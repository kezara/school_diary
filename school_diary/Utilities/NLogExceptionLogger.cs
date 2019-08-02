using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http.ExceptionHandling;

namespace school_diary.Utilities
{
    //log unhandled exceptions
    public class NLogExceptionLogger : ExceptionLogger
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        public override void Log(ExceptionLoggerContext context)
        {
            var fileLine = StackTraceException(context.Exception);
            //returns URI that calls method which throws an exception
            var log = context.Exception.TargetSite;
            //returns exception message
            var loggg = "Exception message: " + context.Exception.Message.ToString();
            var logg = RequestToString(context.Request);
            logger.Info(fileLine);
            logger.Info(logg);
            logger.Info(log);
            logger.Error(loggg);
        }

        //returns method that therow an exception
        private static string RequestToString(HttpRequestMessage request)
        {
            var message = new StringBuilder();
            if (request.Method != null)
                message.Append(request.Method);

            if (request.RequestUri != null)
                message.Append(" ").Append(request.RequestUri);

            return message.ToString();
        }

        //returns string from stacktrace class with info about file and line number which throws an exception
        public static string StackTraceException(Exception exception)
        {
            var st = new StackTrace(exception, true);
            var frame = st.GetFrame(0);
            var line = "File throwing an exception " + frame.GetFileName() + ", line which throw an exception " + frame.GetFileLineNumber();
            return line;
        }
    }
}