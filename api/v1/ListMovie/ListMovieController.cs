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
        [HttpPost("Create")]
        public async Task<IActionResult> createNewListMovie(ListMovieCreateModel listMovie) {
           var data = await this._services.createNewListMovie(listMovie); 
           return Ok(data);
        }
    }
}