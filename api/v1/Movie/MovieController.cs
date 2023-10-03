using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movie_Server.Models;
using Movie_Server.Services;

namespace Movie_Server.Controllers {
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase{
        private readonly IMovieServices services;
        public MovieController(IMovieServices services) {
            this.services = services;
        }
        [HttpGet("GetAll") ]
        public async Task<IActionResult> getAllMovies() {
              var data =  await this.services.getAllMovies();
              return Ok(data);
        }
        [HttpPost("Create") ]
        public async Task<IActionResult> createMovies(MovieModel movie) {
              var data =  await this.services.createNewMovie(movie);
              return Ok(data);
        }

        [HttpPut("Update") ]
        public async Task<IActionResult> updateMovieInfo(MovieModel movie, string id) {
              var data =  await this.services.updateMovieInfo(movie,id);
              return Ok(data);
        }

    }
}