using SharedKernel;

namespace AccountService.Domain.Entities;

public class Account: BaseEntity
{

    public string Owner { get; private set; }
    public decimal Balance { get; private set; }

    public Account()
    {
            
    }
    public Account(string owner, decimal initialBalance)
    {
        Id = Guid.NewGuid();
        Owner = owner;
        Balance = initialBalance;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0) throw new ArgumentException("Invalid amount");
        Balance += amount;
    }
}