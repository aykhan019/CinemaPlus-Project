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
    public class SeatService : IExtendedSeatService
    {
        private readonly ISeatDal _seatDal;

        public SeatService(ISeatDal seatDal)
        {
            _seatDal = seatDal;
        }

        public void Add(Seat entity)
        {
            _seatDal.Add(entity);
        }

        public void Delete(Seat entity)
        {
            _seatDal.Delete(entity);
        }

        public List<Seat> GetAll()
        {
            return _seatDal.GetList();
        }

        public Seat GetById(string id)
        {
            return _seatDal.Get(s => s.Id == id);
        }

        public void Update(Seat entity)
        {
            _seatDal.Update(entity);
        }
    }
}
