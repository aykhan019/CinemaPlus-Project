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
    public class TheatreImageService : IExtendedTheatreImageService
    {
        private readonly EFTheatreImageDal _hallImageDal;

        public TheatreImageService(EFTheatreImageDal hallImageDal)
        {
            _hallImageDal = hallImageDal;
        }

        public void Add(TheatreImage entity)
        {
            _hallImageDal.Add(entity);
        }

        public void Delete(TheatreImage entity)
        {
            _hallImageDal.Delete(entity);
        }

        public List<TheatreImage> GetAll()
        {
            return _hallImageDal.GetList();
        }

        public TheatreImage GetById(string id)
        {
            return _hallImageDal.Get(h => h.Id == id);
        }

        public void Update(TheatreImage entity)
        {
           _hallImageDal.Update(entity);
        }
    }
}
