using Contactum.Application.Results;
using Contactum.Domain.Models;

namespace Contactum.Application.Interfaces.Features.Companies;

public interface IGetAllCompaniesHandler
{
    Task<Result<IReadOnlyCollection<Company>>> HandleAsync();
}