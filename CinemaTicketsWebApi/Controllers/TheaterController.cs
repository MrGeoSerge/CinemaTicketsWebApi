using CinemaTicketsWebApi.Models;
using CinemaTicketsWebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace CinemaTicketsWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TheaterController : Controller
    {
        private readonly ITheaterService _theaterService;

        public TheaterController(ITheaterService theaterService)
        {
            _theaterService = theaterService;
        }

        [HttpGet(Name = "GetAllTheaters")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<Theater>), 200)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [SwaggerOperation(OperationId = "GetAllTheaters", Description = "Provides list of all theaters")]
        public async Task<IActionResult> GetTheaters()
        {
            var result = await _theaterService.GetTheaters();
            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetTheaterById")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Theater), 200)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [SwaggerOperation(OperationId = "GetTheaterById", Description = "Provides theater by id")]
        public async Task<IActionResult> GetTheater(int id)
        {
            var result = await _theaterService.GetTheater(id);
            return Ok(result);
        }

        [HttpPost(Name = "AddNewTheater")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Theater), 200)]
        [SwaggerOperation(OperationId = "AddNewTheater", Description = "Adds new theater info")]
        public async Task<IActionResult> AddTheater(Theater theater)
        {
            var result = await _theaterService.AddTheater(theater);
            return Ok(result);
        }

        [HttpPut(Name = "UpdateTheater")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Theater), 200)]
        [SwaggerOperation(OperationId = "UpdateTheater", Description = "Updates the theater info")]
        public async Task<IActionResult> UpdateTheater(Theater theater)
        {
            var result = await _theaterService.UpdateTheater(theater);
            return Ok(result);
        }

        [HttpDelete("{id}", Name = "DeleteTheater")]
        [ProducesResponseType(typeof(Theater), 200)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [SwaggerOperation(OperationId = "UpdateTheater", Description = "Updates the theater info")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _theaterService.DeleteTheater(id);
            return Ok();
        }
    }
}
