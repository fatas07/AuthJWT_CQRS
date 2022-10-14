using AuthJWT_CQRS.Business.CQRS.Queries.User.GetUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthJWT_CQRS.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : Controller
    {
        private readonly IMediator mediator;

        public UserController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        public IActionResult Index()
        {
            return Ok("Hello World");
        }

        //[Authorize(Roles = "User")]
        [HttpGet("{email}")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var response = await mediator.Send(new GetUserQueryRequest() { Email = email });
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}
