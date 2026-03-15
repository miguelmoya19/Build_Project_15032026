using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Software.Infraestructure.Persistence.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software.Infraestructure.Persistence.Configuration.ViewConfiguration
{
    public class AllTasksViewConfiguration : IEntityTypeConfiguration<AllTasksView>
    {
        public void Configure(EntityTypeBuilder<AllTasksView> builder)
        {
            builder.ToView("AllTasksView");

            builder.HasKey(s => s.TaskId);

            builder.Property(s => s.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(120);

            builder.Property(s => s.Title)
                .HasColumnName("Title")
                .IsRequired()
                .HasMaxLength(120);

            builder.Property(s => s.Description)
                .HasColumnName("Description")
                .IsRequired()
                .HasMaxLength(120);

            builder.Property(s => s.Assignee)
                .HasColumnName("Assignee")
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

            builder.Property(s => s.DueDate)
                .HasColumnName("DueDate")
                .IsRequired()
                .HasMaxLength(120);
        }
    }
}
