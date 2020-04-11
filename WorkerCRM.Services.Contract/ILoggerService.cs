using System;
using System.Collections.Generic;
using System.Text;

namespace WorkerCRM.Services.Contract
{
    public interface ILoggerService
    {
        void LogAboutSuccess(string message);
        void LogAboutError(Exception e, string message);
    }
}
