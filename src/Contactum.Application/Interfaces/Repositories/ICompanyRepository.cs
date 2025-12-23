using Contactum.Domain.Models;

namespace Contactum.Application.Interfaces.Repositories;

public interface ICompanyRepository
{
    Task AddAsync(Company company);
    Task<IReadOnlyCollection<Company>> GetAllAsync();
    Task<Company?> GetByIdAsync(int id);
}
