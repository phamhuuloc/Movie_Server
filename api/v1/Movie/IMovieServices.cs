using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Movie_Server.Helper;
using Movie_Server.Models;


namespace Movie_Server.Services {
    public  interface IMovieServices {
        Task<ApiResponse> createNewMovie(MovieCreateModel movie); 
    }
}