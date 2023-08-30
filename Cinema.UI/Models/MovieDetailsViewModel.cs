using Cinema.Entities.Models;

namespace CinemaPlusMovieDetails.Models
{
    public class MovieDetailsViewModel
    {
        public Movie? Movie { get; set; }
        public List<Session>? MovieSessions { get; set; }
        public List<Movie>? AnotherMovies { get; set; }
        public List<DateTime>? SessionDates { get; set; }
        public List<Theatre>? Theatres { get; set; }
        public List<string>? Languages { get; set; }
    }
}
