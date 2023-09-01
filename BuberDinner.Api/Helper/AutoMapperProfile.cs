//using AutoMapper;
//using BuberDinner.Application.Services.Authentication.Common;
//using BuberDinner.Contracts.Authentication;

//namespace BuberDinner.Api.Helper
//{
//    public class AutoMapperProfile : Profile {
//        public AutoMapperProfile() {
//            CreateMap<AuthenticationResult, AuthenticationResponse>().ForMember(dist => dist.Id, opt => opt.MapFrom(src => src.User.Id))
//                .ForMember(dist => dist.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
//                .ForMember(dist => dist.LastName, opt => opt.MapFrom(src => src.User.LastName))
//                .ForMember(dist => dist.Email, opt => opt.MapFrom(src => src.User.Email)).ReverseMap();
//        }
//    }
//}
