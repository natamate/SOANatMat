using System;

namespace WebApplication1.Services
{
    public class Logger : ILogger
    {
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(typeof(Object));

        public void Write(string message, LogLevel level)
        {
            switch (level)
            {
                case LogLevel.Fatal:
                    log.Fatal(message);
                    break;
                case LogLevel.Error:
                    log.Error(message);
                    break;
                case LogLevel.Warn:
                    log.Warn(message);
                    break;
                case LogLevel.Info:
                    log.Info(message);
                    break;
                case LogLevel.Debug:
                    log.Debug(message);
                    break;
            }

        }
    }
}