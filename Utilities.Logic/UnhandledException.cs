using System;
using System.Text;
using TI.Utilities.Logic.Delegates;

namespace TI.Utilities.Logic
{

    public static class UnhandledException
    {
        //https://stackoverflow.com/questions/9788962/how-to-get-a-dump-of-all-local-variables

        internal static event UnhandledExceptionHandler UnhandledExceptionEvent;


        private static void OnUnhandledException(StringBuilder errorMessage)
        {
            if (UnhandledExceptionEvent == null) return;
            UnhandledExceptionEvent(errorMessage);
        }


        public static void Register(UnhandledExceptionHandler eventHandler)
        {
            if (eventHandler == null)
                throw new NullReferenceException("You have to specify an event handler.");

            if (UnhandledExceptionEvent != null)
                throw new InvalidOperationException("You can only specify one Unhandled Event Handler.");

            UnhandledExceptionEvent = eventHandler;

            AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
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
                TRAVERSE:
                e = e.InnerException;
                if (e != null)
                {
                    sb.AppendLine("=======INNER=====");
                    sb.AppendLine(e.Message);
                    sb.AppendLine("=======STACK=====");
                    sb.AppendLine(e.StackTrace);
                    goto TRAVERSE;
                }
                sb.AppendLine();
                sb.AppendLine();


                OnUnhandledException(sb);

            };
        }
    }
}
