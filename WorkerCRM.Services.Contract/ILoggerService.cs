using System;
using System.Collections.Generic;
using System.Text;

namespace WorkerCRM.Services.Contract
{
    public interface ILoggerService
    {
        void LogOrderSuccess(string name, string phone);
        void LogOrderError(Exception e, string name, string phone);
    }
}
