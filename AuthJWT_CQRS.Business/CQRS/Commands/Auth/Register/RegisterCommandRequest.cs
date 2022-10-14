using AuthJWT_CQRS.Business.CQRS.Models.Base;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace AuthJWT_CQRS.Business.CQRS.Commands.Auth.Register
{
    public class RegisterCommandRequest : IRequest<ResponseModel>
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
