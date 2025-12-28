using Contactum.Api.Controllers.BaseController;
using Contactum.Application.Features.Companies;
using Contactum.Application.Results;
using Microsoft.AspNetCore.Mvc;

namespace Contactum.Api.Controllers.Company
{
    [Route("api/companies")]
    [ApiController]
    public class CompanyController : BaseApiController
    {
        private readonly IGetCompanyByIdHandler _getCompanyByIdHandler;
        private readonly ICreateCompanyHandler _createCompanyHandler;
        private readonly IGetAllCompanyHandler _getCompaniesHandler;
        private readonly ICreateCompanyBulkHandler _createCompanyBulkHandler;

        public CompanyController(
            IGetCompanyByIdHandler getCompanyByIdHandler,
            ICreateCompanyHandler createCompanyHandler,
            IGetAllCompanyHandler getAllCompaniesHandler,
            ICreateCompanyBulkHandler createCompanyBulkHandler)
        {
            _getCompanyByIdHandler = getCompanyByIdHandler;
            _createCompanyHandler = createCompanyHandler;
            _getCompaniesHandler = getAllCompaniesHandler;
            _createCompanyBulkHandler = createCompanyBulkHandler;
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
            System.Console.WriteLine($"Creating company: {command.Name}");
            var result = await _createCompanyHandler.HandleAsync(command);
            return HandleResult(result);
        }

        [HttpPost("bulk")]
        public async Task<IActionResult> CreateBulk([FromBody] CreateCompanyBulkCommand command)
        {
            System.Console.WriteLine("Creating companiies..");
            var result = await _createCompanyBulkHandler.HandleAsync(command);
            return HandleResult(result);
        }
    }
}
