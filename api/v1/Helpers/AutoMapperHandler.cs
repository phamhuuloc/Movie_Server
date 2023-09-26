using AutoMapper;
using Movie_Server.Models;
using Movie_Server.Database;
namespace Movie_Server.Helper {
    public class AutoMapperHandler : Profile {
       public AutoMapperHandler () {
        CreateMap<UserModel, User>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
 
        CreateMap<User, UserModel>() ;
       }
    }
}