using Airbnb.Application.Users.Register;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Airbnb.WebAPI.Controllers.Users;

public sealed class UsersController(ISender sender) : BaseController(sender)
{
    [HttpPost]
    public async Task<Guid> Create([FromBody] RegisterCommand createUser, CancellationToken cancellationToken) =>
        await _sender.Send(createUser, cancellationToken);
}