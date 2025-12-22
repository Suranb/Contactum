using System;
using Contactum.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Contactum.Infrastructure;

public class ContactumDbContext : DbContext
{
    public ContactumDbContext(DbContextOptions<ContactumDbContext> options) : base(options)
    {
    }
    public DbSet<Company> Companies { get; set; }
}
