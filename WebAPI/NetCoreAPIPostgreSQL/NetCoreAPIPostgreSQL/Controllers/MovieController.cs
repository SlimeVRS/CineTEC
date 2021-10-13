using Microsoft.AspNetCore.Mvc;
using NetCoreAPIPostgreSQL.Data.Movie_Repository;
using NetCoreAPIPostgreSQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreAPIPostgreSQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : Controller
    {
        private readonly IMovieRepository _movieRepository;
        public MovieController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllMovies()
        {
            return Ok(await _movieRepository.GetAllMovies());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetMovieDetails(int id)
        {
            return Ok(await _movieRepository.GetMovieDetails(id));
        }

        [HttpPost]
        public async Task<ActionResult> CreateMovie([FromBody] MovieFRONTEND movie)
        {
            if (movie == null)
                return BadRequest();
            if (!ModelState.IsValid)
                BadRequest();

            var created = await _movieRepository.InsertMovieFrontEnd(movie);
            return Created("Movie created", created);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateMovie([FromBody] Movie movie)
        {
            if (movie == null)
                return BadRequest();
            if (!ModelState.IsValid)
                BadRequest();

            await _movieRepository.UpdateMovie(movie);
            return NoContent();
        }

        [HttpDelete("{id}")]
       public async Task<ActionResult> DeleteMovie(int id)
        {
            await _movieRepository.DeleteMovie(new Movie { Id_Movie = id });
            return NoContent();
        }
    }
}
