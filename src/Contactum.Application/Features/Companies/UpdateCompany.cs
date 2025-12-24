using System;
using Contactum.Application.Interfaces.Repositories;
using Contactum.Application.Results;
using Contactum.Domain.Models;

namespace Contactum.Application.Features.Companies;

public class UpdateCompanyCommand
{
    public string Name { get; set; } = string.Empty;
    public int? OrganizationNumber { get; set; }
    public string? Description { get; set; }
    public Person? Owner { get; set; }
    public Person? ContactPerson { get; set; }
}

public class UpdateCompanyHandler // : IUpdateCompanyHandler
{
    private readonly ICompanyRepository _companyRepository;
    public UpdateCompanyHandler(ICompanyRepository companyRepository)
    {
        _companyRepository = companyRepository;
    }
    
    /*
    public async Task<Result<Company>> HandleAsync(UpdateCompanyCommand data)
    {

        // Do we need to do some validations? We probly want to. 
        // Should we let them to clear out the description, owner etc?

        // We should let them change Name, but should be a Valid name.
    }
    */
}

public interface IUpdateCompanyHandler
{
    Task<Result<Company>> HandleAsync(UpdateCompanyCommand data);
}