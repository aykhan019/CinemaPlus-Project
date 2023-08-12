using Cinema.Business.Abstraction.Extensions;
using Cinema.DataAccess.Abstract;
using Cinema.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Business.Concrete
{
    public class TheatreService : IExtendedTheatreService
    {
        private readonly ITheatreDal _theatreDal;

        public TheatreService(ITheatreDal theatreDal)
        {
            _theatreDal = theatreDal;
        }

        public void Add(Theatre entity)
        {
            _theatreDal.Add(entity);
        }

        public void Delete(Theatre entity)
        {
            _theatreDal.Delete(entity);
        }

        public List<Theatre> GetAll()
        {
            return _theatreDal.GetList();
        }

        public Theatre GetById(string id)
        {
            return _theatreDal.Get(t => t.Id == id);
        }

        public void Update(Theatre entity)
        {
            _theatreDal.Update(entity);
        }
    }
}
