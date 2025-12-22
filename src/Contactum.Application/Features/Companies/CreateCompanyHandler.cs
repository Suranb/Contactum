using Contactum.Application.Interfaces;
using Contactum.Application.Interfaces.Features.Companies;
using Contactum.Application.Interfaces.Repositories;
using Contactum.Application.Results;
using Contactum.Domain.Models;

namespace Contactum.Application.Features.Companies;

public class CreateCompanyCommand
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int? OrganizationNumber { get; set; }
}

public class CreateCompanyHandler : ICreateCompanyHandler
{
    private readonly ICompanyRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCompanyHandler(ICompanyRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> HandleAsync(CreateCompanyCommand command)
    {
        if (string.IsNullOrWhiteSpace(command.Name))
            return Result<int>.Failure("Company name is required");

        var company = new Company(name: command.Name, description: command.Description);

        await _repository.AddAsync(company);
        await _unitOfWork.SaveChangesAsync();

        return Result<int>.Success(company.Id);
    }
}