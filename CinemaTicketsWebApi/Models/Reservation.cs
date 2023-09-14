using System.ComponentModel.DataAnnotations;

namespace CinemaTicketsWebApi.Models
{
    public class Reservation
    {
        /// <example>1</example>
        [Key]
        public int Id { get; set; }

        public List<Ticket> Tickets { get; set; }

        public float TotalPrice { get; set; }

        public bool IsCompleted { get; set; }

        public DateTime? EndReservationTime { get; set; }


    }
}
