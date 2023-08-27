using Cinema.Core.Abstract;

namespace Cinema.Entities.Models
{
    /// <summary>
    /// Represents a hall in a theater.
    /// </summary>
    public class Hall : IEntity
    {
        /// <summary>
        /// Gets or sets the ID of the hall.
        /// </summary>
        public string? Id { get; set; }

        /// <summary>
        /// Gets or sets the ID of the theater to which the hall belongs.
        /// </summary>
        public string? TheatreId { get; set; }

        /// <summary>
        /// Gets or sets the name of the hall.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the list of seats in the hall.
        /// </summary>
        public virtual List<Seat>? Seats { get; set; }

        public Hall()
        {
            Seats = new List<Seat>();
        }
    }
}
