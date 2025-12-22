using Contactum.Application.Features.Companies;
using Contactum.Application.Interfaces.Features.Companies;
using Microsoft.AspNetCore.Mvc;

namespace Contactum.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICreateCompanyHandler _createCompanyHandler;

        public CompanyController(ICreateCompanyHandler createCompanyHandler)
        {
            _createCompanyHandler = createCompanyHandler;
        }

        [HttpPost("createCompany/")]
        public async Task<IActionResult> CreateCompany([FromBody] CreateCompanyCommand command)
        {
            var result = await _createCompanyHandler.HandleAsync(command);
            return result.IsSuccess ? CreatedAtAction(nameof(CreateCompany), new { id = result.Value }, null) : BadRequest(result.Error);
        }
    }
}