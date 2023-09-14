using CinemaTicketsWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaTicketsWebApi.DataAccess
{
    public class CinemaTicketBookingDbContext : DbContext
    {
        public CinemaTicketBookingDbContext(DbContextOptions<CinemaTicketBookingDbContext> options)
            : base(options)
        { }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Showtime> Showtimes { get; set; }

        public DbSet<ShowtimeSeat> ShowtimeSeats { get; set;}

        public DbSet<Theater> Theaters { get; set; }

        public DbSet<TheaterSeat> TheaterSeats { get; set;}

    }
}
