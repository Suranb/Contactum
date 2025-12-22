using System;
using Contactum.Application.Interfaces;
using Contactum.Application.Interfaces.Repositories;
using Contactum.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Contactum.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ContactumDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IUnitOfWork, Infrastructure.UnitOfWork.UnitOfWork>();

        services.AddScoped<ICompanyRepository, CompanyRepository>();

        return services;
    }
}
