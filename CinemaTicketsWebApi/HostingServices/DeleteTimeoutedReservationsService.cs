using CinemaTicketsWebApi.Services.Interfaces;
using System.Threading;

namespace CinemaTicketsWebApi.HostingServices
{
    //Hosted service is good for scalability when we have multiple instances
    //We can use redlock to limit service running only on one instanse at a time
    //It is very reliable even if service will be shut down for a while
    public class DeleteTimeoutedReservationsService : IHostedService
    {
        private CancellationTokenSource _cancellationTokenSource;
        private Timer _timer;
        private Task _worker;

        private readonly IBookingService _bookingService;

        public DeleteTimeoutedReservationsService(IBookingService bookingService) 
        {
            _bookingService = bookingService;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _cancellationTokenSource = new CancellationTokenSource();
            _timer = new Timer(RunDeleteTimeoutedReservations, null, TimeSpan.FromMinutes(1), TimeSpan.FromMinutes(1));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _cancellationTokenSource.Cancel();
            _timer?.Dispose();

            return _worker ?? Task.CompletedTask;

        }

        private void RunDeleteTimeoutedReservations(object? state)
        {
            _worker = Task.Run(DeleteTimeoutedReservations, _cancellationTokenSource.Token);
        }

        private async Task DeleteTimeoutedReservations()
        {
            try
            {
                await _bookingService.CancelExpiredReservations();
            }
            catch(Exception ex)
            {
                //TODO: Log exception
            }
        }
    }
}
