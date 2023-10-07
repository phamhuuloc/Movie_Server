using AutoMapper;
using AutoMapper.Configuration.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Movie_Server.Database.Models;
using Movie_Server.Helper;
using Movie_Server.Models;
using Movie_Server.Services;

namespace Movie_Server.Container {
    public class ListMovieServices : IListMovieServices {
        private readonly MovieserverContext _context ;
        private readonly Mapper _mapper;
        private ILogger<ListMovieServices> _logger;

        public ListMovieServices (MovieserverContext context , IMapper mapper, ILogger<ListMovieServices> logger) {
            this._context = context;
            this._mapper = (Mapper?)mapper;
            this._logger = logger;
        }

        public async  Task<ApiResponse>  createNewListMovie(ListMovieCreateModel listMovie) {
            ApiResponse _response = new ApiResponse(); 
            try {
                List _list = this._mapper.Map<ListMovieCreateModel,List>(listMovie);
                _list.Id = Guid.NewGuid().ToString();
                await this._context.AddAsync(_list);
                await this._context.SaveChangesAsync();
                _response.responseCode = 201;
                _response.responseMessage = "Create New List Movie Successfully";
                _response.data = null;
                return _response;
            }catch(Exception ex) {
                _logger.LogError(ex.Message, "Create New List Movie Failed");
                _response.responseCode = 500;
                _response.responseMessage = "Create New List Movie Failed";
            }
            return _response;
        }
        public async  Task<ApiResponse> updateListMovie(ListMovieCreateModel listMovie, string id) {
            ApiResponse _response = new ApiResponse(); 
            try {
                var _list = await this._context.Lists.FirstOrDefaultAsync(l => l.Id == id);
                if(_list == null) {
                    _response.responseCode = 404;
                    _response.responseMessage = "List Movie Not Found";
                    return _response;
                }
                else {
                    _mapper.Map(listMovie , _list);
                     await this._context.SaveChangesAsync();
                    _response.responseCode = 200;
                    _response.responseMessage = "Update List Movie Successfully";
                    _response.data = null;
                    return _response;
                }
            


            }
            catch (Exception ex) {
                 _logger.LogError(ex.Message , "Update List Movie Failed");
                 _response.responseCode = 500;
                 _response.responseMessage = "Update List Movie Failed";
            }
            return _response;
        }
        public async Task<ApiResponse> deleteListMovie (string id){
            ApiResponse  _response = new ApiResponse();
            try{
                var _listMovie = await this._context.Lists.FindAsync(id);
                if(_listMovie != null) {
                    this._context.Lists.Remove(_listMovie);
                    this._context.SaveChanges();
                    _response.responseCode = 200;
                    _response.responseMessage = "Delete List Movie Successfully";
                    _response.data = null;
                    return _response;

                }
            }catch(Exception ex) {
                _logger.LogError(ex.Message, "Delete List Movie Failed");
                _response.responseCode = 500;
                _response.responseMessage = "Delete List Movie Failed";
            }
            return _response;
            
        }
        public async Task<ApiResponse> getAllListMovie (){
            ApiResponse _response = new ApiResponse();
            try{
                _logger.LogInformation("Get All List Movie Starting");
                var data = await this._context.Lists.ToListAsync();
                if(data != null) {
                    _response.responseCode = 200;
                    _response.responseMessage = "Get All List Movie Successfully";
                    _response.data = _mapper.Map<List<List>, List<ListModel>>(data);
                    return _response;
                }
                
            }catch(Exception ex) {
                _logger.LogError(ex.Message, "Get All List Movie Failed");
                _response.responseCode = 500;
                _response.responseMessage = "Get All List Movie Failed";
            }
            return _response;
        }
        public async  Task<ApiResponse> getListMovieById (string id) {
            ApiResponse _response  = new ApiResponse();
            try {
                 // get list movie information by id
                 var _listMovie = await this._context.Lists.FindAsync(id);
                 if(_listMovie == null){
                    _response.responseCode = 404;
                    _response.responseMessage = "List Movie Not Found";
                    _response.data = null;
                    return _response;
                 }
                 // query string to get all movies  of list movie with id
                 var query = from lm  in _context.ListMovies
                            join movie  in _context.Movies on lm.LmMovieId equals movie.Id
                            where lm.LmListId == id
                            select new {
                                movieInfo = _mapper.Map<Movie, MovieInfoModel>(movie)
                            };
                var movies = await query.ToListAsync();
                var ListMovieInformation = new {ListMovieInformation =_listMovie,movies};
                _response.responseCode = 200;
                _response.responseMessage = "Get List Movie By Id Successfully";
                _response.data = ListMovieInformation;
                return _response;

            }catch(Exception ex) {
                _logger.LogError(ex.Message, "Get List Movie By Id Failed");
                _response.responseCode = 500;
                _response.responseMessage = ex.Message;
                // _response.responseMessage = "Get List Movie By Id Failed";
            }
            return _response;


        }
        
    }
}