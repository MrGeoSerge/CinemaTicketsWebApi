using System.ComponentModel.DataAnnotations;

namespace CinemaTicketsWebApi.Models
{
    public class Reservation
    {
        /// <example>1</example>
        [Key]
        public int Id { get; set; }

        public IEnumerable<Ticket> tickets;

        public IEnumerable<Ticket> Tickets {
            get
            {
                return tickets;
            }
            set
            {
                tickets = value;
                CalculateTotalPrice();
            }
        }

        public float totalPrice;

        /// <example>111.23</example>
        public float TotalPrice { 
            get
            {
                return totalPrice;
            }
        }

        /// <example>true</example>
        public bool IsCompleted { get; set; }

        /// <example>2023-10-01T19:41:00.000Z</example>
        public DateTime? EndReservationTime { get; set; }

        private void CalculateTotalPrice()
        {
            totalPrice = tickets.Sum(t => t.Price);
        }
    }

}
