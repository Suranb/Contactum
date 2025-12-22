using Contactum.Application.Features.Companies;
using Contactum.Application.Interfaces.Features.Companies;
using Contactum.Application.Results;
using Microsoft.AspNetCore.Mvc;

namespace Contactum.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICreateCompanyHandler _createCompanyHandler;
        private readonly IGetCompanyByIdHandler _getCompanyByIdHandler;

        public CompanyController(
            IGetCompanyByIdHandler getCompanyByIdHandler,
            ICreateCompanyHandler createCompanyHandler)
        {
            _getCompanyByIdHandler = getCompanyByIdHandler;
            _createCompanyHandler = createCompanyHandler;
        }

        [HttpGet("/{id}")]
        public async Task<IActionResult> GetCompanyById(int id)
        {
            var result = await _getCompanyByIdHandler.HandleAsync(id);

            if (result.IsSuccess)
                return Ok(result.Value);

            return result.ErrorType switch
            {
                ErrorType.NotFound => NotFound(new { error = result.Error }),
                ErrorType.Validation => BadRequest(new { error = result.Error }),
                ErrorType.Unauthorized => Unauthorized(new { error = result.Error }),
                ErrorType.Forbidden => Forbid(),
                _ => StatusCode(500, new { error = "An unexpected error occurred" })
            };
        }

        [HttpPost("createCompany/")]
        public async Task<IActionResult> CreateCompany([FromBody] CreateCompanyCommand command)
        {
            var result = await _createCompanyHandler.HandleAsync(command);
            return result.IsSuccess ? CreatedAtAction(nameof(CreateCompany), new { id = result.Value }, null) : BadRequest(result.Error);
        }
    }
}