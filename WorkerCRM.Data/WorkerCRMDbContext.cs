using Microsoft.EntityFrameworkCore;
using WorkerCRM.Data.Configurations;
using WorkerCRM.Models;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Text;



namespace WorkerCRM.Data
{
    public class WorkerCRMDbContext : DbContext
    {
        
       public WorkerCRMDbContext(DbContextOptions<WorkerCRMDbContext> options) : base(options)
        {

        }
     
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new LogConfiguration());
            builder.ApplyConfiguration(new EmployeeConfiguration());
            builder.ApplyConfiguration(new TypeContactConfiguration());
            builder.ApplyConfiguration(new EmployeeContactConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
        }

        public DbSet<LogEntry> Logs { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<TypeContact> TypeContact { get; set; }

        public DbSet<EmployeeContact> EmployeeContact { get; set; }
    }
}
