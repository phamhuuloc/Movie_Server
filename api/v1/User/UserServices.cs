
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Movie_Server.Helper;
using Movie_Server.Models;
using Movie_Server.Database;
using Movie_Server.Services;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Cors;

namespace Movie_Server.Container {
    public class UserServices : IUserServices{
        private readonly   MovieserverContext _context;
        private readonly Mapper _mapper;
        private readonly ILogger<UserServices> _logger;
        public   UserServices (MovieserverContext context , IMapper mapper, ILogger<UserServices> logger) {
            this._context = context;
            this._mapper = (Mapper?)mapper;
            this._logger = logger;
        }
        // get all user
        // [EnableCors("corsplicy1")]
        public async Task<List<UserModel>>getAllUsers()
        {
            _logger.LogInformation("Get All Users Starting");
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

            _logger.LogInformation("Get  Users  By ID Starting");
            UserModel _response = new UserModel();
            var data =  await this._context.Users.FindAsync(id);
            if(data != null){
                _response = _mapper.Map<User, UserModel>(data);
            }
            return _response;

        }
       // create a new user 
        public async Task<ApiResponse> createNewUser(UserCreateModel user)
        {

            _logger.LogInformation("Create A  New User Starting");
            ApiResponse _response = new ApiResponse();
            try {
            // chec if email regeistered
            var isExit =  await this._context.Users.AnyAsync( u => u.Email == user.Email);
            if(isExit == true){
                _response.responseCode = 404;
                _response.responseMessage = "User already exists";
                _response.data = null;
                return _response;
            }
            else{
                //  check if email is  valid
                bool isValidGmail = Regex.IsMatch(user.Email, @"^[a-zA-Z0-9._%+-]+@gmail\.com$");
                // check  if phone number is valid
                bool isValidPhoneNumber = Regex.IsMatch(user.Phone, @"^[0-9]{10}$");
                if( isValidGmail == false) {
                    _response.responseCode = 400;
                    _response.responseMessage = "Email is not valid";
                    return _response;
                }
                else if( isValidPhoneNumber == false){
                    _response.responseCode = 400;
                    _response.responseMessage = "Phone number is not valid";
                    return _response;
                }
                User _user = this._mapper.Map<UserCreateModel, User>(user);
                 // Tạo một Guid mới
                _user.Id = Guid.NewGuid().ToString(); 
                await this._context.Users.AddAsync(_user);
                await this._context.SaveChangesAsync();
                _response.responseCode = 201;
                _response.responseMessage = "User created successfully";
                _response.data = null;
                return _response;
            }
        
        }catch(Exception ex) {
            _logger.LogWarning(ex.Message);
            _response.responseCode = 500;
            _response.responseMessage = ex.Message;
            
        }
        return _response;
    }
    // update user info
    public async Task<ApiResponse> updateUser(UserUpdateModel userData,string id) {


        _logger.LogInformation("Update User Info Starting");
        ApiResponse _response = new ApiResponse();
        try {
        var _user  = await this._context.Users.FindAsync(id);
        if(_user != null){
            _user.Username = userData.Username; 
            _user.Password = userData.Password; 
            _user.ProfilePic = userData.ProfilePic; 
            _user.WalletBalance = userData.WalletBalance; 
            _user.Phone = userData.Phone; 
            _user.IsAdmin = userData.IsAdmin; 
           await this._context.SaveChangesAsync();
           _response.responseCode = 200;
           _response.responseMessage = "Update Successfully";
           _response.data = null;
           return _response;
        }
        }catch(Exception ex){
            _logger.LogError(ex.Message);
            _response.responseCode = 500;
            _response.responseMessage = ex.Message;  
        }
        return _response;
    }     
    }
}