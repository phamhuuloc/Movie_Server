using AutoMapper;
using Movie_Server.Models;
using Movie_Server.Repos;
namespace Movie_Server.Helper {
    public class AutoMapperHandler : Profile {
       public AutoMapperHandler () {
           CreateMap<User, UserModel> ();
       }
    }
}