using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Movie_Server.Helper;
using Movie_Server.Models;


namespace Movie_Server.Services {
    public  interface IMovieServices {
        Task<ApiResponse> createNewMovie(MovieModel movie); 
        Task<ApiResponse> updateMovieInfo(MovieModel movie,string id); 
    }
}