using Movie_Server.Helper;
using Movie_Server.Models;
namespace Movie_Server.Services {
    public interface IListMovieServices {
        Task<ApiResponse> createNewListMovie(ListMovieCreateModel listMovie);
    }
}