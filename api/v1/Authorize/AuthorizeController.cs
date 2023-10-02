using System.Text;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie_Server.Database.Models;
using Movie_Server.Helper;
using Movie_Server.Models;
using Movie_Server.Services;

namespace Movie_Server.Controllers {
       

    [Route("api/v1/[controller]")]
    [ApiController]

    public class AuthorizeController : ControllerBase {
        private readonly IAuthorizeServices _services;
        public AuthorizeController(IAuthorizeServices services) {
             this._services = services;
       }
        [HttpPost("/register")]
        public async Task<IActionResult> Register(AuthorizeModel request) {
            var data =  await this._services.Register(request);
             return Ok(data);

        }
        [HttpPost("/login")]
        public async Task<IActionResult> Login(AuthorizeModel request) {
            var data =  await this._services.Login(request);
            return Ok(data);
        }
    }
}
