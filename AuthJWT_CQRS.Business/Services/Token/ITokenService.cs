using AuthJWT_CQRS.Business.CQRS.Models.Token;
using AuthJWT_CQRS.Entities.Identity;

namespace AuthJWT_CQRS.Business.Services.Token
{
    public interface ITokenService
    {
        TokenModel CreateToken(UserEntity user, IList<string> userRoles);
    }
}
