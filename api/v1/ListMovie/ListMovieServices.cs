using AutoMapper;
using AutoMapper.Configuration.Annotations;
using Microsoft.EntityFrameworkCore;
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
        public async Task<ApiResponse> getAllListMovie (){
            ApiResponse _response = new ApiResponse();
            try{
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
        
    }
}