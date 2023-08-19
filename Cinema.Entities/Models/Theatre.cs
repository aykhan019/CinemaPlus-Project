using Cinema.Core.Abstract;

namespace Cinema.Entities.Models
{
    /// <summary>
    /// Represents a theatre where movies are shown.
    /// </summary>
    public class Theatre : IEntity
    {
        /// <summary>
        /// Gets or sets the ID of the theatre.
        /// </summary>
        public string? Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the theatre.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the location of the theatre.
        /// </summary>
        public string? Location { get; set; }

        /// <summary>
        /// Gets or sets the description of the theatre.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the URL of the theatre's image.
        /// </summary>
        public string? ImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the theatre.
        /// </summary>
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the list of theatre images associated with the theatre.
        /// </summary>
        public virtual List<TheatreImage>? TheatreImages { get; set; }
    }
}
