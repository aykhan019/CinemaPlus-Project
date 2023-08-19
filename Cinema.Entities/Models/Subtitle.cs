using Cinema.Core.Abstract;

namespace Cinema.Entities.Models
{
    /// <summary>
    /// Represents a subtitle associated with a movie.
    /// </summary>
    public class Subtitle : IEntity
    {
        /// <summary>
        /// Gets or sets the ID of the subtitle.
        /// </summary>
        public string? Id { get; set; }

        /// <summary>
        /// Gets or sets the URL of the subtitle's image.
        /// </summary>
        public string? ImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the ID of the movie associated with the subtitle.
        /// </summary>
        public string? MovieId { get; set; }

        /// <summary>
        /// Gets or sets the movie associated with the subtitle.
        /// </summary>
        public virtual Movie? Movie { get; set; }
    }
}
