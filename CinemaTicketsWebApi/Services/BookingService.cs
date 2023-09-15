using CinemaTicketsWebApi.Dtos;
using CinemaTicketsWebApi.Models;
using CinemaTicketsWebApi.Repositories.Interfaces;
using CinemaTicketsWebApi.Services.Interfaces;

namespace CinemaTicketsWebApi.Services
{
    public class BookingService : IBookingService
    {
        private readonly ITicketsRepository _ticketsRepository;
        private readonly IReservationRepository _reservationRepository;
        private TimeSpan _reservationTimeout = TimeSpan.FromMinutes(1);//TODO: put it in settings

        public BookingService(ITicketsRepository ticketsRepository,
            IReservationRepository reservationRepository)
        {
            _ticketsRepository = ticketsRepository;
            _reservationRepository = reservationRepository;
        }

        public Task<IEnumerable<Ticket>> GetAvailableTickets(int showtimeId)
        {
            return _ticketsRepository.GetAvailableTicketsForShowtime(showtimeId);
        }

        public async Task<Reservation> ReserveTickets(ReservationRequest reservationRequest)
        {
            var tickets = await _ticketsRepository.GetTicketsByIds(reservationRequest.TicketIds);

            var reservation = new Reservation();
            reservation.Tickets = tickets;
            reservation.EndReservationTime = DateTime.UtcNow + _reservationTimeout;

            var result = await _reservationRepository.CreateReservation(reservation);
            return result;
        }

        public async Task<Reservation> CompleteReservation(int reservationId)
        {
            var reservation = await _reservationRepository.GetReservation(reservationId);
            var ticketIds = reservation.Tickets.Select(x => x.Id);
            await _ticketsRepository.MarkTicketsAsSold(ticketIds);
            reservation = await _reservationRepository.MarkReservationAsCompleted(reservationId);
            return reservation;
        }

        public async Task<bool> CancelReservation(int reservationId)
        {
            var reservation = await _reservationRepository.GetReservation(reservationId);
            var ticketIds = reservation.Tickets.Select(x => x.Id);
            await _ticketsRepository.RemoveReservationFromTickets(ticketIds);
            var result = await _reservationRepository.RemoveReservation(reservationId);
            return result;
        }

        public async Task CancelExpiredReservations()
        {
            var reservations = _reservationRepository.GetExpiredReservations();

            foreach (var reservation in reservations)
            {
                await CancelReservation(reservation);
            }
        }

        private async Task<bool> CancelReservation(Reservation reservation)
        {
            var ticketIds = reservation.Tickets.Select(x => x.Id);
            await _ticketsRepository.RemoveReservationFromTickets(ticketIds);
            var result = await _reservationRepository.RemoveReservation(reservation);
            return result;
        }

    }
}
