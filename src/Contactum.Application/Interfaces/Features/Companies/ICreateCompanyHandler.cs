using Contactum.Application.Features.Companies;
using Contactum.Application.Results;

namespace Contactum.Application.Interfaces.Features.Companies;

public interface ICreateCompanyHandler
{
    Task<Result<int>> HandleAsync(CreateCompanyCommand command);
}
