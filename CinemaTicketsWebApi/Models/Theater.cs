using System.ComponentModel.DataAnnotations;

namespace CinemaTicketsWebApi.Models
{
    public class Theater
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public List<TheaterSeat> Seats { get; set; }
    }
}
