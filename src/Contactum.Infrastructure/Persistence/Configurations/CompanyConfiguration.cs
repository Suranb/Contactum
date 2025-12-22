using System;
using Contactum.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contactum.Infrastructure.Persistence.Configurations;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.ToTable("companies");

        // Primary key
        builder.HasKey(c => c.Id); builder.Property(c => c.Id).HasColumnName("id");

        // Properties with snake_case column names
        builder.Property(c => c.Name).HasColumnName("name").HasMaxLength(200).IsRequired();
        builder.Property(c => c.OrganizationNumber).HasColumnName("organization_number");
        builder.Property(c => c.Description).HasColumnName("description").HasMaxLength(1000);
        builder.Property(c => c.CreatedAt).HasColumnName("created_at").IsRequired();
        builder.Property(c => c.UpdatedAt).HasColumnName("updated_at").IsRequired();
        builder.HasOne(c => c.Owner).WithMany().HasForeignKey("owner_id");
        builder.HasOne(c => c.ContactPerson).WithMany().HasForeignKey("person_id");
    }
}