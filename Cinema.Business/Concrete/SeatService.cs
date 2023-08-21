using Cinema.Business.Abstraction.Extensions;
using Cinema.DataAccess.Abstract;
using Cinema.Entities.Models;

namespace Cinema.Business.Concrete
{
    public class SeatService : IExtendedSeatService
    {
        private readonly ISeatDal _seatDal;

        public SeatService(ISeatDal seatDal)
        {
            _seatDal = seatDal;
        }

        public async Task AddAsync(Seat entity)
        {
            await _seatDal.AddAsync(entity);
        }

        public async Task DeleteAsync(Seat entity)
        {
            await _seatDal.DeleteAsync(entity);
        }

        public async Task<IEnumerable<Seat>> GetAllAsync()
        {
            return await _seatDal.GetListAsync();
        }

        public async Task<Seat> GetByIdAsync(string id)
        {
            return await _seatDal.GetAsync(s => s.Id == id);
        }

        public async Task UpdateAsync(Seat entity)
        {
            await _seatDal.UpdateAsync(entity);
        }
    }
}
