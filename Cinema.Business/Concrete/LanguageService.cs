using Cinema.Business.Abstraction.Extensions;
using Cinema.DataAccess.Abstract;
using Cinema.Entities.Models;

namespace Cinema.Business.Concrete
{
    public class LanguageService : IExtendedLanguageService
    {
        private readonly ILanguageDal _languageDal;

        public LanguageService(ILanguageDal languageDal)
        {
            _languageDal = languageDal;
        }

        public async Task AddAsync(Language entity)
        {
            await _languageDal.AddAsync(entity);
        }

        public async Task DeleteAsync(Language entity)
        {
            await _languageDal.DeleteAsync(entity);
        }

        public async Task<IEnumerable<Language>> GetAllAsync()
        {
            return await _languageDal.GetListAsync();
        }

        public async Task<Language> GetByIdAsync(string id)
        {
            return await _languageDal.GetAsync(l => l.Id == id);
        }

        public async Task<IEnumerable<Language>> GetMovieLanguagesAsync(string movieId)
        {
            return await _languageDal.GetListAsync(l => l.MovieId == movieId);
        }

        public async Task UpdateAsync(Language entity)
        {
            await _languageDal.UpdateAsync(entity);
        }
    }
}
