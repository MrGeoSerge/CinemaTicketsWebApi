using CinemaTicketsWebApi.Models;
using CinemaTicketsWebApi.Repositories.Interfaces;
using CinemaTicketsWebApi.Services.Interfaces;

namespace CinemaTicketsWebApi.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public Task<Movie> AddMovie(Movie movie)
        {
            ///TODO: Add movie properties validation
            return _movieRepository.AddMovie(movie);
        }

        public Task<bool> DeleteMovie(int id)
        {
            return _movieRepository.DeleteMovie(id);
        }

        public Task<Movie?> GetMovie(int id)
        {
            return _movieRepository.GetMovie(id);
        }

        public Task<IEnumerable<Movie>> GetMovies()
        {
            return _movieRepository.GetMovies();
        }

        public Task<Movie> UpdateMovie(Movie movie)
        {
            return _movieRepository.UpdateMovie(movie);
        }
    }
}
