using CinemaTicketsWebApi.DataAccess;
using CinemaTicketsWebApi.Exceptions;
using CinemaTicketsWebApi.Models;
using CinemaTicketsWebApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CinemaTicketsWebApi.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly CinemaTicketBookingDbContext _dbContext;

        public ReservationRepository(CinemaTicketBookingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Reservation> CreateReservation(Reservation reservation)
        {
            var result = await _dbContext.Reservations.AddAsync(reservation);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Reservation> GetReservation(int id)
        {
            var result = await _dbContext.Reservations.FirstOrDefaultAsync(x => x.Id == id);
            if (result == null)
            {
                throw new ItemNotFoundException($"Reservation with Id: {id} was not found");
            }
            return result;
        }

        public async Task<Reservation> MarkReservationAsCompleted(int id)
        {
            var reservation = await _dbContext.Reservations.FirstOrDefaultAsync(x => x.Id == id);
            if (reservation == null)
            {
                throw new ItemNotFoundException($"Reservation with Id: {id} was not found");
            }

            reservation.IsCompleted = true;

            var result = _dbContext.Reservations.Update(reservation);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> RemoveReservation(int id)
        {
            var reservation = await _dbContext.Reservations.FirstOrDefaultAsync(x => x.Id == id);

            if (reservation is null)
            {
                throw new ItemNotFoundException($"Reservation with Id: {id} was not found");
            }

            _dbContext.Reservations.Remove(reservation);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveReservation(Reservation reservation)
        {
            _dbContext.Reservations.Remove(reservation);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public IQueryable<Reservation> GetExpiredReservations()
        {
            return _dbContext.Reservations.Where(x => x.EndReservationTime <  DateTime.UtcNow);
        }

    }
}
