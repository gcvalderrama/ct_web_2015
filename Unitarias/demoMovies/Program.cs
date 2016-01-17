using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoMovies
{
    public class Review
    {
        public string Comment { get; set; }

    }

    public class  ReviewService
    {
        private IReviewRepositorio Repositorio; 
        public ReviewService(IReviewRepositorio  Repositorio)
        {
            this.Repositorio = Repositorio; 
        }
        public  void CreateReview(Review Model)
        {
            var bw = this.Repositorio.GetBadWords(); 

            if ( bw.Contains( Model.Comment) )
            {
                throw new ApplicationException("frase no permitida"); 
            }
            this.Repositorio.CreateReview(Model); 
            
            //
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var rev = new Review() { Comment = "El senior de los anillos es chevere" };
            
            var service = new ReviewService(new ReviewRepositorio());

            service.CreateReview(rev); 


        }
    }
}
