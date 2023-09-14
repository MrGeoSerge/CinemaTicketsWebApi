using CinemaTicketsWebApi.Models;

namespace CinemaTicketsWebApi.Repositories.Interfaces
{
    public interface IShowtimeRepository
    {
        Task<Showtime?> GetShowtime(int id);

        Task<IEnumerable<Showtime>> GetShowtimes();

        Task<Showtime> AddShowtime(Showtime showtime);

        Task<Showtime> UpdateShowtime(Showtime showtime);

        Task<bool> DeleteShowtime(int id);

    }
}
