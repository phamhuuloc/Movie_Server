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
        [HttpPost("Create") ]
        public async Task<IActionResult> createMovies(MovieCreateModel movie) {
              var data =  await this.services.createNewMovie(movie);
              return Ok(data);
        }

    }
}