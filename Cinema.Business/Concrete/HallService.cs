using Cinema.Business.Abstraction.Extensions;
using Cinema.DataAccess.Abstract;
using Cinema.Entities.Models;

namespace Cinema.Business.Concrete
{
    public class HallService : IExtendedHallService
    {
        private readonly IHallDal _hallDal;

        public HallService(IHallDal hallDal)
        {
            _hallDal = hallDal;
        }

        public async Task AddAsync(Hall entity)
        {
            await _hallDal.AddAsync(entity);
        }

        public async Task DeleteAsync(Hall entity)
        {
            await _hallDal.DeleteAsync(entity);
        }

        public async Task<IEnumerable<Hall>> GetAllAsync()
        {
            return await _hallDal.GetListAsync();
        }

        public async Task<Hall> GetByIdAsync(string id)
        {
            return await _hallDal.GetAsync(h => h.Id == id);
        }

        public async Task UpdateAsync(Hall entity)
        {
            await _hallDal.UpdateAsync(entity);
        }
    }
}
