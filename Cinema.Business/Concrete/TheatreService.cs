using Cinema.Business.Abstraction.Extensions;
using Cinema.DataAccess.Abstract;
using Cinema.Entities.Models;

namespace Cinema.Business.Concrete
{
    public class TheatreService : IExtendedTheatreService
    {
        private readonly ITheatreDal _theatreDal;

        public TheatreService(ITheatreDal theatreDal)
        {
            _theatreDal = theatreDal;
        }

        public async Task AddAsync(Theatre entity)
        {
            await _theatreDal.AddAsync(entity);
        }

        public async Task DeleteAsync(Theatre entity)
        {
            await _theatreDal.DeleteAsync(entity);
        }

        public async Task<IEnumerable<Theatre>> GetAllAsync()
        {
            return await _theatreDal.GetListAsync();
        }

        public async Task<Theatre> GetByIdAsync(string id)
        {
            return await _theatreDal.GetAsync(t => t.Id == id);
        }

        public async Task UpdateAsync(Theatre entity)
        {
            await _theatreDal.UpdateAsync(entity);
        }
    }
}
