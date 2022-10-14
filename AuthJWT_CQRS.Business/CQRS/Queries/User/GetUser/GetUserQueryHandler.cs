using AuthJWT_CQRS.Business.CQRS.Models.Base;
using AuthJWT_CQRS.Business.Helpers;
using AuthJWT_CQRS.Data.Repositories.User;
using AutoMapper;
using MediatR;

namespace AuthJWT_CQRS.Business.CQRS.Queries.User.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQueryRequest, ResponseModel>
    {
        private readonly IUserRepo userRepo;
        private readonly IMapper mapper;

        public GetUserQueryHandler(IUserRepo _userRepo, IMapper _mapper)
        {
            userRepo = _userRepo;
            mapper = _mapper;
        }

        public async Task<ResponseModel> Handle(GetUserQueryRequest request, CancellationToken cancellationToken)
        {
            var user = await userRepo.GetUserByEmail(request.Email);
            if (user == null)
            {
                return new ResponseModelError { Error = ErrorHandlerHelper.USER_NOT_FOUND };
            }
            GetUserQueryResponse userModel = mapper.Map<GetUserQueryResponse>(user);
            return new ResponseModelOk<GetUserQueryResponse>() { payload = userModel };
        }
    }
}
