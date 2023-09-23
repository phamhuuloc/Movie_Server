using Movie_Server.Models;
using Movie_Server.Repos;

namespace Movie_Server.Services {

    public interface IUserServices {
       Task< List<UserModel>> getAllUsers();
    }
}