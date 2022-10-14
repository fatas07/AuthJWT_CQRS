using AuthJWT_CQRS.Business.CQRS.Commands.Auth.Register;
using AuthJWT_CQRS.Business.CQRS.Models.User;
using AuthJWT_CQRS.Business.CQRS.Queries.User.GetUser;
using AuthJWT_CQRS.Entities.Identity;
using AutoMapper;

namespace AuthJWT_CQRS.Business.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserEntity, GetUserQueryResponse>().ReverseMap();
            CreateMap<UserEntity, UserModel>().ReverseMap();
            CreateMap<UserEntity, RegisterCommandRequest>().ReverseMap();
        }
    }
}
