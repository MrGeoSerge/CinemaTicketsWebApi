namespace CinemaTicketsWebApi.Dtos
{
    public class ReservationRequest
    {
        /// <example>[1,2]</example>
        public List<int> TicketIds { get; set; }
    }
}
