using System;
using Contactum.Application.Results;
using Contactum.Domain.Models;

namespace Contactum.Application.Interfaces.Features.Companies;

public interface IGetCompanyByIdHandler
{
    Task<Result<Company>> HandleAsync(int id);
}
