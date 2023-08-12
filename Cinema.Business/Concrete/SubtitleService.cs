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
    public class SubtitleService : IExtendedSubtitleService
    {
        private readonly ISubtitleDal _subtitleDal;

        public SubtitleService(ISubtitleDal subtitleDal)
        {
            _subtitleDal = subtitleDal;
        }

        public void Add(Subtitle entity)
        {
            _subtitleDal.Add(entity);
        }

        public void Delete(Subtitle entity)
        {
            _subtitleDal.Delete(entity);
        }

        public List<Subtitle> GetAll()
        {
            return _subtitleDal.GetList();
        }

        public Subtitle GetById(string id)
        {
            return _subtitleDal.Get(s => s.Id == id);
        }

        public void Update(Subtitle entity)
        {
            _subtitleDal.Update(entity);
        }
    }
}
