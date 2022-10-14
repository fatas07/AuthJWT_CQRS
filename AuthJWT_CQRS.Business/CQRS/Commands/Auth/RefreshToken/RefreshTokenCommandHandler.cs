using AuthJWT_CQRS.Business.CQRS.Models.Base;
using AuthJWT_CQRS.Business.CQRS.Models.User;
using AuthJWT_CQRS.Business.Helpers;
using AuthJWT_CQRS.Business.Services.Token;
using AuthJWT_CQRS.Data.Repositories.User;
using AutoMapper;
using MediatR;

namespace AuthJWT_CQRS.Business.CQRS.Commands.Auth.RefreshToken
{
    public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommandRequest, ResponseModel>
    {
        private readonly IUserRepo userRepo;
        private readonly IMapper mapper;
        private readonly ITokenService tokenService;

        public RefreshTokenCommandHandler(IUserRepo _userRepo, IMapper _mapper, ITokenService _tokenService)
        {
            userRepo = _userRepo;
            mapper = _mapper;
            this.tokenService = _tokenService;
        }
        public async Task<ResponseModel> Handle(RefreshTokenCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await userRepo.GetUserByEmail(request.Email);
            if (user == null)
            {
                return new ResponseModelError
                {
                    Error = ErrorHandlerHelper.USER_NOT_FOUND
                };
            }

            if (user.RefreshToken != request.RefreshToken || DateTime.UtcNow > user.RefreshTokenEndDate)
            {
                return new ResponseModelError
                {
                    Error = ErrorHandlerHelper.REFRESH_TOKEN_EXPIRED
                };
            }
            var loginResponseModel = new RefreshTokenCommandResponse()
            {
                User = mapper.Map<UserModel>(user),
                Token = tokenService.CreateToken(user, await userRepo.GetUserRoles(user))
            };

            user.RefreshToken = loginResponseModel.Token.RefreshToken;
            user.RefreshTokenEndDate = loginResponseModel.Token.Expiration.AddHours(12); // Added 12 hours to access token exp.
            await userRepo.UpdateUser(user);

            return new ResponseModelOk<RefreshTokenCommandResponse>() { payload = loginResponseModel };
        }
    }
}
