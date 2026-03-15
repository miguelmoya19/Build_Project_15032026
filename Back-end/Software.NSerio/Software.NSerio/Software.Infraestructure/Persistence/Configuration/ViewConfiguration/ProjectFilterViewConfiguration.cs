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
    public class ProjectFilterViewConfiguration : IEntityTypeConfiguration<ProjectWithTaskFilterView>
    {
        public void Configure(EntityTypeBuilder<ProjectWithTaskFilterView> builder)
        {
            builder.ToView("ProjectWithTaskListFilter");

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

            builder.Property(s => s.AssigneeId)
                .HasColumnName("AssigneeId");


        }
    }
}

