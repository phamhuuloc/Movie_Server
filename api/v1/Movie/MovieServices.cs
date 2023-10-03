using Movie_Server.Database.Models;
using AutoMapper;
using Movie_Server.Database;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Movie_Server.Helper;
using Movie_Server.Models;
using Movie_Server.Services;

namespace Movie_Server.Container {
    public  class MovieServices : IMovieServices {
        private readonly MovieserverContext _context;
        private readonly Mapper _mapper;
        private readonly ILogger<MovieServices> _logger;
        public MovieServices(MovieserverContext context, IMapper mapper, ILogger<MovieServices> logger) {
            this._context = context;
            this._mapper = (Mapper?)mapper;
            this._logger = logger;
        }   
        public async Task<ApiResponse> createNewMovie (MovieCreateModel movie) {
            _logger.LogInformation("Create Movie Starting");
            ApiResponse _response = new ApiResponse();
            try {
                Movie _movie = _mapper.Map<MovieCreateModel, Movie>(movie);
                _movie.Id = Guid.NewGuid().ToString();
                await this._context.Movies.AddAsync(_movie);
                await this._context.SaveChangesAsync();
                _response.responseCode = 201;
                _response.responseMessage = "Create Movie Successfully";
                return(_response);
            }catch (ArgumentException ex){
                _response.responseCode = 500;
                _response.responseMessage = ex.Message;
            }
            return _response;
        }
    }
}