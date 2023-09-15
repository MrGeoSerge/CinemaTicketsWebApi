using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaTicketsWebApi.Models
{
    public class Showtime
    {
        /// <example>1</example>
        [Key]
        public int Id { get; set; }

        /// <example>2023-10-01T19:41:00.000Z</example>
        public DateTime StartDateTime { get; set; }

        /// <example>1</example>
        [ForeignKey("Movie")]
        public int MovieId { get; set; }

        public Movie Movie { get; set; }

        /// <example>1</example>
        [ForeignKey("Theater")]
        public int TheaterId { get; set; }

        public virtual Theater? Theater { get; set; }

        public List<Ticket> Tickets { get; set; }
    }
}
