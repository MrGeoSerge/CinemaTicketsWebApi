using CinemaTicketsWebApi.Models;

namespace CinemaTicketsWebApi.Services.Interfaces
{
    public interface IMovieService
    {
        Task<IEnumerable<Movie>> GetMovies();

        Task<Movie?> GetMovie(int id);

        Task<Movie> AddMovie(Movie movie);

        Task<Movie> UpdateMovie(Movie movie);

        Task<bool> DeleteMovie(int id);
    }
}
