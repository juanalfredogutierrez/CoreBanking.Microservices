using CustomerService.Application.Features.Customer;
using Microsoft.AspNetCore.Mvc;

namespace CustomerService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly CreateCustomerHandler _handler;

        public CustomersController(CreateCustomerHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCustomerCommand command)
        {
            var customer = await _handler.Handle(command);
            return Ok(customer);
        }
    }
}
