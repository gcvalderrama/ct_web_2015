using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalApp.UnitTest
{
    [TestFixture]
    public class SumarServicioTest 
    {
        [Test]
        public void SumarCase ()
        {
            var service = new Servicios.CalculadoraServicio();
            Assert.AreEqual(service.Sumar(4, 5), 9); 
        }
    }
}
