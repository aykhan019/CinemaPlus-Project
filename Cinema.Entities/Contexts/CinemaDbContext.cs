using Cinema.Entities.Helpers;
using Cinema.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Entities.Contexts
{
    public class CinemaDbContext:DbContext
    {

        public CinemaDbContext()
        {

        }

        public CinemaDbContext(DbContextOptions<CinemaDbContext> options)
            : base(options) 
        {
           
        }

        /// <summary>
        /// Overrides the default configuration of the DbContext options.
        /// Sets the database connection based on the appsettings.json file.
        /// </summary>
        /// <param name="optionsBuilder">The DbContext options builder.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configBuilder = new ConfigurationBuilder()
                        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                        .AddJsonFile(Constants.AppSettingsFile, optional: true, reloadOnChange: true);

                IConfiguration configuration = configBuilder.Build();

                // Read the connection string
                string? connectionString = configuration.GetConnectionString(Constants.Default);

                optionsBuilder.UseSqlServer(connectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Hall>? Halls { get; set; }
        public DbSet<TheatreImage>? TheatreImages { get; set; }
        public DbSet<Language>? Languages { get; set; }
        public DbSet<Movie>? Movies { get; set; }
        public DbSet<Seat>? Seats { get; set; }
        public DbSet<Session>? Sessions { get; set; }
        public DbSet<Subtitle>? Subtitles { get; set; }
        public DbSet<Theatre>? Theatres { get; set; }
        public DbSet<Ticket>? Tickets { get; set; }
    }
}
