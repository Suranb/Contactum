using Contactum.Application.Features.Companies;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Contactum.Application.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Register all handlers
        services.AddScoped<IGetCompanyByIdHandler, GetCompanyByIdHandler>();
        services.AddScoped<ICreateCompanyHandler, CreateCompanyHandler>();
        services.AddScoped<IGetAllCompaniesHandler, GetAllCompaniesHandler>();

        services.AddValidatorsFromAssemblyContaining<CreateCompanyCommandValidator>();
        
        return services;
    }
}