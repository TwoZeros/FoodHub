using Microsoft.Extensions.DependencyInjection;
using WorkerCRM.Data.Contract.Repositories;
using WorkerCRM.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
namespace WorkerCRM.Data.Infrastructure
{
   public class ContainerConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddTransient<ILogRepository, LogRepository>();
            services.AddTransient<IAuthorizationRepository, AuthorizationRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
        }
    }
}
