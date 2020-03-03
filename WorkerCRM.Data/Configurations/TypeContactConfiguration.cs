using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WorkerCRM.Models;

namespace WorkerCRM.Data.Configurations
{
    class TypeContactConfiguration : IEntityTypeConfiguration<TypeContact>
    {
       
        public void Configure(EntityTypeBuilder<TypeContact> builder)
        {
            builder.HasKey(t =>t.Id);
            builder.Property(x => x.Name).HasMaxLength(256).IsRequired();

        }
    }
}
