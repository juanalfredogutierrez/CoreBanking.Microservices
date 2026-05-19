using Microsoft.AspNetCore.Mvc;
using AccountService.Application.Features.Accounts;

namespace AccountService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountsController : ControllerBase
{
    private readonly CreateAccountHandler _handler;

    public AccountsController(CreateAccountHandler handler)
    {
        _handler = handler;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateAccountCommand command)
    {
        var result = await _handler.Handle(command);

        if (result.IsFailure)
            return BadRequest(result);

        return Ok(result);
    }
}