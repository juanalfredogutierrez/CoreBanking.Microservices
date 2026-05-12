namespace AccountService.Application.Interfaces
{
    public interface ICustomerServiceClient
    {
        Task<bool> ExistsAsync(Guid customerId);
    }
}
