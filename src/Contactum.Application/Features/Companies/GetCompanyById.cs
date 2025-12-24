using Contactum.Application.Interfaces.Repositories;
using Contactum.Application.Results;
using Contactum.Domain.Models;

namespace Contactum.Application.Features.Companies;

public class GetCompanyByIdHandler : IGetCompanyByIdHandler
{
    private readonly ICompanyRepository _companyRepistory;
    public GetCompanyByIdHandler(ICompanyRepository companyRepistory)
    {
        _companyRepistory = companyRepistory;
    }

    public async Task<Result<Company>> HandleAsync(int id)
    {
        if (id <= 0) return Result<Company>.ValidationError("Company ID must be greater then 0");

        var company = await _companyRepistory.GetByIdAsync(id);

        if (company is null)
        {
            return Result<Company>.NotFound($"Company with ID '{id}' not found");
        }

        return Result<Company>.Success(company);
    }
}

public interface IGetCompanyByIdHandler
{
    Task<Result<Company>> HandleAsync(int id);
}