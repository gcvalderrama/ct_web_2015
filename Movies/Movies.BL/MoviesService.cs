using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.BL
{
    public class MoviesService :  IMoviesService
    {
        private DAC.IMovieRepositorio MovieRepositorio = new DAC.MovieRepository();
        public IEnumerable<Entities.Movie> GetAll()
        {
            return this.MovieRepositorio.GetAll();              
        }


        public void Create(Entities.Movie Model)
        {
            this.MovieRepositorio.Create(Model);
        }

        public Entities.Movie GetOne(int Id)
        {
            return this.MovieRepositorio.GetOne(Id);
        }


        public void CreateReview(Entities.Review Model)
        {
            this.MovieRepositorio.CreateReview(Model); 
        }
    }
}
