using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Movie_Server.Database.Models;

namespace Movie_Server.middlewares {
    public class AuthenticationMiddleWare {
        private readonly IConfiguration _configuration;
        private readonly User _user;
        public AuthenticationMiddleWare (IConfiguration configuration , User user) {
            this._configuration = configuration;
            this._user = user;
        }
        public  string generateAccessToken(User user) {
            List<Claim> claims = new List<Claim>{
                    new Claim(ClaimTypes.Name, user.Id),
            };
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                   _configuration.GetSection("JwtSetting:accessTokenKey").Value 
                ) 
            ) ;
            var cred = new  SigningCredentials(key,SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(
                claims : claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials : cred
            );
            var accessToken =  new JwtSecurityTokenHandler().WriteToken(token);
           return accessToken; 
        }
    }
}