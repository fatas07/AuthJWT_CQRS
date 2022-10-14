using AuthJWT_CQRS.Business.CQRS.Models.Base;
using AuthJWT_CQRS.Business.CQRS.Models.User;
using AuthJWT_CQRS.Business.Helpers;
using AuthJWT_CQRS.Business.Services.Token;
using AuthJWT_CQRS.Data.Repositories.User;
using AutoMapper;
using MediatR;

namespace AuthJWT_CQRS.Business.CQRS.Commands.Auth.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommandRequest, ResponseModel>
    {
        private readonly IUserRepo userRepo;
        private readonly IMapper mapper;
        private readonly ITokenService tokenService;

        public LoginCommandHandler(IUserRepo _userRepo, IMapper _mapper, ITokenService _tokenService)
        {
            userRepo = _userRepo;
            mapper = _mapper;
            tokenService = _tokenService;
        }


        public async Task<ResponseModel> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await userRepo.GetUserByEmail(request.Email);
            if (user == null || !await userRepo.CheckUserPassword(user, request.Password))
            {
                return new ResponseModelError { Error = ErrorHandlerHelper.INVALID_USER };
            }

            var loginQueryResponse = new LoginCommandResponse()
            {
                User = mapper.Map<UserModel>(user),
                Token = tokenService.CreateToken(user, await userRepo.GetUserRoles(user))
            };

            user.RefreshToken = loginQueryResponse.Token.RefreshToken;
            user.RefreshTokenEndDate = loginQueryResponse.Token.Expiration.AddHours(12); // Added 12 hours to access token exp.
            await userRepo.UpdateUser(user);

            return new ResponseModelOk<LoginCommandResponse>() { payload = loginQueryResponse };
        }
    }
}
