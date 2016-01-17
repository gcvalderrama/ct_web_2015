using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoMovies.UnitTest
{
    //aqui reemplazamos la depencia por una falsa implementacion
    public class  ReviewRepositorioMock: 
        IReviewRepositorio
    {
        public ReviewRepositorioMock()
        {

        }
        public List<string> BadWords = new List<string>(); 
        public void CreateReview(Review Model)
        {
            
        }

        public List<string> GetBadWords()
        {
            return BadWords; 
        }
    }


    [TestFixture]
    public class ReviewServiceTest
    {

        [Test]
        public void CreateReviewTest()
        {
            var service = new ReviewService(
                new ReviewRepositorioMock()); 
            var model = new Review(){ Comment = "test"};
            service.CreateReview(model);                
        }
        [Test]
        public void CreateReview_Sapos_Test()
        {

            var repo = new ReviewRepositorioMock();
            repo.BadWords.Add("sapos"); 

            var service = new ReviewService(repo); 

            var model = new Review(){ Comment = "sapos"};
            try
            {
                service.CreateReview(model);
                Assert.Fail("es posible insertar sapos");
            }
            catch (ApplicationException ex)
            {               
                
            }

            
        }
    }
}
