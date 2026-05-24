using AccountService.Application.Features.Accounts;
using AccountService.Application.Interfaces;
using AccountService.Infrastructure.Persistence;
using AccountService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AccountDbContext>(options =>
{
    options.UseSqlServer(connectionString, sql =>
    {
        sql.EnableRetryOnFailure(
            maxRetryCount: 5,
            maxRetryDelay: TimeSpan.FromSeconds(5),
            errorNumbersToAdd: null);
    });
});

builder.Services.AddScoped<IAccountRepository, AccountRepository>();
var customerServiceUrl =
    builder.Configuration["Services:CustomerService"];

builder.Services.AddHttpClient<
    ICustomerServiceClient,
    CustomerServiceClient>(client =>
    {
        client.BaseAddress = new Uri(customerServiceUrl!);
    }).AddStandardResilienceHandler(options =>
    {
        options.Retry.MaxRetryAttempts = 3;
        options.CircuitBreaker.FailureRatio = 0.5;
        options.TotalRequestTimeout.Timeout =
            TimeSpan.FromSeconds(10);
    });


builder.Services.AddScoped<CreateAccountHandler>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider
        .GetRequiredService<AccountDbContext>();
    db.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();