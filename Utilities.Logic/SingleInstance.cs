using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Threading;

namespace TIUtilities.Logic
{

    public class SingleInstance : IDisposable
    {
        public SingleInstance(TimeSpan timeOut)
            : this(timeOut,Assembly.GetExecutingAssembly(),null)
        {
        }

        public SingleInstance(int timeoutMilliseconds)
            : this(TimeSpan.FromMilliseconds(timeoutMilliseconds),
                Assembly.GetExecutingAssembly(),null)
        {
        }

        public SingleInstance(int timeoutMilliseconds, Assembly assembly)
            : this(TimeSpan.FromMilliseconds(timeoutMilliseconds),assembly,null)
        {
        }

        public SingleInstance(TimeSpan timeOut, Assembly executingAssembly, string version)
        {
            _executingAssembly = executingAssembly;

            InitMutex(version);
            try
            {
                HasHandle = _mutex.WaitOne(timeOut < TimeSpan.Zero ? Timeout.InfiniteTimeSpan : timeOut, false);

                if (HasHandle == false)
                    throw new TimeoutException("Timeout waiting for exclusive access on SingleInstance");
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
            var appGuid = ((GuidAttribute) _executingAssembly.GetCustomAttributes(typeof (GuidAttribute), false).GetValue(0)).Value + version;
            var mutexId = $"Global\\{{{appGuid}}}";
            _mutex = new Mutex(false, mutexId);

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