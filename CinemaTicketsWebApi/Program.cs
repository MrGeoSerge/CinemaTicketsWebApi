
using CinemaTicketsWebApi.DataAccess;
using CinemaTicketsWebApi.Repositories;
using CinemaTicketsWebApi.Repositories.Interfaces;
using CinemaTicketsWebApi.Services.Interfaces;
using CinemaTicketsWebApi.Services;
using Microsoft.EntityFrameworkCore;
using CinemaTicketsWebApi.Utilities;
using System.Net;
using CinemaTicketsWebApi.Exceptions;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;

namespace CinemaTicketsWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            ConfigureServices(builder.Services);

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseExceptionHandlingMiddleware(new Dictionary<Type, HttpStatusCode>
            {
                {typeof(ItemNotFoundException), HttpStatusCode.NotFound }
            });

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(options => 
            {
                options.EnableAnnotations();
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Cinema Ticket Booking System API",
                    Description = "Robust and user-friendly API for a cinema ticket booking system. The API will allow users to search for available movies, view showtimes, reserve seats, and complete bookings.",
                });

                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });

            services.AddDbContext<CinemaTicketBookingDbContext>(options
                => options.UseInMemoryDatabase(databaseName: "CinemaTicketBooking"));

            services
                .AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                  {
                      options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                      options.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
                  });

            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped<IShowtimeRepository, ShowtimeRepository>();
            services.AddScoped<ITheaterRepository, TheaterRepository>();
            services.AddScoped<ITicketsRepository, TicketsRepository>();

            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IShowtimeService, ShowtimeService>();
            services.AddScoped<ITheaterService, TheaterService>();
        }

    }
}