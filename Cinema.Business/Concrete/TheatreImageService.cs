using Cinema.Business.Abstraction.Extensions;
using Cinema.DataAccess.Abstract;
using Cinema.Entities.Models;

namespace Cinema.Business.Concrete
{
    public class TheatreImageService : IExtendedTheatreImageService
    {
        private readonly ITheatreImageDal _hallImageDal;

        public TheatreImageService(ITheatreImageDal hallImageDal)
        {
            _hallImageDal = hallImageDal;
        }

        public async Task AddAsync(TheatreImage entity)
        {
            await _hallImageDal.AddAsync(entity);
        }

        public async Task DeleteAsync(TheatreImage entity)
        {
            await _hallImageDal.DeleteAsync(entity);
        }

        public async Task<IEnumerable<TheatreImage>> GetAllAsync()
        {
            return await _hallImageDal.GetListAsync();
        }

        public async Task<TheatreImage> GetByIdAsync(string id)
        {
            return await _hallImageDal.GetAsync(t => t.Id == id);
        }

        public async Task UpdateAsync(TheatreImage entity)
        {
            await _hallImageDal.UpdateAsync(entity);
        }
    }
}
