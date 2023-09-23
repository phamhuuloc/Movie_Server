
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Movie_Server.Models;
using Movie_Server.Repos;
using Movie_Server.Services;

namespace Movie_Server.Container {
    public class UserServices : IUserServices{
        private readonly   MovieserverContext _context;
        private readonly Mapper _mapper;
        public   UserServices (MovieserverContext context , IMapper mapper) {
            this._context = context;
            this._mapper = (Mapper?)mapper;
        }
        // get all user
        public async Task<List<UserModel>>getAllUsers()
        {
            List<UserModel>  _response = new List<UserModel>();
            var data =  await this._context.Users.ToListAsync();
            if(data != null){
                _response = _mapper.Map<List<User>, List<UserModel>>(data);
            }
            return _response;
        }
        // get  user by id
        public async Task<UserModel> getUserById(int id)
        {
            UserModel _response = new UserModel();
            var data =  await this._context.Users.FindAsync(id);
            if(data != null){
                _response = _mapper.Map<User, UserModel>(data);
            }
            return _response;

        }
    }
}