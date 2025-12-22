using System;
using Contactum.Application.Interfaces;

namespace Contactum.Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly ContactumDbContext _context;

    public UnitOfWork(ContactumDbContext context)
    {
        _context = context;
    }
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}