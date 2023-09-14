using CinemaTicketsWebApi.DataAccess;
using CinemaTicketsWebApi.Exceptions;
using CinemaTicketsWebApi.Models;
using CinemaTicketsWebApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CinemaTicketsWebApi.Repositories
{
    public class ShowtimeRepository : IShowtimeRepository
    {
        private readonly CinemaTicketBookingDbContext _dbContext;

        public ShowtimeRepository(CinemaTicketBookingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Showtime?> GetShowtime(int id)
        {
            var result = await _dbContext.Showtimes.FirstOrDefaultAsync(x => x.Id == id);
            if (result == null)
            {
                throw new ItemNotFoundException($"Showtime with Id: {id} was not found");
            }
            return result;
        }

        public async Task<IEnumerable<Showtime>> GetShowtimes()
        {
            return await _dbContext.Showtimes.ToListAsync();
        }

        public async Task<Showtime> AddShowtime(Showtime showtime)
        {
            var result = await _dbContext.Showtimes.AddAsync(showtime);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Showtime> UpdateShowtime(Showtime showtime)
        {
            var result = _dbContext.Showtimes.Update(showtime);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteShowtime(int id)
        {
            var showtime = await _dbContext.Showtimes.FirstOrDefaultAsync(x => x.Id == id);

            if (showtime is null)
            {
                throw new ItemNotFoundException($"Showtime with Id: {id} was not found");
            }

            _dbContext.Showtimes.Remove(showtime);
            await _dbContext.SaveChangesAsync();
            return true;
        }


    }
}
