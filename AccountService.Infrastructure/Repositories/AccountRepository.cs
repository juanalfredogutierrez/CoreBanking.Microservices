using AccountService.Domain.Entities;
using AccountService.Application.Interfaces;
using AccountService.Infrastructure.Persistence;

namespace AccountService.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AccountDbContext _context;

        public AccountRepository(AccountDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Account account)
        {
            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();
        }
    }
}