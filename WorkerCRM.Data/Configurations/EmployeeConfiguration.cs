﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WorkerCRM.Models;

namespace WorkerCRM.Data.Configurations
{
    class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
       
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName).HasMaxLength(256).IsRequired();

            builder.Property(x => x.SecondName).HasMaxLength(256).IsRequired();

            builder.Property(x => x.MiddleName).HasMaxLength(256);
            
            builder.Property(x => x.PhoneNumber).HasMaxLength(20);

            builder.Property(x => x.Email).HasMaxLength(60);

        }
    }
}
