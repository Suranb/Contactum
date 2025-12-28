using System;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using Contactum.Application.Interfaces;
using Contactum.Application.Interfaces.Repositories;
using Contactum.Application.Results;
using Contactum.Domain.Models;
using FluentValidation;

namespace Contactum.Application.Features.Companies;

public interface ICreateCompanyBulkHandler
{
    Task<Result<BulkCreateResult>> HandleAsync(CreateCompanyBulkCommand command);
}
public class CreateCompanyBulkCommand
{
    public List<CreateCompanyCommand> Companies { get; set; } = new();
}

public class CreateCompaniesBulkCommandValidator : AbstractValidator<CreateCompanyBulkCommand>
{
    public CreateCompaniesBulkCommandValidator()
    {

        RuleFor(x => x.Companies)
            .NotEmpty().WithMessage("At least one company is required")
            .Must(list => list.Count <= 100).WithMessage("Cannot create more than 100 companies at once");


        // Validate each company in the list
        RuleForEach(x => x.Companies)
            .SetValidator(new CreateCompanyCommandValidator());
    }
}

/* RESULT DTO */
public class BulkCreateResult
{
    public int SuccessCount { get; set; }
    public int FailureCount { get; set; }
    public List<BulkCreateError> Errors { get; set; } = new();
}

public class BulkCreateError
{
    public int Index { get; set; }
    public string CompanyName { get; set; } = string.Empty;
    public List<string> Errors { get; set; } = new();
}


public class CreateCompaniesBulkHandler : ICreateCompanyBulkHandler
{
    private readonly ICompanyRepository _companyRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<CreateCompanyBulkCommand> _validator;
    private readonly IValidator<CreateCompanyCommand> _individualValidator;

    public CreateCompaniesBulkHandler(
        ICompanyRepository companyRepository,
        IUnitOfWork unitOfWork,
        IValidator<CreateCompanyBulkCommand> validator,
        IValidator<CreateCompanyCommand> individualValidator)
    {
        _companyRepository = companyRepository;
        _unitOfWork = unitOfWork;
        _validator = validator;
        _individualValidator = individualValidator;
    }

    private CreateCompaniesBulkHandler() { }


    public async Task<Result<BulkCreateResult>> HandleAsync(CreateCompanyBulkCommand command)
    {
        var validationResult = await _validator.ValidateAsync(command);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToArray();
            return Result<BulkCreateResult>.ValidationError(string.Join(", ", errors));
        }

        var bulkResult = new BulkCreateResult();
        bulkResult.SuccessCount = 0;
        bulkResult.FailureCount = 0;

        return Result<BulkCreateResult>.Success(bulkResult);

    }
}
