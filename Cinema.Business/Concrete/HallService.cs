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
    public class HallService : IExtendedHallService
    {
        private readonly IHallDal _hallDal;

        public HallService(IHallDal hallDal)
        {
            _hallDal = hallDal;
        }

        public void Add(Hall entity)
        {
            _hallDal.Add(entity);
        }

        public void Delete(Hall entity)
        {
            _hallDal.Delete(entity);
        }

        public List<Hall> GetAll()
        {
            return _hallDal.GetList();
        }

        public Hall GetById(string id)
        {
            return _hallDal.Get(h => h.Id == id);
        }

        public void Update(Hall entity)
        {
            _hallDal.Update(entity);
        }
    }
}
