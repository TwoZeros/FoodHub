using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WorkerCRM.Models;

namespace WorkerCRM.Data.Configurations
{
    class EmployeeContactConfiguration : IEntityTypeConfiguration<EmployeeContact>
    {
        public void Configure(EntityTypeBuilder<EmployeeContact> builder)
        {
            builder.HasKey(t => new { t.EmployeeId, t.TypeContactId });

            builder.Property(t => t.Value).HasMaxLength(256).IsRequired();

            builder
                  .HasOne(sc => sc.Employee)
                  .WithMany(c => c.EmployeeContact)
                  .HasForeignKey(sc => sc.EmployeeId);
                  
            builder
             .HasOne(sc => sc.TypeContact)
             .WithMany(c => c.EmployeeContact)
             .HasForeignKey(sc => sc.TypeContactId); 
        }
    }
}
