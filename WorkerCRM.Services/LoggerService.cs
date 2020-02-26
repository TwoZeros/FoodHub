using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using WorkerCRM.Common;
using WorkerCRM.Services.Contract;
using Serilog;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace WorkerCRM.Services
{
    public class LoggerService : ILoggerService
    {
        private Logger _orderLog;
        public LoggerService(IOptions<LoggerSettings> options)
        {
            var date = DateTime.Now;
            var logPath = options.Value.OrderLogPath + date.ToString("yyyy.MM.dd") + ".txt";
            _orderLog = new LoggerConfiguration().WriteTo.File(logPath).CreateLogger();
        }

        public void LogOrderSuccess(string name, string phone)
        {
            string currentDatetime = DateTime.Now.ToString();
            string successMessage = "{0} - Success. Name:{1} | Phone {2}";
            _orderLog.Information(string.Format(successMessage, currentDatetime, name, phone));
        }
        public void LogOrderError(Exception e, string name, string phone)
        {
            string errorMessage = "ERROR: {0} {1} - Name:{2} | Phone {3}";
            string currentDatetime = DateTime.Now.ToString();
            _orderLog.Error(string.Format(errorMessage, e.Message, currentDatetime, name, phone));
        }
    }
}
