using CinemaTicketsWebApi.Models;
using CinemaTicketsWebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace CinemaTicketsWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShowtimeController : Controller
    {
        private readonly IShowtimeService _showtimeService;

        public ShowtimeController(IShowtimeService showtimeService)
        {
            _showtimeService = showtimeService;
        }

        /// <summary>
        /// Gets all Showtimes in the system
        /// </summary>
        /// <returns>Get All Showtimes</returns>
        [HttpGet(Name = "GetAllShowtimes")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<Showtime>), 200)]
        [SwaggerOperation(OperationId = "GetAllShowtimes", Description = "Provides list of all showtimes")]
        public async Task<IActionResult> GetShowtimes()
        {
            var result = await _showtimeService.GetShowtimes();
            return Ok(result);
        }

        /// <summary>
        /// Gets a Showtime
        /// </summary>
        /// <param name="showtimeId"></param>
        /// <returns>Showtime by Id</returns>
        [HttpGet("{id}", Name = "GetShowtimeById")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Showtime), 200)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [SwaggerOperation(OperationId = "GetShowtimeById", Description = "Provides showtime by id")]
        public async Task<IActionResult> GetShowtime(int id)
        {
            var result = await _showtimeService.GetShowtime(id);
            return Ok(result);
        }

        /// <summary>
        /// Creates a Showtime
        /// </summary>
        /// <param name="showtime"></param>
        /// <returns>A newly created Showtime</returns>
        [HttpPost(Name = "AddNewShowtime")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Showtime), 200)]
        [SwaggerOperation(OperationId = "AddNewShowtime", Description = "Adds new showtime info")]
        public async Task<IActionResult> AddShowtime(Showtime showtime)
        {
            var result = await _showtimeService.AddShowtime(showtime);
            return Ok(result);
        }

        /// <summary>
        /// Updates a Showtime
        /// </summary>
        /// <param name="showtime"></param>
        /// <returns>A newly updated Showtime</returns>
        [HttpPut(Name = "UpdateShowtime")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Showtime), 200)]
        [SwaggerOperation(OperationId = "UpdateShowtime", Description = "Updates the showtime info")]
        public async Task<IActionResult> UpdateShowtime(Showtime showtime)
        {
            var result = await _showtimeService.UpdateShowtime(showtime);
            return Ok(result);
        }

        /// <summary>
        /// Deletes a specific Showtime.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}", Name = "DeleteShowtime")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [SwaggerOperation(OperationId = "DeleteShowtime", Description = "Deletes the showtime")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _showtimeService.DeleteShowtime(id);
            return Ok();
        }
    }
}
