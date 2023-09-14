using CinemaTicketsWebApi.Models;

namespace CinemaTicketsWebApi.Repositories.Interfaces
{
    public interface IMovieRepository
    {
        Task<Movie?> GetMovie(int id);

        Task<IEnumerable<Movie>> GetMovies();

        Task<Movie> AddMovie(Movie movie);

        Task<Movie> UpdateMovie(Movie movie);

        Task<bool> DeleteMovie(int id);
    }
}
