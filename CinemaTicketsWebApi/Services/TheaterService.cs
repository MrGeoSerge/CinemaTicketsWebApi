using CinemaTicketsWebApi.Models;
using CinemaTicketsWebApi.Repositories.Interfaces;
using CinemaTicketsWebApi.Services.Interfaces;

namespace CinemaTicketsWebApi.Services
{
    public class TheaterService : ITheaterService
    {
        private readonly ITheaterRepository _theaterRepository;

        public TheaterService(ITheaterRepository theaterRepository)
        {
            _theaterRepository = theaterRepository;
        }

        public Task<Theater> AddTheater(Theater theater)
        {
            ///TODO: Add theater properties validation
            return _theaterRepository.AddTheater(theater);
        }

        public Task<bool> DeleteTheater(int id)
        {
            return _theaterRepository.DeleteTheater(id);
        }

        public Task<Theater?> GetTheater(int id)
        {
            return _theaterRepository.GetTheater(id);
        }

        public Task<IEnumerable<Theater>> GetTheaters()
        {
            return _theaterRepository.GetTheaters();
        }

        public Task<Theater> UpdateTheater(Theater theater)
        {
            return _theaterRepository.UpdateTheater(theater);
        }

    }
}
