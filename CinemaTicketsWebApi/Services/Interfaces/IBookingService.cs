using CinemaTicketsWebApi.Dtos;
using CinemaTicketsWebApi.Models;

namespace CinemaTicketsWebApi.Services.Interfaces
{
    public interface IBookingService
    {
        Task<List<Ticket>> GetAvailableTickets(int showtimeId);

        Task<Reservation> ReserveTickets(ReservationRequest reservationRequest);

        Task<Reservation> CompleteReservation(int id);


    }
}
