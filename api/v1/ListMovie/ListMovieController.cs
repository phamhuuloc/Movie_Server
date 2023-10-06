using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movie_Server.Services;
using Movie_Server.Models;

namespace  Movie_Server.Controllers {
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]

    public   class ListMovieController : ControllerBase {
        private readonly IListMovieServices _services;
        public ListMovieController(IListMovieServices services) {
            this._services = services;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> getAllListMovie() {
           var data = await this._services.getAllListMovie(); 
           return Ok(data);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> createNewListMovie(ListMovieCreateModel listMovie) {
           var data = await this._services.createNewListMovie(listMovie); 
           return Ok(data);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> updateListMovie(ListMovieCreateModel listMovie,string id) {
           var data = await this._services.updateListMovie(listMovie,id); 
           return Ok(data);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> deleteListMovie(string  id) {
            var data = await this._services.deleteListMovie(id);
            return Ok(data);
        }

    }
}