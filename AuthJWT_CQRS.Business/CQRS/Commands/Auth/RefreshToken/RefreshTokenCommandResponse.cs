using AuthJWT_CQRS.Business.CQRS.Models.Token;
using AuthJWT_CQRS.Business.CQRS.Models.User;

namespace AuthJWT_CQRS.Business.CQRS.Commands.Auth.RefreshToken
{
    public class RefreshTokenCommandResponse
    {
        public TokenModel Token { get; set; }
        public UserModel User { get; set; }
    }
}
