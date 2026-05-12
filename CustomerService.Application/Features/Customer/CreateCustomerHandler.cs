using CustomerService.Application.Interfaces;
namespace CustomerService.Application.Features.Customer
{
    public class CreateCustomerHandler
    {
        private readonly ICustomerRepository _repository;

        public CreateCustomerHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<Domain.Entities.Customer> Handle(CreateCustomerCommand command)
        {
            var customer = new Domain.Entities.Customer(command.Name, command.Email);

            await _repository.AddAsync(customer);

            return customer;
        }
    }

}