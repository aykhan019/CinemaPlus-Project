using Cinema.Business.Abstraction.Extensions;
using Cinema.DataAccess.Abstract;
using Cinema.Entities.Models;

namespace Cinema.Business.Concrete
{
    public class SessionService : IExtendedSessionService
    {
        private readonly ISessionDal _sessionDal;

        public SessionService(ISessionDal sessionDal)
        {
            _sessionDal = sessionDal;
        }

        public async Task AddAsync(Session entity)
        {
          await _sessionDal.AddAsync(entity);
        }

        public async Task DeleteAsync(Session entity)
        {
            await _sessionDal.DeleteAsync(entity);
        }

        public async Task<IEnumerable<Session>> GetAllAsync()
        {
            return await _sessionDal.GetListAsync();
        }

        public async Task<Session> GetByIdAsync(string id)
        {
            return await _sessionDal.GetAsync(s => s.Id == id);
        }

        public async Task UpdateAsync(Session entity)
        {
            await _sessionDal.UpdateAsync(entity);
        }
    }
}
