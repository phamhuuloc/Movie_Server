using AutoMapper;
using Movie_Server.Models;
using Movie_Server.Database;
namespace Movie_Server.Helper {
    public class AutoMapperHandler : Profile {
       public AutoMapperHandler () {
        CreateMap<User, UserModel>() ;
        CreateMap<UserCreateModel, User>()
            .ForMember(
                dest => dest.Username, 
                opt => opt.MapFrom(src => src.Username)
            ).ForMember(
                dest => dest.Email, 
                opt => opt.MapFrom(src => src.Email)
            ).ForMember(
                dest => dest.Password,
                opt => opt.MapFrom(src => src.Password)
            ).ForMember(
                dest => dest.WalletBalance,
                opt => opt.MapFrom(src => src.WalletBalance)
            ).ForMember(
                dest => dest.Phone,
                opt => opt.MapFrom(src => src.Phone)
            ).ForMember(
                dest => dest.IsAdmin,
                opt => opt.MapFrom(src => src.IsAdmin)
            );
        CreateMap<UserUpdateModel, User>()
            .ForMember(
                dest => dest.Username, 
                opt => opt.MapFrom(src => src.Username)
            ).ForMember(
                dest => dest.Password, 
                opt => opt.MapFrom(src => src.Password)
            ).ForMember(
                dest => dest.ProfilePic,
                opt => opt.MapFrom(src => src.ProfilePic)
            ).ForMember(
                dest => dest.WalletBalance,
                opt => opt.MapFrom(src => src.WalletBalance)
            ).ForMember(
                dest => dest.Phone,
                opt => opt.MapFrom(src => src.Phone)
            ).ForMember(
                dest => dest.IsAdmin,
                opt => opt.MapFrom(src => src.IsAdmin)
            );
       }
    }
}