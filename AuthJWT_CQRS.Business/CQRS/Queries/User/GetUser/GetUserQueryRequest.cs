using AuthJWT_CQRS.Business.CQRS.Models.Base;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace AuthJWT_CQRS.Business.CQRS.Queries.User.GetUser
{
    public class GetUserQueryRequest : IRequest<ResponseModel>
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
