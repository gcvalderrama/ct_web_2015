using Movies.DAC;
using Movies.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.BL
{
    public class MoviesService :  IMoviesService
    {
        private DAC.IMovieRepositorio MovieRepositorio;

        private DAC.IGrammarService GrammarService; 


        public MoviesService(IMovieRepositorio MovieRepositorio, 
            IGrammarService  GrammarService
            )
        {
            this.GrammarService = GrammarService; 
            this.MovieRepositorio = MovieRepositorio; 
        }

        
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

        public IList<Movie> SearchMovies(string Filter)
        {
            var result = this.MovieRepositorio.Search(Filter);


            return result; 
        }
        public void CreateReview(Entities.Review Model)
        {
            var words = this.GrammarService.GetBadWords(); 
            var badwords = words.Where( c=> Model.Comment.Contains(c)).ToList();
            if (badwords.Count() > 0)
            {
                StringBuilder  sb  = new StringBuilder(); 
                foreach (var item in badwords)
	            {
                    sb.AppendLine(item);		 
	            }


                throw new ApplicationException(
                    string.Format("this comment is not valid, because contains this bad word {0}", 
                        sb.ToString()
                    ));
            }
            this.MovieRepositorio.CreateReview(Model); 
        }
    }
}
