using CinemaTicketsWebApi.Models;

namespace CinemaTicketsWebApi.Services.Interfaces
{
    public interface IShowtimeService
    {
        Task<IEnumerable<Showtime>> GetShowtimes();

        Task<Showtime?> GetShowtime(int id);

        Task<Showtime> AddShowtime(Showtime showtime);

        Task<Showtime> UpdateShowtime(Showtime showtime);

        Task<bool> DeleteShowtime(int id);

    }
}
