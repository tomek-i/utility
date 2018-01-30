using System;
using System.Text;

namespace TI.Utilities.Logic
{
    public static class App
    {
        //https://stackoverflow.com/questions/9788962/how-to-get-a-dump-of-all-local-variables


        public static event EventHandler<string> UnhandledExceptionMessage;

        private static void UnhandledException(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"EXCEPTION OCCURED: {DateTime.Now}");
            sb.AppendLine(args.ExceptionObject.GetType().Name);
            sb.AppendLine($"Is terminating: {args.IsTerminating}");
            sb.AppendLine("=====MESSAGE=====");
            sb.AppendLine(e.Message);
            sb.AppendLine("=====STACK=====");
            sb.AppendLine(e.StackTrace);

            e = e.InnerException;
            while (e != null)
            {
                sb.AppendLine("=======INNER=====");
                sb.AppendLine(e.Message);
                sb.AppendLine("=======STACK=====");
                sb.AppendLine(e.StackTrace);
            }
            sb.AppendLine();
            sb.AppendLine();

            UnhandledExceptionMessage?.Invoke(sender, sb.ToString());
        }

        public static void RegisterUnhaledExceptions(AppDomain domain)
        {
            domain.UnhandledException += UnhandledException;
        }

        public static void RegisterUnhaledExceptions()
        {
            AppDomain.CurrentDomain.UnhandledException += UnhandledException;
        }

    }
}
