using Movie_Server.Database.Models;
using AutoMapper;
using Movie_Server.Database;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Movie_Server.Helper;
using Movie_Server.Models;
using Movie_Server.Services;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;

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

        public async  Task<ApiResponse> getAllMovies () {
            ApiResponse _response = new ApiResponse();
            try{
               _logger.LogInformation("Get All Movies Starting");
               var data = await this._context.Movies.ToListAsync();
               if( data != null) {
                    _response.responseCode = 200;
                    _response.responseMessage  = "Get All Movies Successfully";
                    _response.data = _mapper.Map<List<Movie> , List<MovieModel>>(data);
                    return _response;
               }
            }catch(Exception ex) {
                _response.responseCode = 500;
                _response.responseMessage = ex.Message;
            }
            return _response;
            
        }
        public async Task<ApiResponse> getMovieById (string id) {
            ApiResponse _response = new ApiResponse();
            try{
            _logger.LogInformation("Get Movie By ID Starting");
            var data = await this._context.Movies.FindAsync(id);
            MovieModel movieInfo = _mapper.Map<MovieModel>(data);
            if(movieInfo == null){
                _response.responseCode = 404;
                _response.responseMessage = "Movie Not Found";
                return _response;
            }else{

            
           // get rating content of user for movie 
            var getRatings= from rating in _context.Ratings
                        join user in _context.Users on rating.RUserId equals user.Id
                        where rating.RMovieId  == id // Điều kiện join bảng
                       select new {
                            userProfilePic = user.ProfilePic,
                            userName = user.Username,
                            ratingStar = rating.RNumberStar,
                            ratingContent = rating.RContent,
                            ratingTime = rating.CreateAt
                       };
            // get atribute of movie
            var getAttributeOfMovie =  from  _movieCategories  in _context.MovieCategories
                                       join categories in _context.Categories on _movieCategories.MvCateId equals categories.Id
                                       where _movieCategories.MvMovieId == id
                                       select new {
                                           categoriesName = categories.CateName,
                                           isActive = categories.IsActive
                                       };
            // Execute query to get information
            var ratingsOfMovie = await getRatings.ToListAsync();
            var atributeOfMovie = await getAttributeOfMovie.ToListAsync();

            _response.responseCode = 200;
            _response.responseMessage = "Get Movie By ID Successfully";
            _response.data = new {movieInfo, moveAtribute = atributeOfMovie,ratings = ratingsOfMovie}; // Trả về thông tin phim từ thuộc tính Movie trong kết quả
            return _response;
           }     
            }catch(Exception ex){
                _response.responseCode = 500;
                _response.responseMessage = "Get Movie By ID Failed";

            }
            return _response; //TODO: Add result

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