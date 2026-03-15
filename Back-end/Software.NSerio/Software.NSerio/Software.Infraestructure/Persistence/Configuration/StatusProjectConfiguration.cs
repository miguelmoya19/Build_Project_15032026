using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Software.Domain.Entities;
using Software.Infraestructure.Persistence.View;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software.Infraestructure.Persistence.Configuration
{
    public class StatusProjectConfiguration : IEntityTypeConfiguration<StatusProjectView>
    {
        public void Configure(EntityTypeBuilder<StatusProjectView> builder)
        {
            builder.HasKey(s => s.ProjectId);

            builder.Property(s => s.Name)
                .HasColumnName("Name")
                .IsRequired()
                .HasMaxLength(120);

            builder.Property(s => s.ClientName)
                .HasColumnName("ClientName")
                .IsRequired()
                .HasMaxLength(120);

            builder.Property(s => s.Status)
                .HasColumnName("Status")
                .IsRequired()
                .HasMaxLength(120);

            builder.Property(s => s.OpenTasks)
                .HasColumnName("OpenTasks")
                .IsRequired()
                .HasMaxLength(120);

            builder.Property(s => s.CompletedTasks)
                .HasColumnName("CompletedTasks")
                .IsRequired()
                .HasMaxLength(120);

            builder.Property(s => s.TotalTasks)
                .HasColumnName("TotalTasks")
                .IsRequired()
                .HasMaxLength(120);
        }
    }
}
