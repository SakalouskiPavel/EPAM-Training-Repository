using System;
using System.IO;

namespace NET.W._2018.Соколовский._21
{
    public class Logger
    {
        private string _logFilePath;

        public Logger()
        {
            this._logFilePath = "log.txt";
        }

        public Logger(string logFilePath)
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