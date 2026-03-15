using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Software.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software.Infraestructure.Persistence.Configuration
{
    internal class ProjectConfiguration : IEntityTypeConfiguration<Projects>
    {
        public void Configure(EntityTypeBuilder<Projects> builder)
        {
            builder.ToTable("Projects");

            builder.HasKey(s => s.ProjectId);

            builder.Property(s => s.Name)
                .HasColumnName("Name")
                .IsRequired()
                .HasMaxLength(120);

            builder.Property(s => s.ClientName)
                .HasColumnName("ClientName")
                .IsRequired()
                .HasMaxLength(120);

            builder.Property(s => s.StartDate)
                .HasColumnName("StartDate");

            builder.Property(s => s.EndDate)
                .HasColumnName("EndDate");

            builder.Property(s => s.Status)
                .HasColumnName("Status");

          
        }

      
    }
}

