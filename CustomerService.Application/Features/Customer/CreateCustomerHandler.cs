using CustomerService.Application.Features.Customer;
using CustomerService.Application.Intefaces;
using CustomerService.Domain.Entities;

public class CreateCustomerHandler
{
    private readonly ICustomerRepository _repository;

    public CreateCustomerHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Customer> Handle(CreateCustomerCommand command)
    {
        var customer = new Customer(command.Name, command.Email);

        await _repository.AddAsync(customer);

        return customer;
    }
}