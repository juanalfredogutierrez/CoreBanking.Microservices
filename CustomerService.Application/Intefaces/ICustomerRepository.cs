using CustomerService.Domain.Entities;

namespace CustomerService.Application.Intefaces
{
    public interface ICustomerRepository
    {
        Task AddAsync(Customer customer);
    }
}
