using Cinema.Business.Abstraction.Extensions;
using Cinema.DataAccess.Concrete.EFEntityFramework;
using Cinema.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Business.Concrete
{
    public class HallImageService : IExtendedHallImageService
    {
        private readonly EFHallImageDal _hallImageDal;

        public HallImageService(EFHallImageDal hallImageDal)
        {
            _hallImageDal = hallImageDal;
        }

        public void Add(HallImage entity)
        {
            _hallImageDal.Add(entity);
        }

        public void Delete(HallImage entity)
        {
            _hallImageDal.Delete(entity);
        }

        public List<HallImage> GetAll()
        {
            return _hallImageDal.GetList();
        }

        public HallImage GetById(string id)
        {
            return _hallImageDal.Get(h => h.Id == id);
        }

        public void Update(HallImage entity)
        {
           _hallImageDal.Update(entity);
        }
    }
}
