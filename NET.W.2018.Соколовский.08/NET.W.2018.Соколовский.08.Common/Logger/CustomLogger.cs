using System.Diagnostics;
using System.Runtime.CompilerServices;
using NLog;

namespace NET.W._2018.Соколовский._08.Common.Logger
{
    public class CustomLogger
    {
        private static ILogger _logger;

        public CustomLogger()
        {
            _logger = LogManager.GetCurrentClassLogger();
        }

        public CustomLogger(ILogger logger)
        {
            if (!ReferenceEquals(logger, null))
            {
                _logger = logger;
            }
            else
            {
                _logger = LogManager.GetCurrentClassLogger();
            }
        }

        public static void Debug(string message)
        {
            _logger.Debug(message);
        }

        public static void Info(string message)
        {
            _logger.Info(message);
        }

        public static void Warn(string message)
        {
            _logger.Warn(message);
        }

        public static void Error(string message)
        {
            _logger.Error(message);
        }

        public static void Fatal(string message)
        {
            _logger.Fatal(message);
        }
    }
}