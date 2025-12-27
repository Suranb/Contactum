using System;
using Contactum.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contactum.Infrastructure.Persistence.Configurations;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.ToTable("company");

        // Primary key
        builder.HasKey(c => c.Id); builder.Property(c => c.Id).HasColumnName("id");

        // Properties with snake_case column names
        builder.Property(c => c.Name).HasColumnName("name").HasMaxLength(200).IsRequired();
        builder.Property(c => c.OrganizationNumber).HasColumnName("organization_number");
        builder.Property(c => c.Description).HasColumnName("description").HasMaxLength(1000);
        builder.Property(c => c.CreatedAt).HasColumnName("created_at").IsRequired();
        builder.Property(c => c.UpdatedAt).HasColumnName("updated_at").IsRequired();
        builder.Property(c => c.OwnerId).HasColumnName("owner_id");
        builder.Property(c => c.ContactPersonId).HasColumnName("contact_person_id");
        
        // Relationships to Person
        builder.HasOne(c => c.Owner)
            .WithMany(p => p.OwnedCompanies)
            .HasForeignKey(c => c.OwnerId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull); // If person is deleted, set owner_id to NULL
        
        builder.HasOne(c => c.ContactPerson)
            .WithMany(p => p.ContactForCompanies)
            .HasForeignKey(c => c.ContactPersonId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);
    }
}