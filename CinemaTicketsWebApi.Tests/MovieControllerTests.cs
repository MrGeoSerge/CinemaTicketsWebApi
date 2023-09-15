using CinemaTicketsWebApi.Controllers;
using CinemaTicketsWebApi.Models;
using CinemaTicketsWebApi.Services;
using CinemaTicketsWebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace CinemaTicketsWebApi.Tests
{
    public class MovieControllerTests
    {
        ////TODO: Add more tests;
        readonly Mock<IMovieService> _movieService;
        private MovieController _movieController;

        private List<Movie> _movies;

        public MovieControllerTests()
        {
            _movies = new List<Movie>
            {
                new Movie { Id = 1, Title = "Rocky 3", Description = "Some text...", DurationMinutes = 115, Genre = Enums.Genre.Action },
                new Movie { Id = 1, Title = "Rocky 2", Description = "Some text...", DurationMinutes = 110, Genre = Enums.Genre.Action }
            };

            _movieService = new Mock<IMovieService>();

            _movieService.Setup(x => x.GetMovies())
                .ReturnsAsync(_movies);

            _movieController = new MovieController(_movieService.Object);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            var result = _movieController.GetMovies().Result;

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            var result = _movieController.GetMovies().Result as OkObjectResult;

            var items = Assert.IsType<List<Movie>>(result.Value);
            Assert.Equal(_movies.Count, items.Count);

            Assert.IsType<OkObjectResult>(result);
        }
    }
}