using System.ComponentModel.DataAnnotations;

namespace CinemaTicketsWebApi.Models
{
    public class Theater
    {
        /// <example>1</example>
        [Key]
        public int Id { get; set; }

        /// <example>Best Movie Theater</example>
        public string Name { get; set; }

        public List<TheaterSeat> Seats { get; set; }
    }
}
