using Cinema.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Entities.Models
{
    public class Session:IEntity
    {
        public string Id { get; set; }
        public DateTime StartTime { get; set; }
        public string MovieId { get; set; }
        public virtual Movie? Movie { get; set; }
        public string HallId { get; set; }
        public virtual Hall? Hall { get; set; }
        public List<Ticket> Tickets { get; set; }
    }
}
