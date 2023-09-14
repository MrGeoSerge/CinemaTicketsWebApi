using CinemaTicketsWebApi.DataAccess;
using CinemaTicketsWebApi.Exceptions;
using CinemaTicketsWebApi.Models;
using CinemaTicketsWebApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CinemaTicketsWebApi.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly CinemaTicketBookingDbContext _dbContext;

        public MovieRepository(CinemaTicketBookingDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<Movie?> GetMovie(int id)
        {
            var result = await _dbContext.Movies.FirstOrDefaultAsync(x => x.Id == id);
            if (result == null)
            {
                throw new ItemNotFoundException($"Movie with Id: {id} was not found");
            }
            return result;
        }

        public async Task<IEnumerable<Movie>> GetMovies()
        {
            return await _dbContext.Movies.ToListAsync();
        }

        public async Task<Movie> AddMovie(Movie movie)
        {
            var result = await _dbContext.Movies.AddAsync(movie);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Movie> UpdateMovie(Movie movie)
        {
            var result = _dbContext.Movies.Update(movie);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteMovie(int id)
        {
            var movie = await _dbContext.Movies.FirstOrDefaultAsync(x => x.Id == id);

            if(movie is null)
            {
                throw new ItemNotFoundException($"Movie with Id: {id} was not found");
            }

            _dbContext.Movies.Remove(movie);
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}
