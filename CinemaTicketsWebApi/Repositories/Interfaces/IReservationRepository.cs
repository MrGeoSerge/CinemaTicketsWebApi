using CinemaTicketsWebApi.Models;

namespace CinemaTicketsWebApi.Repositories.Interfaces
{
    public interface IReservationRepository
    {
        Task<Reservation> CreateReservation(Reservation reservation);

        IQueryable<Reservation> GetExpiredReservations();

        Task<Reservation> GetReservation(int id);

        Task<Reservation> MarkReservationAsCompleted(int id);

        Task<bool> RemoveReservation(int id);

        Task<bool> RemoveReservation(Reservation reservation);
    }
}
