using CinemaTicketsWebApi.Dtos;
using CinemaTicketsWebApi.Models;

namespace CinemaTicketsWebApi.Services.Interfaces
{
    public interface IBookingService
    {
        Task<IEnumerable<Ticket>> GetAvailableTickets(int showtimeId);

        Task<Reservation> ReserveTickets(ReservationRequest reservationRequest);

        Task<Reservation> CompleteReservation(int id);

        Task<bool> CancelReservation(int reservationId);

        Task CancelExpiredReservations();

    }
}
