using System;
using Contactum.Application.Interfaces.Repositories;
using Contactum.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Contactum.Infrastructure.Repositories;

public class CompanyRepository : ICompanyRepository
{
    private readonly ContactumDbContext _context;

    public CompanyRepository(ContactumDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Company company)
    {
        await _context.Companies.AddAsync(company);
        await _context.SaveChangesAsync();
    }

    public async Task<IReadOnlyCollection<Company>> GetAllAsync()
    {
        var companies = await _context.Companies.ToListAsync();
        return companies.AsReadOnly();
    }

    public async Task<Company?> GetByIdAsync(int id)
    {
        return await _context.Companies.FindAsync(id);
    }
}
