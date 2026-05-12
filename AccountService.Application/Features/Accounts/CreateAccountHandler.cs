using AccountService.Domain.Entities;
using AccountService.Application.Interfaces;

namespace AccountService.Application.Features.Accounts
{
    public class CreateAccountHandler
    {
        private readonly IAccountRepository _repository;
        private readonly ICustomerServiceClient _customerClient;
        public CreateAccountHandler(IAccountRepository repository, ICustomerServiceClient customerClient)
        {
            _repository = repository;
            _customerClient = customerClient;   
        }

        public async Task<Account> Handle(CreateAccountCommand command)
        {
          
            var exists = await _customerClient.ExistsAsync(command.CustomerId);

            if (!exists)
                throw new Exception("Customer does not exist");

            var account = new Account(command.CustomerId, command.InitialBalance);

            await _repository.AddAsync(account);

            return account;
        }
    }
}