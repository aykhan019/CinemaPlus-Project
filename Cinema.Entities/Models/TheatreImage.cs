using Cinema.Core.Abstract;

namespace Cinema.Entities.Models
{
    /// <summary>
    /// Represents an image associated with a theatre.
    /// </summary>
    public class TheatreImage : IEntity
    {
        /// <summary>
        /// Gets or sets the ID of the theatre image.
        /// </summary>
        public string? Id { get; set; }

        /// <summary>
        /// Gets or sets the URL of the image.
        /// </summary>
        public string? ImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the ID of the theatre associated with the image.
        /// </summary>
        public string? TheatreId { get; set; }

        /// <summary>
        /// Gets or sets the theatre associated with the image.
        /// </summary>
        public virtual Theatre? Theatre { get; set; }
    }
}
