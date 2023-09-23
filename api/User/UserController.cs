using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Movie_Server.Services;
// using Org.BouncyCastle.Asn1.Iana;

namespace Movie_Server.Controllers {
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController: ControllerBase {
       private readonly IUserServices services;
       public UserController(IUserServices services) {
        this.services = services;
       }
       [HttpGet("GetAll")]
       public async Task<IActionResult> Get() {
             var data =  await this.services.getAllUsers();
             return Ok(data);
       }
       
    }
}