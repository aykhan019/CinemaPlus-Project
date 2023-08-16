using Cinema.Core.Abstract;

namespace Cinema.Entities.Models
{
    /// <summary>
    /// Represents a seat in a cinema hall.
    /// </summary>
    public class Seat : IEntity
    {
        /// <summary>
        /// Gets or sets the ID of the seat.
        /// </summary>
        public string? Id { get; set; }

        /// <summary>
        /// Gets or sets the seat number.
        /// </summary>
        public string? Number { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the seat is available.
        /// </summary>
        public bool IsAvailable { get; set; }

        /// <summary>
        /// Gets or sets the ID of the session associated with the seat.
        /// </summary>
        public string? SessionId { get; set; }

        /// <summary>
        /// Gets or sets the session associated with the seat.
        /// </summary>
        public virtual Session? Session { get; set; }
    }
}
