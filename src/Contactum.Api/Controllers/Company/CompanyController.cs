using Contactum.Api.Controllers.BaseController;
using Contactum.Application.Features.Companies;
using Contactum.Application.Interfaces.Features.Companies;
using Microsoft.AspNetCore.Mvc;

namespace Contactum.Api.Controllers.Company
{
    [Route("api/companies")]
    [ApiController]
    public class CompanyController : BaseApiController
    {
        private readonly IGetCompanyByIdHandler _getCompanyByIdHandler;
        private readonly ICreateCompanyHandler _createCompanyHandler;

        public CompanyController(
            IGetCompanyByIdHandler getCompanyByIdHandler,
            ICreateCompanyHandler createCompanyHandler)
        {
            _getCompanyByIdHandler = getCompanyByIdHandler;
            _createCompanyHandler = createCompanyHandler;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompanyById(int id)
        {
            var result = await _getCompanyByIdHandler.HandleAsync(id);
            return HandleResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCompanyCommand command)
        {
            var result = await _createCompanyHandler.HandleAsync(command);
            return HandleResult(result);
        }
    }
}
