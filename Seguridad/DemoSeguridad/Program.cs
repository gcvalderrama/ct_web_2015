using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSeguridad
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.SetPrincipalPolicy(
                System.Security.Principal.PrincipalPolicy.WindowsPrincipal);

            var seg = 
                System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            var segnet =
                System.Threading.Thread.CurrentPrincipal.Identity.Name;

            Console.WriteLine(seg);
            Console.WriteLine(segnet);

            if (System.Threading.Thread.CurrentPrincipal.IsInRole("Administradores"))
                Console.WriteLine("Bienvenido Administrator");

            Console.ReadLine();

        }
    }
}
