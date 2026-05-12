using AccountService.Domain.Entities;
using AccountService.Application.Interfaces;

namespace AccountService.Application.Features.Accounts
{
    public class CreateAccountHandler
    {
        private readonly IAccountRepository _repository;

        public CreateAccountHandler(IAccountRepository repository)
        {
            _repository = repository;
        }

        public async Task<Account> Handle(CreateAccountCommand command)
        {
            var account = new Account(command.Owner, command.InitialBalance);

            await _repository.AddAsync(account);

            return account;
        }
    }
}