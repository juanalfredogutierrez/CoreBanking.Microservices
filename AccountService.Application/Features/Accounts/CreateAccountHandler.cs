using AccountService.Domain.Entities;
using AccountService.Application.Interfaces;
using SharedKernel.Result;

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

        public async Task<Result<Account>> Handle(CreateAccountCommand command)
        {
          
            var exists = await _customerClient.ExistsAsync(command.CustomerId);

            if (!exists)
                return Result<Account>.Failure("Cliente no existe.");

            var account = new Account(command.CustomerId, command.InitialBalance);

            await _repository.AddAsync(account);

            return Result<Account>.Success(account);
        }
    }
}