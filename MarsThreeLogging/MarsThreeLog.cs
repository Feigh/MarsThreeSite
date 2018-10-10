using System;
using System.IO;
using Microsoft.Extensions.Logging;

namespace MarsThreeLogging
{

    public class MarsThreeLoggerProvider : ILoggerProvider
    {
        private readonly MarsThreeLogger _logger = new MarsThreeLogger();

        public ILogger CreateLogger(string categoryName)
        {
            return _logger;
        }

        public void Dispose()
        {
        }
    }

    public class MarsThreeLogger : ILogger
    {
        private string _filePath;
        private string _fileName;
        private static readonly Object obj = new Object();

        public MarsThreeLogger()
        {

            _filePath = "C:/Temp/log/";
            _fileName = string.Format("logFil_{0}.log",  DateTime.Today.ToString("yyyyMMdd"));
            lock (obj)
            {
                File.AppendAllText(_filePath+ _fileName, "Start logging \n");
            }
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            _fileName = string.Format("logFil_{0}.log", DateTime.Today.ToString("yyyyMMdd"));
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            switch (logLevel)
            {
                case LogLevel.Information:
                    return false;
                case LogLevel.Trace:
                case LogLevel.Debug:
                case LogLevel.Warning:
                case LogLevel.Error:
                case LogLevel.Critical:
                case LogLevel.None:
                    return true;
            }
            return false;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel)) return;
            
            string fileToWrite = _filePath+_fileName;
            lock(obj)
            {
                string message = string.Format("Level:{0} message: {1} event:{2} \n", logLevel.ToString(), state.ToString(), eventId.ToString());
                File.AppendAllText(fileToWrite, message);
            }
        }
    }
}