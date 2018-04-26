using System;
using System.IO;
using NET.W._2018.Соколовский._16.Interfaces;

namespace NET.W._2018.Соколовский._16.Logger
{
    public class CustomLogger : ILogger
    {
        private string _logFilePath;
        public CustomLogger()
        {
            this._logFilePath = "log.txt";
        }

        public CustomLogger(string logFilePath)
        {
            this._logFilePath = logFilePath;
        }

        /// <summary>
        /// Writes service information to log file.
        /// </summary>
        /// <param name="message"> Service message.</param>
        public void Log(string message)
        {
            using (var stream = new FileStream(this._logFilePath, FileMode.Append, FileAccess.Write, FileShare.Read))
            {
                using (var writer = new BinaryWriter(stream))
                {
                    writer.Write($"{DateTime.Now.ToShortTimeString()} - {message}; {Environment.NewLine}");

                }
            }
        }
    }
}