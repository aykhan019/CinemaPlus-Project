using Cinema.Core.Abstract;

namespace Cinema.Entities.Models
{
    /// <summary>
    /// Represents a movie session in a cinema hall.
    /// </summary>
    public class Session : IEntity
    {
        /// <summary>
        /// Gets or sets the ID of the session.
        /// </summary>
        public string? Id { get; set; }

        /// <summary>
        /// Gets or sets the start time of the session.
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Gets or sets the ID of the movie associated with the session.
        /// </summary>
        public string? MovieId { get; set; }

        /// <summary>
        /// Gets or sets the movie associated with the session.
        /// </summary>
        public virtual Movie? Movie { get; set; }

        /// <summary>
        /// Gets or sets the ID of the hall associated with the session.
        /// </summary>
        public string? HallId { get; set; }

        /// <summary>
        /// Gets or sets the hall associated with the session.
        /// </summary>
        public virtual Hall? Hall { get; set; }

        /// <summary>
        /// Gets or sets the list of tickets associated with the session.
        /// </summary>
        public virtual List<Ticket>? Tickets { get; set; }
    }
}
