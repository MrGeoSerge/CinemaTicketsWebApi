using CinemaTicketsWebApi.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaTicketsWebApi.Models
{
    public class TheaterSeat
    {
        [Key]
        public int Id { get; set; }

        public string Label { get; set; }

        public SeatPricingCategory Category { get; set; }

        [ForeignKey("Theater")]
        public int TheaterId { get; set; }

        public virtual Theater Theater { get; set; }
    }
}
