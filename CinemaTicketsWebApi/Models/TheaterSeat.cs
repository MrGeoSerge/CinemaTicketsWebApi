using CinemaTicketsWebApi.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaTicketsWebApi.Models
{
    public class TheaterSeat
    {
        /// <example>1</example>
        [Key]
        public int Id { get; set; }

        //For simplification we will use string representation of seat location
        /// <example>Row 1 Place 35</example>
        [Required]
        public string Location { get; set; }

        /// <example>1</example>
        [ForeignKey("Theater")]
        public int TheaterId { get; set; }

        public virtual Theater Theater { get; set; }
    }
}
