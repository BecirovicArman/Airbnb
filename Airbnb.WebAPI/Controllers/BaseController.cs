using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Airbnb.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public abstract class BaseController(ISender sender) : ControllerBase
{
    protected readonly ISender _sender = sender;
}