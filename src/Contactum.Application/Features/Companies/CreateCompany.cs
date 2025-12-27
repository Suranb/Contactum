using System.ComponentModel.DataAnnotations;
using Contactum.Application.Interfaces;
using Contactum.Application.Interfaces.Repositories;
using Contactum.Application.Results;
using Contactum.Domain.Models;
using FluentValidation;

namespace Contactum.Application.Features.Companies;

public class CreateCompanyCommand
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int? OrganizationNumber { get; set; }
    public Person? Owner { get; set; }
    public Person? ContactPerson { get; set; }
}

public class CreateCompanyCommandValidator : AbstractValidator<CreateCompanyCommand>
{
    public CreateCompanyCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Company name is required")
            .MaximumLength(200).WithMessage("Company name cannot exceed 200 characters")
            .MinimumLength(2).WithMessage("Company name must be at least 2 characters");
        
        RuleFor(x => x.Description)
            .MaximumLength(1000).WithMessage("Description cannot exceed 1000 characters")
            .When(x => !string.IsNullOrEmpty(x.Description));
        
        RuleFor(x => x.OrganizationNumber)
            .Must(BeValidNorwegianOrgNumber)
            .WithMessage("Invalid Norwegian organization number")
            .When(x => x.OrganizationNumber.HasValue);

        /*RuleFor(x => x.Owner)
            .SetValidator(new PersonValidator());

        RuleFor(x => x.ContactPerson)
            .SetValidator(new PersonValidator());*/
    }
    
    private bool BeValidNorwegianOrgNumber(int? orgNumber)
    {
        if (!orgNumber.HasValue) return true;
        
        var orgString = orgNumber.Value.ToString();
        if (orgString.Length != 9) return false;
        
        return ValidateNorwegianChecksum(orgString);
    }
    
    private bool ValidateNorwegianChecksum(string orgNumber)
    {
        int[] weights = { 3, 2, 7, 6, 5, 4, 3, 2 };
        int sum = 0;
        
        for (int i = 0; i < 8; i++)
        {
            sum += (orgNumber[i] - '0') * weights[i];
        }
        
        int remainder = sum % 11;
        int checkDigit = remainder == 0 ? 0 : 11 - remainder;
        
        return checkDigit == (orgNumber[8] - '0');
    }
}

public class CreateCompanyHandler : ICreateCompanyHandler
{
    private readonly ICompanyRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<CreateCompanyCommand> _validator;

    public CreateCompanyHandler(
        ICompanyRepository repository, 
        IUnitOfWork unitOfWork,
        IValidator<CreateCompanyCommand> validator)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task<Result<int>> HandleAsync(CreateCompanyCommand command)
    {
        var validationResult = await _validator.ValidateAsync(command);

        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(errors => errors.ErrorMessage)
                .ToArray();
            return Result<int>.ValidationError(string.Join(", ", errors));
        }

        var company = new Company(name: command.Name, description: command.Description);

        await _repository.AddAsync(company);
        await _unitOfWork.SaveChangesAsync();

        return Result<int>.Success(company.Id);
    }
}

public interface ICreateCompanyHandler
{
    Task<Result<int>> HandleAsync(CreateCompanyCommand command);
}