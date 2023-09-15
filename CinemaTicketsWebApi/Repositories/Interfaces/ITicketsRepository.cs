using CinemaTicketsWebApi.Models;

namespace CinemaTicketsWebApi.Repositories.Interfaces
{
    public interface ITicketsRepository
    {
        Task<IEnumerable<Ticket>> GetAvailableTicketsForShowtime(int showtimeId);

        Task<IEnumerable<Ticket>> GetTicketsByIds(IEnumerable<int> ticketsId);

        Task<bool> ReserveTickets(IEnumerable<int> ticketsIds);

        Task<bool> RemoveReservationFromTickets(IEnumerable<int> ticketsId);

        Task<bool> MarkTicketsAsSold(IEnumerable<int> ticketIds);
    }
}
