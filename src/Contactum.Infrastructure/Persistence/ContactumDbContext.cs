using System;
using Contactum.Domain.Models;
using Contactum.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Contactum.Infrastructure;

public class ContactumDbContext : DbContext
{
    public ContactumDbContext(DbContextOptions<ContactumDbContext> options) : base(options)
    {
    }
    public DbSet<Company> Companies { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new CompanyConfiguration());
    }
}
