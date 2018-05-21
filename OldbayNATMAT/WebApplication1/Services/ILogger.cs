namespace WebApplication1.Services
{

        public interface ILogger
        {
            void Write(string message, LogLevel level);
        }

        public enum LogLevel
        {
            Fatal,
            Error,
            Warn,
            Info,
            Debug
        }
    
}
