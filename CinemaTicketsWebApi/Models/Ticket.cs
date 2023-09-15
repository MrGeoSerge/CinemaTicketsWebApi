using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaTicketsWebApi.Models
{
    //For simplification we don't have mapping in the project
    //And we should add mapping and distinguish TicketsDto from TicketBO from Ticket - database model
    public class Ticket
    {
        /// <example>1</example>
        [Key]
        public int Id { get; set; }

        /// <example>false</example>
        public bool IsSold { get; set; }

        /// <example>false</example>
        public bool IsReserved { get; set; }

        /// <example>15.1</example>
        public float Price { get; set; }

        /// <example>1</example>
        [ForeignKey("TheaterSeat")]
        public int TheaterSeatId { get; set; }

        public virtual TheaterSeat TheaterSeat { get; set; }

        /// <example>1</example>
        [ForeignKey("Showtime")]
        public int ShowtimeId { get; set; }

        public virtual Showtime Showtime { get; set; }


        [ForeignKey("Reservation")]
        public int? ReservationId { get; set; }

        public virtual Reservation Reservation { get; set; }

    }
}
