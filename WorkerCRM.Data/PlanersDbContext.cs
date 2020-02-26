using Microsoft.EntityFrameworkCore;
using WorkerCRM.Data.Configurations;
using WorkerCRM.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace WorkerCRM.Data
{
    public class PlanersDbContext : DbContext
    {
        public PlanersDbContext(DbContextOptions<PlanersDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new LogConfiguration());
        }

        public DbSet<LogEntry> Logs { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
