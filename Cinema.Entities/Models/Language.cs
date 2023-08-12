using Cinema.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Entities.Models
{
    public class Language:IEntity
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string FlagUrl { get; set; }
    }
}
