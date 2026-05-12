using CustomerService.Domain.Entities;

namespace CustomerService.Application.Interfaces
{
    public interface ICustomerRepository
    {
        Task AddAsync(Customer customer);
        Task<bool> ExistsAsync(Guid customerId);

    }
}
