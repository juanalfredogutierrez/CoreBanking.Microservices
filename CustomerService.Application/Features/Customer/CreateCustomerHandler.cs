using CustomerService.Application.DTOs;
using CustomerService.Application.Interfaces;
using SharedKernel.Result;
namespace CustomerService.Application.Features.Customer
{
    public class CreateCustomerHandler
    {
        private readonly ICustomerRepository _repository;

        public CreateCustomerHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<CustomerDto>> Handle(CreateCustomerCommand command)
        {
            var customer = new Domain.Entities.Customer(command.Name, command.Email);

            await _repository.AddAsync(customer);

            var customerDto = new CustomerDto
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email
            };

            return Result<CustomerDto>.Success(customerDto);
        }
    }

}