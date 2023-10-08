using Movie_Server.Helper;
using Movie_Server.Models;
namespace Movie_Server.Services {
    public interface IListMovieServices {
        Task<ApiResponse> createNewListMovie(ListMovieCreateModel listMovie);
        Task<ApiResponse> addMovieIntoList(MovieListModel movieListModel);
        Task<ApiResponse> updateListMovie(ListMovieCreateModel listMovie,string id);
        Task<ApiResponse> deleteListMovie(string id);
        Task<ApiResponse> getAllListMovie();
        Task<ApiResponse> getListMovieById(string id);

    }
}