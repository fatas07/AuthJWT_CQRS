using AuthJWT_CQRS.Api.Filters;
using AuthJWT_CQRS.Business.CQRS.Commands.Auth.Login;
using AuthJWT_CQRS.Business.CQRS.Commands.Auth.RefreshToken;
using AuthJWT_CQRS.Business.CQRS.Commands.Auth.Register;
using AuthJWT_CQRS.Business.CQRS.Queries.User.GetUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AuthJWT_CQRS.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IMediator mediator;

        public AuthController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        [ModelStateValidFilter]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginCommandRequest request)
        {
            var response = await mediator.Send(request);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [ModelStateValidFilter]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterCommandRequest request)
        {
            var response = await mediator.Send(request);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [ModelStateValidFilter]
        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenCommandRequest request)
        {
            var response = await mediator.Send(request);
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}
