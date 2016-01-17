using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoMovies
{
    public interface IReviewRepositorio
    {
        void CreateReview(Review Model);
        List<string> GetBadWords();
    }

    public class ReviewRepositorio : IReviewRepositorio
    {
        public void CreateReview(Review Model)
        {
            var sql = new SqlConnection();
        }


        public List<string> GetBadWords()
        {
            var sql = new SqlConnection();

            return new List<string>(); 
        }
    }
}
