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
    public class SessionService : IExtendedSessionService
    {
        private readonly ISessionDal _sessionDal;

        public SessionService(ISessionDal sessionDal)
        {
            _sessionDal = sessionDal;
        }

        public void Add(Session entity)
        {
            _sessionDal.Add(entity);
        }

        public void Delete(Session entity)
        {
            _sessionDal.Delete(entity); 
        }

        public List<Session> GetAll()
        {
            return _sessionDal.GetList();
        }

        public Session GetById(string id)
        {
            return _sessionDal.Get(s => s.Id == id);
        }

        public void Update(Session entity)
        {
            _sessionDal.Update(entity);
        }
    }
}
