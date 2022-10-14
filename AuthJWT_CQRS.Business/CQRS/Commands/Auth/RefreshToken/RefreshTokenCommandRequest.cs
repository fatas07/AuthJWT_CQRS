using AuthJWT_CQRS.Business.CQRS.Models.Base;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace AuthJWT_CQRS.Business.CQRS.Commands.Auth.RefreshToken
{
    public class RefreshTokenCommandRequest : IRequest<ResponseModel>
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        public string RefreshToken { get; set; }
    }
}
