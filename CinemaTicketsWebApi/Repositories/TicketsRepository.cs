using CinemaTicketsWebApi.DataAccess;
using CinemaTicketsWebApi.Models;
using CinemaTicketsWebApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CinemaTicketsWebApi.Repositories
{
    public class TicketsRepository : ITicketsRepository
    {
        private readonly CinemaTicketBookingDbContext _dbContext;

        public TicketsRepository(CinemaTicketBookingDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Ticket>> GetAvailableTicketsForShowtime(int showtimeId)
        {
            var result = await _dbContext.Tickets.Where(x => x.ShowtimeId == showtimeId && !x.IsSold && !x.IsReserved)
                                                 .ToListAsync();
            return result;
        }

        public async Task<IEnumerable<Ticket>> GetTicketsByIds(IEnumerable<int> ticketsId)
        {
            var result = await _dbContext.Tickets.Where(x => ticketsId.Contains(x.Id))
                                                 .ToListAsync();
            return result;
        }

        public async Task<bool> ReserveTickets(IEnumerable<int> ticketsIds)
        {
            var result = await _dbContext.Tickets.Where(x => ticketsIds.Contains(x.Id))
                                            .ExecuteUpdateAsync(b => b
                                                .SetProperty(x => x.IsReserved, true));

            return result == ticketsIds.Count();
        }

        public async Task<bool> RemoveReservationFromTickets(IEnumerable<int> ticketsIds)
        {
            var result = await _dbContext.Tickets.Where(x => ticketsIds.Contains(x.Id))
                                            .ExecuteUpdateAsync(b => b
                                                .SetProperty(x => x.IsReserved, false));

            return result == ticketsIds.Count();
        }

        public async Task<bool> MarkTicketsAsSold(IEnumerable<int> ticketIds)
        {
            var result = await _dbContext.Tickets.Where(x => ticketIds.Contains(x.Id))
                                            .ExecuteUpdateAsync(b => b
                                                .SetProperty(x => x.IsSold, true));

            return result == ticketIds.Count();
        }

    }
}
