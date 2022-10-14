using AuthJWT_CQRS.Business.CQRS.Models.Base;
using AuthJWT_CQRS.Business.Helpers;
using AuthJWT_CQRS.Business.Services.Token;
using AuthJWT_CQRS.Data.Repositories.User;
using AuthJWT_CQRS.Entities.Identity;
using AutoMapper;
using MediatR;

namespace AuthJWT_CQRS.Business.CQRS.Commands.Auth.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommandRequest, ResponseModel>
    {
        private readonly IUserRepo userRepo;
        private readonly IMapper mapper;
        private readonly ITokenService tokenService;

        public RegisterCommandHandler(IUserRepo _userRepo, IMapper _mapper, ITokenService _tokenService)
        {
            userRepo = _userRepo;
            mapper = _mapper;
            tokenService = _tokenService;
        }

        public async Task<ResponseModel> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await userRepo.GetUserByEmail(request.Email);

            if (user != null)
            {
                return new ResponseModelError
                {
                    Error = ErrorHandlerHelper.USER_EXIST
                };
            }

            var userEntity = mapper.Map<UserEntity>(request);
            userEntity.Language = "en-US";
            userEntity.Timezone = TimeZoneInfo.Utc.Id;
            userEntity.SecurityStamp = Guid.NewGuid().ToString();

            var result = await userRepo.CreateUser(userEntity, request.Password);

            if (!result.Succeeded)
            {
                return new ResponseModelError
                {
                    Error = ErrorHandlerHelper.UNKNOWN_REGISTER_ERROR
                };
            }
            await userRepo.AddDefaultRoleToUser(userEntity);

            return new ResponseModelOk();
        }
    }
}
