using Cinema.Business.Abstraction.Extensions;
using Cinema.DataAccess.Abstract;
using Cinema.Entities.Models;

namespace Cinema.Business.Concrete
{
    public class SubtitleService : IExtendedSubtitleService
    {
        private readonly ISubtitleDal _subtitleDal;

        public SubtitleService(ISubtitleDal subtitleDal)
        {
            _subtitleDal = subtitleDal;
        }

        public async Task AddAsync(Subtitle entity)
        {
            await _subtitleDal.AddAsync(entity);
        }

        public async Task DeleteAsync(Subtitle entity)
        {
            await _subtitleDal.DeleteAsync(entity);
        }

        public async Task<IEnumerable<Subtitle>> GetAllAsync()
        {
            return await _subtitleDal.GetListAsync();
        }

        public async Task<Subtitle> GetByIdAsync(string id)
        {
            return await _subtitleDal.GetAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Subtitle>> GetMovieSubtitles(string movieId)
        {
            return await _subtitleDal.GetListAsync(s => s.MovieId == movieId);
        }

        public async Task UpdateAsync(Subtitle entity)
        {
            await _subtitleDal.UpdateAsync(entity);
        }
    }
}
