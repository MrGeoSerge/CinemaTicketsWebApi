using CinemaTicketsWebApi.Models;
using CinemaTicketsWebApi.Repositories.Interfaces;
using CinemaTicketsWebApi.Services.Interfaces;

namespace CinemaTicketsWebApi.Services
{
    public class ShowtimeService : IShowtimeService
    {
        private readonly IShowtimeRepository _showtimeRepository;

        public ShowtimeService(IShowtimeRepository showtimeRepository)
        {
            _showtimeRepository = showtimeRepository;
        }

        public Task<Showtime> AddShowtime(Showtime showtime)
        {
            ///TODO: Add showtime properties validation
            return _showtimeRepository.AddShowtime(showtime);
        }

        public Task<bool> DeleteShowtime(int id)
        {
            return _showtimeRepository.DeleteShowtime(id);
        }

        public Task<Showtime?> GetShowtime(int id)
        {
            return _showtimeRepository.GetShowtime(id);
        }

        public Task<IEnumerable<Showtime>> GetShowtimes()
        {
            return _showtimeRepository.GetShowtimes();
        }

        public Task<Showtime> UpdateShowtime(Showtime showtime)
        {
            return _showtimeRepository.UpdateShowtime(showtime);
        }
    }
}
