using System;
using Contactum.Application.Interfaces.Features.Companies;
using Contactum.Application.Interfaces.Repositories;
using Contactum.Application.Results;
using Contactum.Domain.Models;

namespace Contactum.Application.Features.Companies;

public class GetAllCompaniesHandler : IGetAllCompaniesHandler
{
    private readonly ICompanyRepository _companyRepository;
    public GetAllCompaniesHandler(ICompanyRepository companyRepository)
    {
        _companyRepository = companyRepository;
    }

    public async Task<Result<IReadOnlyCollection<Company>>> HandleAsync()
    {
        var companies = await _companyRepository.GetAllAsync();

        if (companies.Count == 0)
            return Result<IReadOnlyCollection<Company>>.NotFound("No companies found");

        return Result<IReadOnlyCollection<Company>>.Success(companies);
    }
}
