using Movies.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.DAC
{
    public interface IMovieRepositorio
    {
        IEnumerable<Movie> GetAll();
        Movie GetOne(int Id);
        void Create(Movie Model);
        void CreateReview(Review Model); 
        int Count();
        IList<Movie> Search(string Filter);

        
    }
}
