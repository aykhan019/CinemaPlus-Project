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

        public async Task AdjustSessionDatesToNextWeekAsync()
        {
            var sessions = await _sessionDal.GetListAsync();

            if (sessions != null && sessions.Count() > 0)
            {
                var oldestSession = sessions.OrderByDescending(s => s.StartTime).FirstOrDefault()!;

                var firstAddedSessionDate = new DateTime(2023, 8, 23);

                if (oldestSession.StartTime != firstAddedSessionDate)
                {
                    int dayDifference = (DateTime.Now - firstAddedSessionDate).Days;

                    foreach (var session in sessions)
                    {
                        session.StartTime = session.StartTime.AddDays(dayDifference);
                        await _sessionDal.UpdateAsync(session);
                    }
                }
            }
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
