
using CustomerService.Application.Interfaces;

namespace CustomerService.Application.Features.Customer
{
    public class GetCustomerByIdHandler
    {
        private readonly ICustomerRepository _repository;

        public GetCustomerByIdHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(Guid id)
        {
            return await _repository.ExistsAsync(id);
        }
    }
}