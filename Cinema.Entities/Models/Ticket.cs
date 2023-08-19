using Cinema.Core.Abstract;

namespace Cinema.Entities.Models
{
    /// <summary>
    /// Represents a ticket for a movie session.
    /// </summary>
    public class Ticket : IEntity
    {
        /// <summary>
        /// Gets or sets the ID of the ticket.
        /// </summary>
        public string? Id { get; set; }

        /// <summary>
        /// Gets or sets the ID of the session associated with the ticket.
        /// </summary>
        public string? SessionId { get; set; }

        /// <summary>
        /// Gets or sets the session associated with the ticket.
        /// </summary>
        public virtual Session? Session { get; set; }

        /// <summary>
        /// Gets or sets the purchase date of the ticket.
        /// </summary>
        public DateTime PurchaseDate { get; set; }

        /// <summary>
        /// Gets or sets the email associated with the ticket.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Gets or sets the phone number associated with the ticket.
        /// </summary>
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the payment method used for the ticket.
        /// </summary>
        public string? Payment { get; set; }

        /// <summary>
        /// Gets or sets the card number used for payment.
        /// </summary>
        public string? CardNumber { get; set; }
    }
}
