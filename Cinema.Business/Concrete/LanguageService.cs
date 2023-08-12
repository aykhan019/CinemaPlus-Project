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
    public class LanguageService : IExtendedLanguageService
    {
        private readonly ILanguageDal _languageDal;

        public LanguageService(ILanguageDal languageDal)
        {
            _languageDal = languageDal;
        }

        public void Add(Language entity)
        {
            _languageDal.Add(entity);
        }

        public void Delete(Language entity)
        {
            _languageDal.Delete(entity);
        }

        public List<Language> GetAll()
        {
            return _languageDal.GetList();
        }

        public Language GetById(string id)
        {
            return _languageDal.Get(l => l.Id == id);
        }

        public void Update(Language entity)
        {
            _languageDal.Update(entity);
        }
    }
}
