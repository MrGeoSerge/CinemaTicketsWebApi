using CinemaTicketsWebApi.Dtos;
using CinemaTicketsWebApi.Models;
using CinemaTicketsWebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace CinemaTicketsWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        /// <summary>
        /// Gets all seats in the system
        /// </summary>
        /// <returns>Get All available tickets for showtime</returns>
        [HttpGet("GetAvailableTickets/{showtimeId}", Name = "Get Available Tickets")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<Showtime>), 200)]
        [SwaggerOperation(OperationId = "GetAvailableTicketsForShowtime", Description = "Provides list of avilable tickets to specific showtime")]
        public async Task<IActionResult> GetAvailableTicketsForShowtime(int showtimeId)
        {
            var result = await _bookingService.GetAvailableTickets(showtimeId);
            return Ok(result);
        }

        /// <summary>
        /// Reserves tickets in the system. Returns reservation
        /// </summary>
        /// <returns>Get All Showtimes</returns>
        [HttpPost("ReserveTickets", Name = "ReserveTickets")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<Showtime>), 200)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [SwaggerOperation(OperationId = "ReserveTickets", Description = "Reserve tickets")]
        public async Task<IActionResult> ReserveTickets(ReservationRequest reservationRequest)
        {
            var result = await _bookingService.ReserveTickets(reservationRequest);
            return Ok(result);
        }

        /// <summary>
        /// Completes booking. Returns confirmed reservation of tickets
        /// </summary>
        /// <returns>Reservation Completed</returns>
        [HttpPatch("CompleteReservation/{reservationId}", Name = "ReserveTicket")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<Showtime>), 200)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [SwaggerOperation(OperationId = "CompleteReservation", Description = "Completes the reservation")]
        public async Task<IActionResult> CompleteReservation(int reservationId)
        {
            var result = await _bookingService.CompleteReservation(reservationId);
            return Ok(result);
        }
    }
}
