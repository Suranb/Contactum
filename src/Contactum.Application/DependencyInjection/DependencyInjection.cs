using Contactum.Application.Features.Companies;
using Contactum.Application.Interfaces.Features.Companies;
using Microsoft.Extensions.DependencyInjection;

namespace Contactum.Application.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Register all handlers
        services.AddScoped<IGetCompanyByIdHandler, GetCompanyByIdHandler>();
        services.AddScoped<ICreateCompanyHandler, CreateCompanyHandler>();

        return services;
    }
}