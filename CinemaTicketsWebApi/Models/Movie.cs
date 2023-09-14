using CinemaTicketsWebApi.Enums;
using System.ComponentModel.DataAnnotations;

namespace CinemaTicketsWebApi.Models
{
    public class Movie
    {
        /// <example>1</example>
        [Key]
        public int Id { get; set; }

        /// <example>Rocky 3</example>
        public string Title { get; set; }

        /// <example>Rocky, the reigning world champion, accepts a boxing challenge from Clubber Lang and loses the match. He also ends up losing his credibility as a champion, and has to fight to get it back.</example>
        public string Description { get; set; }

        /// <example>116</example>
        public int DurationMinutes { get; set; }

        /// <example>0</example>
        public Genre Genre { get; set; }

    }
}
