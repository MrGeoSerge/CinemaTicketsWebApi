using CinemaTicketsWebApi.Models;

namespace CinemaTicketsWebApi.Repositories.Interfaces
{
    public interface ITicketsRepository
    {
        public Task<IEnumerable<Ticket>> GetAvailableTicketsForShowtime(int showtimeId);

        public Task<bool> RemoveReservationFromTickets(IEnumerable<int> ticketsId);

        public Task<List<Ticket>> CompleteReservation(IEnumerable<int> ticketIds);
    }
}
