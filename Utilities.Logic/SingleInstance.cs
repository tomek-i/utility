using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;

namespace TIUtilities.Logic
{

    internal class NativeMethods
    {
        public const int HWND_BROADCAST = 0xffff;
        public static readonly int WM_SHOWME = RegisterWindowMessage("WM_SHOWME");
        [DllImport("user32")]
        public static extern bool PostMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);
        [DllImport("user32")]
        public static extern int RegisterWindowMessage(string message);
    }
    public class SingleInstance : IDisposable
    {
        public static class Application
        {
            const int SW_RESTORE = 9;

            [System.Runtime.InteropServices.DllImport("User32.dll")]
            private static extern bool SetForegroundWindow(IntPtr handle);
            [System.Runtime.InteropServices.DllImport("User32.dll")]
            private static extern bool ShowWindow(IntPtr handle, int nCmdShow);
            [System.Runtime.InteropServices.DllImport("User32.dll")]
            private static extern bool IsIconic(IntPtr handle);




            [DllImport("user32.dll")]
            static extern Int32 FlashWindowEx(ref FLASHWINFO pwfi);
            [StructLayout(LayoutKind.Sequential)]
            public struct FLASHWINFO
            {
                public UInt32 cbSize;
                public IntPtr hwnd;
                public Int32 dwFlags;
                public UInt32 uCount;
                public Int32 dwTimeout;
            }
            // stop flashing
            const int FLASHW_STOP = 0;
            // flash the window title
            const int FLASHW_CAPTION = 1;
            // flash the taskbar button
            const int FLASHW_TRAY = 2;
            // 1 | 2
            const int FLASHW_ALL = 3;
            // flash continuously
            const int FLASHW_TIMER = 4;
            // flash until the window comes to the foreground
            const int FLASHW_TIMERNOFG = 12;


            public static void flash(IntPtr handle, bool stop)
            {
                FLASHWINFO fw = new FLASHWINFO();
                fw.cbSize = Convert.ToUInt32(Marshal.SizeOf(typeof(FLASHWINFO)));
                fw.hwnd = handle;

                if (!stop)
                    fw.dwFlags = FLASHW_ALL;
                else
                    fw.dwFlags = 0;
                fw.uCount = UInt32.MaxValue;
                FlashWindowEx(ref fw);
            }
            public static void Run(System.Windows.Forms.Form mainForm)
            {
                try
                {
                    using (var instance = new SingleInstance(TimeSpan.FromSeconds(3), Assembly.GetEntryAssembly(), mainForm.Name))
                    {
                        System.Windows.Forms.Application.Run(mainForm);
                    }
                }
                catch (Exception)
                {

                    var process = Process.GetProcessesByName($"{Assembly.GetEntryAssembly().GetName().Name}").SingleOrDefault();
                    var handle = process.MainWindowHandle;

                    if (process != null)
                    {
                        if (IsIconic(handle))
                        {
                            ShowWindow(handle, SW_RESTORE);
                        }

                        SetForegroundWindow(handle);

                        flash(handle, false);
                        Task.Delay(TimeSpan.FromSeconds(1.75)).ContinueWith((t) =>
                        {
                            flash(handle, true);
                        });


                        Thread.Sleep(3000);








                    }
                    //bring existing window to front
                    //    NativeMethods.PostMessage(
                    //(IntPtr)NativeMethods.HWND_BROADCAST,
                    //NativeMethods.WM_SHOWME,
                    //IntPtr.Zero,
                    //IntPtr.Zero);

                }

            }
        }


        public SingleInstance(TimeSpan timeOut)
            : this(timeOut, Assembly.GetExecutingAssembly(), null)
        {
        }

        public SingleInstance(int timeoutMilliseconds)
            : this(TimeSpan.FromMilliseconds(timeoutMilliseconds),
                Assembly.GetExecutingAssembly(), null)
        {
        }

        public SingleInstance(int timeoutMilliseconds, Assembly assembly)
            : this(TimeSpan.FromMilliseconds(timeoutMilliseconds), assembly, null)
        {
        }

        public SingleInstance(TimeSpan timeOut, Assembly executingAssembly) : this(timeOut, executingAssembly, null)
        { }
        public SingleInstance(TimeSpan timeOut, Assembly executingAssembly, string version)
        {
            _executingAssembly = executingAssembly;

            InitMutex(version);
            try
            {
                HasHandle = _mutex.WaitOne(timeOut < TimeSpan.Zero ? Timeout.InfiniteTimeSpan : timeOut, true);

                if (HasHandle == false)
                {

                    throw new TimeoutException("Timeout waiting for exclusive access on SingleInstance");
                }
            }
            catch (AbandonedMutexException)
            {
                HasHandle = true;
            }
        }

        public void Dispose()
        {
            if (_mutex == null) return;
            if (HasHandle)
                _mutex.ReleaseMutex();
            _mutex.Dispose();
        }

        private void InitMutex(string version)
        {
            var appGuid = ((GuidAttribute)_executingAssembly.GetCustomAttributes(typeof(GuidAttribute), false).GetValue(0)).Value + version;
            var mutexId = $"Global\\{{{appGuid}}}";

            _mutex = new Mutex(true, mutexId);

            var allowEveryoneRule = new MutexAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null),
                MutexRights.FullControl, AccessControlType.Allow);
            var securitySettings = new MutexSecurity();
            securitySettings.AddAccessRule(allowEveryoneRule);
            _mutex.SetAccessControl(securitySettings);
        }

        #region  FIELDS

        private readonly Assembly _executingAssembly;
        private Mutex _mutex;
        public bool HasHandle;

        #endregion
    }
}