using NorthwindSimpleClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindSimpleClient
{


    class Program
    {
        static void Helper(IEnumerable<Region> Regiones)
        {
            foreach (var item in Regiones)
            {
                Console.WriteLine("##############");
                Console.WriteLine(item.RegionDescription);
                foreach (var terr in item.Territories)
                {
                    Console.WriteLine(terr.TerritoryDescription);
                }
            }
        }

        static void DemoLoad()
        {
            using (var context = new Model.NorthwindDataModel())
            {
                var regiones = (from c in context.Regions.Include("Territories")
                                select c).ToList();
                Helper(regiones);
            }

        }
        static void Main(string[] args)
        {
            using (var context = new Model.NorthwindDataModel())
            {

                var rr = (from c in context.Regions
                          select c.RegionID).Max();


                context.Database.Log = (s) =>
                {
                    Console.WriteLine(s); 
                };

                var region = (from c in context.Regions
                             where c.RegionID == 5
                             select c).FirstOrDefault();


                context.Regions.Remove(region);
                context.SaveChanges();
                Console.WriteLine(region.RegionID); 
            }
        


        }
    }
}
