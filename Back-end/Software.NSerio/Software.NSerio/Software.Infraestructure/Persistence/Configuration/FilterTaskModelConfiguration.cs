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
    internal class FilterTaskModelConfiguration : IEntityTypeConfiguration<FilterTaskModelReposi>
    {
        public void Configure(EntityTypeBuilder<FilterTaskModelReposi> builder)
        {
            builder.HasNoKey();

            builder.Property(s => s.Title)
                .HasColumnName("Title")
                .IsRequired()
                .HasMaxLength(120);

            builder.Property(s => s.Fullname)
                .HasColumnName("Fullname")
                .IsRequired()
                .HasMaxLength(120);

            builder.Property(s => s.Status)
                .HasColumnName("Status")
                .IsRequired()
                .HasMaxLength(120);

            builder.Property(s => s.Priority)
                .HasColumnName("Priority")
                .IsRequired()
                .HasMaxLength(120);

            builder.Property(s => s.EstimatedComplexity)
                .HasColumnName("EstimatedComplexity")
                .IsRequired()
                .HasMaxLength(120);

            builder.Property(s => s.CreatedAt)
                .HasColumnName("CreatedAt")
                .IsRequired()
                .HasMaxLength(120);

            builder.Property(s => s.DueDate)
                .HasColumnName("DueDate")
                .IsRequired()
                .HasMaxLength(120);
        }
    }
}
