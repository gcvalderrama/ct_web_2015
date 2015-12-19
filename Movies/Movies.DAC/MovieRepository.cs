using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.DAC
{
    public class MovieRepository :  IMovieRepositorio
    {
        private string ConnectionString = null; 
        public MovieRepository()
        {
            this.ConnectionString = ConfigurationManager.ConnectionStrings["Movies"].ConnectionString;
        }
        public IEnumerable<Entities.Movie> GetAll()
        {
            
                
        }

        public Entities.Movie GetOne(int Id)
        {
           
        }


        public int Count()
        {
            int result = 0; 
            using (var con = new SqlConnection(this.ConnectionString))
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = "usp_movies_count";
                cmd.CommandType = System.Data.CommandType.StoredProcedure; 
                con.Open();
                result = (int)cmd.ExecuteScalar();                
            }
            return result; 
        }
    }
}
