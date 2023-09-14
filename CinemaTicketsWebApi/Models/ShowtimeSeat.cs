using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaTicketsWebApi.Models
{
    public class ShowtimeSeat
    {
        [Key]
        public int Id { get; set; }

        public bool IsOccupied { get; set; }

        public bool IsReserved { get; set; }

        public DateTime StartReservationTime { get; set; }

        [ForeignKey("TheaterSeat")]
        public int TheaterSeatId { get; set; }

        public virtual TheaterSeat TheaterSeat { get; set; }

        [ForeignKey("Showtime")]
        public int ShowtimeId { get; set; }

        public virtual Showtime Showtime { get; set; }
    }
}
