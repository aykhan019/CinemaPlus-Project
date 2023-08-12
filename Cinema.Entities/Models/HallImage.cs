using Cinema.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Entities.Models
{
    public class HallImage:IEntity
    {
        public string Id { get; set; }

        public string HallId { get; set; }

        public string ImageUrl { get; set; }

        public virtual Hall? Hall { get; set; }
    }
}
