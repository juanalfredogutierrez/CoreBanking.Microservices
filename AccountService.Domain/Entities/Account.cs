using SharedKernel;

namespace AccountService.Domain.Entities;

public class Account : BaseEntity
{
    public decimal Balance { get; private set; }
    public Guid CustomerId { get; private set; }
    public Account()
    {

    }
    public Account(Guid customerId ,decimal initialBalance)
    {
        Id = Guid.NewGuid();
        Balance = initialBalance;
        CustomerId = customerId;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0) throw new ArgumentException("Invalid amount");
        Balance += amount;
    }
}