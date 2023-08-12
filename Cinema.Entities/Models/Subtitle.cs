using Cinema.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Entities.Models
{
    public class Subtitle:IEntity
    {
        public string Id { get; set; }

        public string MovieId { get; set; }
        public string ImageUrl { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
