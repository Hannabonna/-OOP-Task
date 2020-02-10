using System;
using System.IO;
using System.Reflection;


namespace Learn_Oop
{
    public class Log
    {
        private const string FILE_EXT = ".log";
        private readonly string datetimeFormat;
        private readonly string logFilename;

        public Log(bool append = false)
        {
            datetimeFormat = "yyyy-MM-dd HH:mm:ss.fff";
            logFilename = Assembly.GetExecutingAssembly().GetName().Name + FILE_EXT;

            string logHeader = logFilename + " is created.";
            if (!File.Exists(logFilename))
            {
                append = false;
            }

            if (append == false)
            {
                WriteLine(DateTime.Now.ToString(datetimeFormat) + " " + logHeader, false);
            }
        }

        public void Debug(string text)
        {
            WriteFormattedLog(LogLevel.DEBUG, text);
        }

        public void Error(string text)
        {
            WriteFormattedLog(LogLevel.ERROR, text);
        }

        public void Notice(string text)
        {
            WriteFormattedLog(LogLevel.NOTICE, text);
        }

        public void Info(string text)
        {
            WriteFormattedLog(LogLevel.INFO, text);
        }

        public void Trace(string text)
        {
            WriteFormattedLog(LogLevel.ALERT, text);
        }

        public void Alert(string text)
        {
            WriteFormattedLog(LogLevel.ALERT, text);
        }

        public void Critical(string text)
        {
            WriteFormattedLog(LogLevel.CRITICAL, text);
        }

        public void Emergency(string text)
        {
            WriteFormattedLog(LogLevel.EMERGENCY, text);
        }

        private void WriteLine(string text, bool append = true)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(logFilename, append, System.Text.Encoding.UTF8))
                {
                    if (!string.IsNullOrEmpty(text))
                    {
                        writer.WriteLine(text);
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        private void WriteFormattedLog(LogLevel level, string text)
        {
            string pretext;
            switch (level)
            {
                case LogLevel.NOTICE:
                    pretext = DateTime.Now.ToString(datetimeFormat) + " [NOTICE]   ";
                    break;
                case LogLevel.INFO:
                    pretext = DateTime.Now.ToString(datetimeFormat) + " [INFO]    ";
                    break;
                case LogLevel.DEBUG:
                    pretext = DateTime.Now.ToString(datetimeFormat) + " [DEBUG]   ";
                    break;
                case LogLevel.WARNING:
                    pretext = DateTime.Now.ToString(datetimeFormat) + " [WARNING] ";
                    break;
                case LogLevel.ERROR:
                    pretext = DateTime.Now.ToString(datetimeFormat) + " [ERROR]   ";
                    break;
                case LogLevel.ALERT:
                    pretext = DateTime.Now.ToString(datetimeFormat) + " [ALERT]   ";
                    break;
                case LogLevel.CRITICAL:
                    pretext = DateTime.Now.ToString(datetimeFormat) + " [CRITICAL]   ";
                    break;
                case LogLevel.EMERGENCY:
                    pretext = DateTime.Now.ToString(datetimeFormat) + " [EMERGENCY]   ";
                    break;
                default:
                    pretext = "";
                    break;
            }

            WriteLine(pretext + text);
        }

        private enum LogLevel
        {
            INFO,
            ERROR,
            NOTICE,
            WARNING,
            DEBUG,
            ALERT,
            CRITICAL,
            EMERGENCY
        }
    }
}
