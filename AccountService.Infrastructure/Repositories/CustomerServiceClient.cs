using AccountService.Application.Interfaces;

namespace AccountService.Infrastructure.Repositories
{
    public class CustomerServiceClient : ICustomerServiceClient
    {
        private readonly HttpClient _http;

        public CustomerServiceClient(HttpClient http)
        {
            _http = http;
        }

        public async Task<bool> ExistsAsync(Guid customerId)
        {
            var response = await _http.GetAsync($"api/customers/{customerId}");
            return response.IsSuccessStatusCode;
        }
    }
}
