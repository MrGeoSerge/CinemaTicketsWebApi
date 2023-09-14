using CinemaTicketsWebApi.Models;

namespace CinemaTicketsWebApi.Repositories.Interfaces
{
    public interface ITheaterRepository
    {
        Task<Theater?> GetTheater(int id);

        Task<IEnumerable<Theater>> GetTheaters();

        Task<Theater> AddTheater(Theater theater);

        Task<Theater> UpdateTheater(Theater theater);

        Task<bool> DeleteTheater(int id);
    }
}
