using Cinema.Core.Abstract;

namespace Cinema.Entities.Models
{
    /// <summary>
    /// Represents a language used for movies.
    /// </summary>
    public class Language : IEntity
    {
        /// <summary>
        /// Gets or sets the ID of the language.
        /// </summary>
        public string? Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the language.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the URL of the flag associated with the language.
        /// </summary>
        public string? FlagUrl { get; set; }

        /// <summary>
        /// Gets or sets the ID of the movie associated with the language.
        /// </summary>
        public string? MovieId { get; set; }

        /// <summary>
        /// Gets or sets the movie associated with the language.
        /// </summary>
        public virtual Movie? Movie { get; set; }
    }
}
