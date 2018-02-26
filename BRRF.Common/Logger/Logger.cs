using BRRF.Core.BusinessManager.Interface;
using System;
using System.Collections.Generic;

namespace BRRF.Common
{
    public class Logger
    {
        private List<ILogger> _observers;

        public Logger()
        {
            _observers = new List<ILogger>();
        }

        public void RegisterLogger(ILogger logger)
        {
            if (!_observers.Contains(logger))
            {
                _observers.Add(logger);
            }
        }

        internal void AddLogMessage(string message, LogType logType)
        {

            var log
                = new Log
                {
                    Date = DateTime.Now,
                    Message = message,
                    LogType = logType.ToString()
                };

            foreach (ILogger observer in _observers)
            {
                observer.ProcessLogMessage<Log>(log);
            }
        }
    }
    public class Log
    {
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public string LogType { get; set; }
    }
    public enum LogType { Info, Error }
}