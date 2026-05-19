using AccountService.Application.Features.Accounts;
using AccountService.Application.Interfaces;
using AccountService.Infrastructure.Persistence;
using AccountService.Infrastructure.Repositories;


using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AccountDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

builder.Services.AddScoped<IAccountRepository, AccountRepository>();

builder.Services.AddHttpClient<ICustomerServiceClient, CustomerServiceClient>(client =>
{
    client.BaseAddress = new Uri("http://customerservice:8080");
}).AddStandardResilienceHandler(options =>
{
    options.Retry.MaxRetryAttempts = 3;

    options.CircuitBreaker.FailureRatio = 0.5;

    options.TotalRequestTimeout.Timeout = TimeSpan.FromSeconds(10);
});


builder.Services.AddScoped<CreateAccountHandler>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

var app = builder.Build();

// Swagger middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();