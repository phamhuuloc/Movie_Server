using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.VisualBasic;
using Movie_Server.Models;
using Movie_Server.Services;
// using Org.BouncyCastle.Asn1.Iana;

namespace Movie_Server.Controllers {


    [Authorize]
    [EnableRateLimiting("fixedwindow")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController: ControllerBase {
       private readonly IUserServices services;
       public UserController(IUserServices services) {
        this.services = services;
       }
       [HttpGet("GetAll") ]
       public async Task<IActionResult> Get() {
             var data =  await this.services.getAllUsers();
             return Ok(data);
       }
       
        [HttpGet("GetById")]
       public async Task<IActionResult> getById(string id) {
             var data =  await this.services.getUserById(id);
             if(data.Username == null) {
                return NotFound();
             }
             return Ok(data);
       }
       
       [HttpPost("Create")]
       public async Task<IActionResult> createNewUser(UserCreateModel user) {
             var data =  await this.services.createNewUser(user);
             return Ok(data);
       }
      [HttpPut("Update")] 
      public async Task<IActionResult> updateUser(UserUpdateModel user,string id) {
             var data =  await this.services.updateUser(user,id);
             return Ok(data);
       }
    }
}