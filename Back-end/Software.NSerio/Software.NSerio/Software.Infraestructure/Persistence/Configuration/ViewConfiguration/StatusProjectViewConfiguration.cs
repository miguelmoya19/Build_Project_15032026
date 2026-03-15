using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Software.Domain.Entities;
using Software.Infraestructure.Persistence.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software.Infraestructure.Persistence.Configuration.ViewConfiguration
{
    public class StatusProjectViewConfiguration : IEntityTypeConfiguration<StatusProjectView>
    {
        public void Configure(EntityTypeBuilder<StatusProjectView> builder)
        {
            builder.ToView("StatusProjectView");

            builder.HasKey(s => s.ProjectId);

            builder.Property(s => s.Name)
                .HasColumnName("Name")
                .IsRequired()
                .HasMaxLength(120);

            builder.Property(s => s.ClientName)
                .HasColumnName("ClientName")
                .IsRequired()
                .HasMaxLength(120);

            builder.Property(s => s.TotalTasks)
                .HasComputedColumnSql("ISNULL([OpenTasks],0) + ISNULL([CompletedTasks],0)", stored: true);

            builder.Property(s => s.Status)
                .HasColumnName("Status");

            builder.Property(s => s.AssigneeId)
                .HasColumnName("AssigneeId");

            builder.Property(s => s.OpenTasks)
                .HasColumnName("OpenTasks");

            builder.Property(s => s.CompletedTasks)
                .HasColumnName("CompletedTasks");

           
        }
    }
}
