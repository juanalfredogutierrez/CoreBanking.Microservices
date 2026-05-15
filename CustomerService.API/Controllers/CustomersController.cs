using CustomerService.Application.Features.Customer;
using Microsoft.AspNetCore.Mvc;

namespace CustomerService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly CreateCustomerHandler _createHandler;
        private readonly GetCustomerByIdHandler _getHandler;


        public CustomersController(CreateCustomerHandler createHandler, GetCustomerByIdHandler getHandler)
        {
            _createHandler = createHandler;
            _getHandler = getHandler;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCustomerCommand command)
        {
            var result = await _createHandler.Handle(command);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return Ok(result.Value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var exists = await _getHandler.Handle(id);

            if (!exists)
                return NotFound();

            return Ok(exists);

        }
    }
}
