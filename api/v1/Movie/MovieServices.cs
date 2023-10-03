using Movie_Server.Database.Models;
using AutoMapper;
using Movie_Server.Database;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Movie_Server.Helper;
using Movie_Server.Models;
using Movie_Server.Services;
using System.Runtime.CompilerServices;

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
        public async Task<ApiResponse> createNewMovie (MovieModel movie) {
            _logger.LogInformation("Create Movie Starting");
            ApiResponse _response = new ApiResponse();
            try {
                Movie _movie = _mapper.Map<MovieModel, Movie>(movie);
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
        public async Task<ApiResponse> updateMovieInfo (MovieModel movie, string id) {
            ApiResponse _response = new ApiResponse();
            _logger.LogInformation("Update Movie Starting");

            try {
                var _movie = await this._context.Movies.FindAsync(id);
                if(_movie == null){
                    _response.responseCode = 404;
                    _response.responseMessage = "Movie not found";
                    return _response;
                }
                else if(_movie != null){
                   _movie.SupplierId = movie.SupplierId; 
                   _movie.Title = movie.Title;
                   _movie.Desc = movie.Desc;
                   _movie.Img = movie.Img;
                   _movie.ImgSm = movie.ImgSm;
                   _movie.Trailer = movie.Trailer;
                   _movie.Video = movie.Video;
                   _movie.Year = movie.Year;
                   _movie.Limit = movie.Limit;
                   _movie.Price = movie.Price;
                   await this._context.SaveChangesAsync();
                    _response.responseCode = 201;
                    _response.responseMessage = "Update Movie Successfully";
                    return(_response);
                }
                                
            }catch(Exception ex) {
                _response.responseCode = 500;
                _response.responseMessage = ex.Message;
            }
            return _response;
            
        }
    }
}