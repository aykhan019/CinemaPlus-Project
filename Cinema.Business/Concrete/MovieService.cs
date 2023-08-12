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
    public class MovieService : IExtendedMovieService
    {
        private readonly IMovieDal _movieDal;

        public MovieService(IMovieDal movieDal)
        {
            _movieDal = movieDal;
        }

        public void Add(Movie entity)
        {
           _movieDal.Add(entity);
        }

        public void Delete(Movie entity)
        {
           _movieDal.Delete(entity);
        }

        public List<Movie> GetAll()
        {
            return _movieDal.GetList();
        }

        public Movie GetById(string id)
        {
            return _movieDal.Get(m => m.Id == id);
        }

        public void Update(Movie entity)
        {
            _movieDal.Update(entity);
        }
    }
}
