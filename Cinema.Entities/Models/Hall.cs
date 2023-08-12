using Cinema.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Entities.Models
{
    public class Hall:IEntity
    {
        public string Id { get; set; }

        public string TheatreId { get; set; }

        public string Name { get; set; }

        public List<Seat> Seats { get; set; }

        public List<HallImage> HallImages { get; set; }
    }
}
