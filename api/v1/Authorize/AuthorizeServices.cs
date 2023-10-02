using System.Text.RegularExpressions;
using Movie_Server.Helper;
using Movie_Server.Models;
using Movie_Server.Database.Models;
using Microsoft.EntityFrameworkCore;
using Movie_Server.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Serilog;
using System.IdentityModel.Tokens.Jwt;

namespace Movie_Server.Container {
    public class AuthorizeServices : IAuthorizeServices{
         public readonly MovieserverContext _context;
         public readonly Mapper _mapper;
         public readonly ILogger<AuthorizeServices> _logger;
         private readonly IConfiguration _configuration;
       


        public   AuthorizeServices (MovieserverContext context , IMapper mapper, ILogger<AuthorizeServices> logger, IConfiguration configuration) {
            this._context = context;
            this._mapper = (Mapper?)mapper;
            this._logger = logger;
            this._configuration = configuration;
        }

        public async Task<ApiResponse> Register (AuthorizeModel request) {
            ApiResponse _response = new ApiResponse();
            try {
            Boolean isValidGmail = Regex.IsMatch(request.Email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Boolean isExit =  await this._context.Users.AnyAsync( u => u.Email == request.Email);
            if(request.Email == "" || request.Password == ""){
                _response.responseCode = 400; 
                _response.responseMessage = "Email or Password is empty";
                return _response;
            }
            else if(isValidGmail == false){
                _response.responseCode = 400;
                _response.responseMessage = "Email is not valid";
                return _response;
            }
            else if(isExit == true){
                _response.responseCode = 400;
                _response.responseMessage = "User already exists";
                return _response;
            }
            else {
                // hash password
              string  passwordHashed = BCrypt.Net.BCrypt.HashPassword(request.Password);
              AuthorizeModel  user = new AuthorizeModel() {
                    Email = request.Email,
                    Password = passwordHashed
                };
                User _user = this._mapper.Map<AuthorizeModel, User>(user);
                 // Tạo một Guid mới
                _user.Id = Guid.NewGuid().ToString(); 
                await this._context.Users.AddAsync(_user);
                await this._context.SaveChangesAsync();
                _response.responseCode = 200;
                _response.responseMessage = "Register Successfully";
                _response.data = null;
                return _response;
            } 
            }catch (Exception ex) {
                 _response.responseCode = 500; 
                _response.responseMessage = "Server Error...";
                //  _response.responseMessage = ex.Message;
            }

            return _response;

        }
        private  string generateAccessToken(User user){ 
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Id),
                new Claim(ClaimTypes.Role, user.Role),

            };
            
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
            );
            
            var accessToken = new JwtSecurityTokenHandler().WriteToken(token);
            
            return accessToken;
        }

        public async Task<ApiResponse> Login (AuthorizeModel request){
            ApiResponse _response = new ApiResponse();
            try{
                var _user =  await this._context.Users.FirstOrDefaultAsync( u => u.Email == request.Email);
                // Log user information
                if(_user == null) {
                    _response.responseCode = 400;
                    _response.responseMessage = "User not exists";
                    _response.data = null;
                    return _response;
                } else if( !BCrypt.Net.BCrypt.Verify(request.Password,_user.Password)) {
                    _response.responseCode = 200;
                    _response.responseMessage = "Wromg Password";
                    _response.data = null;
                    return _response;
                }
                else {
                Log.Information("User Information: {@User}", _user.Id);
                string token =  generateAccessToken(_user);
                _response.responseCode = 200;
                _response.responseMessage = "Login Successfully";
                _response.data = new  {
                      token
                };
                return _response;

                }
                
            }catch(Exception ex){
                _response.responseCode = 500;
                _response.responseMessage = ex.Message;
                _response.data = null;

            }

            return _response;
        }

    
    }
}