namespace AccountService.Application.Features.Accounts
{
    public record CreateAccountCommand(string Owner, decimal InitialBalance);
}
