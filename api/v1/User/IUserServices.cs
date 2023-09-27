using Movie_Server.Helper;
using Movie_Server.Models;
using Movie_Server.Database;

namespace Movie_Server.Services {

    public interface IUserServices {
       Task< List<UserModel>> getAllUsers();
       Task<UserModel> getUserById(int id);
       Task<ApiResponse> createNewUser(UserCreateModel user);
       Task<ApiResponse> updateUser(UserUpdateModel user,string id);
    }
}