using CinemaTicketsWebApi.Models;
using CinemaTicketsWebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace CinemaTicketsWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        /// <summary>
        /// Gets all Movies in the system
        /// </summary>
        /// <returns>Get All Movies</returns>
        [HttpGet(Name = "GetAllMovies")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<Movie>), 200)]
        [SwaggerOperation(OperationId = "GetAllMovies", Description = "Provides list of all movies")]
        public async Task<IActionResult> GetMovies()
        {
            var result = await _movieService.GetMovies();
            return Ok(result);
        }

        /// <summary>
        /// Gets a Movie
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns>Movie by Id</returns>
        [HttpGet("{id}", Name = "GetMovieById")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Movie), 200)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [SwaggerOperation(OperationId = "GetMovieById", Description = "Provides movie by id")]
        public async Task<IActionResult> GetMovie(int id)
        {
            var result = await _movieService.GetMovie(id);
            return Ok(result);
        }

        /// <summary>
        /// Creates a Movie
        /// </summary>
        /// <param name="movie"></param>
        /// <returns>A newly created Movie</returns>
        [HttpPost(Name = "AddNewMovie")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Movie), 200)]
        [SwaggerOperation(OperationId = "AddNewMovie", Description = "Adds new movie info")]
        public async Task<IActionResult> AddMovie(Movie movie)
        {
            var result = await _movieService.AddMovie(movie);
            return Ok(result);
        }

        /// <summary>
        /// Updates a Movie
        /// </summary>
        /// <param name="movie"></param>
        /// <returns>A newly updated Movie</returns>
        [HttpPut(Name = "UpdateMovie")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Movie), 200)]
        [SwaggerOperation(OperationId = "UpdateMovie", Description = "Updates the movie info")]
        public async Task<IActionResult> UpdateMovie(Movie movie)
        {
            var result = await _movieService.UpdateMovie(movie);
            return Ok(result);
        }

        /// <summary>
        /// Deletes a specific Movie.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}", Name = "DeleteMovie")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [SwaggerOperation(OperationId = "DeleteMovie", Description = "Deletes the movie")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _movieService.DeleteMovie(id);
            return Ok();
        }
    }
}
