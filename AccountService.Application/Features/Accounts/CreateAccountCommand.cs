namespace AccountService.Application.Features.Accounts
{
    public record CreateAccountCommand(Guid CustomerId, decimal InitialBalance);
}
