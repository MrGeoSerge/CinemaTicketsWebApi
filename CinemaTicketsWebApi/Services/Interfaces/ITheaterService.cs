using CinemaTicketsWebApi.Models;

namespace CinemaTicketsWebApi.Services.Interfaces
{
    public interface ITheaterService
    {
        Task<IEnumerable<Theater>> GetTheaters();

        Task<Theater?> GetTheater(int id);

        Task<Theater> AddTheater(Theater theater);

        Task<Theater> UpdateTheater(Theater theater);

        Task<bool> DeleteTheater(int id);
    }
}
