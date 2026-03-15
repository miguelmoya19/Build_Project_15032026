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
    public class DevConfiguration : IEntityTypeConfiguration<Developers>
    {
        public void Configure(EntityTypeBuilder<Developers> builder)
        {
            builder.ToTable("Developers");

            builder.HasKey(s => s.DeveloperId );

            builder.Property(s => s.FirstName)
                .HasColumnName("FirstName")
                .IsRequired()
                .HasMaxLength(120);
                
            builder.Property(s => s.LastName)
                .HasColumnName("LastName")
                .IsRequired()
                .HasMaxLength(120);

            builder.Property(s => s.IsActive)
                .HasColumnName("IsActive");

            builder.Property(s => s.CreatedAt)
                .HasColumnName("CreatedAt");

            builder.OwnsOne(e => e.Email, email =>
            {
                email.Property(es => es.ValueEmail)
                      .HasColumnName("Email")
                      .HasMaxLength(200);
            });
        }
    }
}
