using Movies.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.BL
{
    public interface IMoviesService
    {
        Movie GetOne(int Id);
        IEnumerable<Movie> GetAll();
        void Create(Movie Model);
        void CreateReview(Review Model);

        IList<Movie> SearchMovies(string Filter);

    }
}
