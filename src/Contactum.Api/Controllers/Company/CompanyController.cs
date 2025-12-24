using Contactum.Api.Controllers.BaseController;
using Contactum.Application.Features.Companies;
using Microsoft.AspNetCore.Mvc;

namespace Contactum.Api.Controllers.Company
{
    [Route("api/companies")]
    [ApiController]
    public class CompanyController : BaseApiController
    {
        private readonly IGetCompanyByIdHandler _getCompanyByIdHandler;
        private readonly ICreateCompanyHandler _createCompanyHandler;
        private readonly IGetAllCompaniesHandler _getCompaniesHandler;

        public CompanyController(
            IGetCompanyByIdHandler getCompanyByIdHandler,
            ICreateCompanyHandler createCompanyHandler,
            IGetAllCompaniesHandler getAllCompaniesHandler)
        {
            _getCompanyByIdHandler = getCompanyByIdHandler;
            _createCompanyHandler = createCompanyHandler;
            _getCompaniesHandler = getAllCompaniesHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _getCompaniesHandler.HandleAsync();
            return HandleResult(result);
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
