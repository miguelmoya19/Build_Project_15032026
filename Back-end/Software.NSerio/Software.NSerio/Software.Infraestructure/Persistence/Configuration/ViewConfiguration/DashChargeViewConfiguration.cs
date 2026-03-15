using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Software.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software.Infraestructure.Persistence.Configuration.ViewConfiguration
{
    public class DashChargeViewConfiguration : IEntityTypeConfiguration<ChargeDeveloper>
    {
        public void Configure(EntityTypeBuilder<ChargeDeveloper> builder)
        {
            builder.ToView("ChargeDeveloper");

            builder.HasKey(s => s.DeveloperId);

            builder.Property(s => s.FullName)
                .HasColumnName("FullName")
                .IsRequired()
                .HasMaxLength(120);

            builder.Property(s => s.OpenTasksCount)
                .HasColumnName("OpenTasksCount")
                .IsRequired()
                .HasMaxLength(120);

            builder.Property(s => s.AverageEstimatedComplexity)
                .HasColumnName("AverageEstimatedComplexity")
                .IsRequired()
                .HasMaxLength(120);

        
        }
    }
}
