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
        [HttpGet("GetById")]
        public async Task<IActionResult> getListMovieById(string id) {
           var data = await this._services.getListMovieById(id); 
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
        [HttpDelete]
        public async Task<IActionResult> deleteListMovie(string  id) {
            var data = await this._services.deleteListMovie(id);
            return Ok(data);
        }
        [HttpPost("AddMovie")]
        public async Task<IActionResult> addMovieIntoList(MovieListModel movieListModel) {
           var data = await this._services.addMovieIntoList(movieListModel); 
           return Ok(data);
        }
        [HttpDelete("DeleteMovie")]
        public async Task<IActionResult> deleteMovieFromList(string list_id, string movie_id) {
           var data = await this._services.deleteMovieFromList(list_id , movie_id); 
           return Ok(data);
        }


    }
}