using Cinema.Core.Abstract;

namespace Cinema.Entities.Models
{
    /// <summary>
    /// Represents a movie.
    /// </summary>
    public class Movie : IEntity
    {
        /// <summary>
        /// Gets or sets the ID of the movie.
        /// </summary>
        public string? Id { get; set; }

        /// <summary>
        /// Gets or sets the title of the movie.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Gets or sets the year of the movie.
        /// </summary>
        public string? Year { get; set; }

        /// <summary>
        /// Gets or sets the release date of the movie.
        /// </summary>
        public string? Released { get; set; }

        /// <summary>
        /// Gets or sets the runtime of the movie.
        /// </summary>
        public string? RunTime { get; set; }

        /// <summary>
        /// Gets or sets the genre of the movie.
        /// </summary>
        public string? Genre { get; set; }

        /// <summary>
        /// Gets or sets the director of the movie.
        /// </summary>
        public string? Director { get; set; }

        /// <summary>
        /// Gets or sets the writer of the movie.
        /// </summary>
        public string? Writer { get; set; }

        /// <summary>
        /// Gets or sets the actors in the movie.
        /// </summary>
        public string? Actors { get; set; }

        /// <summary>
        /// Gets or sets the plot of the movie.
        /// </summary>
        public string? Plot { get; set; }

        /// <summary>
        /// Gets or sets the country of the movie's production.
        /// </summary>
        public string? ProducerCountry { get; set; }

        /// <summary>
        /// Gets or sets the awards received by the movie.
        /// </summary>
        public string? Awards { get; set; }

        /// <summary>
        /// Gets or sets the URL of the movie's poster.
        /// </summary>
        public string? PosterUrl { get; set; }

        /// <summary>
        /// Gets or sets the IMDb rating of the movie.
        /// </summary>
        public string? ImdbRating { get; set; }

        /// <summary>
        /// Gets or sets the price of the movie.
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// Gets or sets the URL of the movie's trailer.
        /// </summary>
        public string? TrailerUrl { get; set; }

        /// <summary>
        /// Gets or sets the age limit of the movie.
        /// </summary>
        public string? AgeLimit { get; set; }

        /// <summary>
        /// Gets or sets the list of languages available for the movie.
        /// </summary>
        public virtual List<Language>? Languages { get; set; }

        /// <summary>
        /// Gets or sets the list of subtitles available for the movie.
        /// </summary>
        public virtual List<Subtitle>? Subtitles { get; set; }
    }
}
