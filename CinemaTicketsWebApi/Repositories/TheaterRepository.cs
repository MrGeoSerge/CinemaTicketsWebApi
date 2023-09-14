using CinemaTicketsWebApi.DataAccess;
using CinemaTicketsWebApi.Exceptions;
using CinemaTicketsWebApi.Models;
using CinemaTicketsWebApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CinemaTicketsWebApi.Repositories
{
    public class TheaterRepository : ITheaterRepository
    {
        private readonly CinemaTicketBookingDbContext _dbContext;

        public TheaterRepository(CinemaTicketBookingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Theater?> GetTheater(int id)
        {
            var result = await _dbContext.Theaters.FirstOrDefaultAsync(x => x.Id == id);
            if (result == null)
            {
                throw new ItemNotFoundException($"Theater with Id: {id} was not found");
            }
            return result;
        }

        public async Task<IEnumerable<Theater>> GetTheaters()
        {
            return await _dbContext.Theaters.ToListAsync();
        }

        public async Task<Theater> AddTheater(Theater theater)
        {
            var result = await _dbContext.Theaters.AddAsync(theater);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Theater> UpdateTheater(Theater theater)
        {
            var result = _dbContext.Theaters.Update(theater);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteTheater(int id)
        {
            var theater = await _dbContext.Theaters.FirstOrDefaultAsync(x => x.Id == id);

            if (theater is null)
            {
                throw new ItemNotFoundException($"Theater with Id: {id} was not found");
            }

            _dbContext.Theaters.Remove(theater);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
