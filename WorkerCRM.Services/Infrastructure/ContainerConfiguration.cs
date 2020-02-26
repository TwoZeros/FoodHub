
using Microsoft.Extensions.DependencyInjection;
using WorkerCRM.Services.Contract;
using System;
using System.Collections.Generic;
using System.Text;
using WorkerCRM.Services;

namespace WorkerCRM.Services.Infrastructure
{
    public class ContainerConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            WorkerCRM.Data.Infrastructure.ContainerConfiguration.Configure(services);
            services.AddTransient<ILoggerService, LoggerService>();
        }
    }
}
