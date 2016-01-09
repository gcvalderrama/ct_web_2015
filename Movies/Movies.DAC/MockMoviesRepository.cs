using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.DAC
{
    public class MockMoviesRepository : IMovieRepositorio
    {
        public IEnumerable<Entities.Movie> GetAll()
        {
            return new List<Entities.Movie>() { 
                new Entities.Movie(){ Id = 1, Title = "Mock" }
            };
        }

        public Entities.Movie GetOne(int Id)
        {
            throw new NotImplementedException();
        }

        public void Create(Entities.Movie Model)
        {
            throw new NotImplementedException();
        }

        public void CreateReview(Entities.Review Model)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }
    }
}
