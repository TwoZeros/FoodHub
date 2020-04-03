﻿using Microsoft.EntityFrameworkCore;
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

            builder.ApplyConfiguration(new UserConfiguration());

            builder.Entity<User>().HasData(
               new User[]
               {
                new User { Id=1, Login="Admin", Password="12345678",Role="Admin"},
               });
            builder.Entity<Position>().HasData(
               new Position[]
               {
                new Position { Id=1, Name="Директор", IsAllowedDelete=false},
                new Position { Id=2, Name="Менеджер", IsAllowedDelete=false},
                new Position { Id=3, Name="Курьер", IsAllowedDelete=false},
                new Position { Id=4, Name="Повар", IsAllowedDelete=false},

               });
        }

        public DbSet<LogEntry> Logs { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Position> Positions { get; set; }
       
    }
}
