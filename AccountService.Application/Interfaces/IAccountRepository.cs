using AccountService.Domain.Entities;

namespace AccountService.Application.Interfaces
{
    public interface IAccountRepository
    {
        Task AddAsync(Account account);
    }
}
