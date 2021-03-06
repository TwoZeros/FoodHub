﻿
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
            services.AddTransient<IAuthorizationService, AuthorizationService>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IClientService, ClientService>();

            services.AddTransient<ICarmaUser, CarmaUserService>(); 

            services.AddTransient<IEmployeePositionService, EmployeePositionServices>();
            services.AddTransient<ICommentService, CommentService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IProductInOrderService, ProductInOrderService>();

        }
    }
}
