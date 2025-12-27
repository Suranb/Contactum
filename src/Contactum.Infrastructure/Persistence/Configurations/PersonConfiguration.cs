using System;
using Contactum.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contactum.Infrastructure.Persistence.Configurations;

public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable("person");
        
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).HasColumnName("id");
        
        builder.Property(p => p.FirstName)
            .HasColumnName("first_name")
            .HasMaxLength(100)
            .IsRequired();
        
        builder.Property(p => p.LastName)
            .HasColumnName("last_name")
            .HasMaxLength(100)
            .IsRequired();
        
        builder.Property(p => p.Email)
            .HasColumnName("email")
            .HasMaxLength(255);
        
        builder.Property(p => p.PhoneNumber)
            .HasColumnName("phone_number")
            .HasMaxLength(20);
        
        builder.Property(p => p.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();
        
        builder.Property(p => p.UpdatedAt)
            .HasColumnName("updated_at")
            .IsRequired();
        
        // Configure inverse relationships (optional, but explicit is better)
        builder.HasMany(p => p.OwnedCompanies)
            .WithOne(c => c.Owner)
            .HasForeignKey(c => c.OwnerId);
        
        builder.HasMany(p => p.ContactForCompanies)
            .WithOne(c => c.ContactPerson)
            .HasForeignKey(c => c.ContactPersonId);
    }
}