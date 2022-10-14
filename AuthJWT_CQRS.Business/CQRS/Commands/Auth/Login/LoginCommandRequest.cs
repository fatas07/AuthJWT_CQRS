using AuthJWT_CQRS.Business.CQRS.Models.Base;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace AuthJWT_CQRS.Business.CQRS.Commands.Auth.Login
{
    public class LoginCommandRequest : IRequest<ResponseModel>
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
