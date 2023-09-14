using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaTicketsWebApi.Models
{
    public class Showtime
    {
        [Key]
        public int Id { get; set; }

        public DateTime StartDateTime { get; set; }

        [ForeignKey("Movie")]
        public int MovieId { get; set; }

        public Movie Movie { get; set; }

        [ForeignKey("Theater")]
        public int TheaterId { get; set; }

        public virtual Theater Theater { get; set; }
    }
}
