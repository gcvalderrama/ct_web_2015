using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DemoSeguridad
{
    class Program
    {
        static void Main(string[] args)
        {
            //ha ha show mvc security
        // https://channel9.msdn.com/Events/MIX/MIX10/FT05
            AppDomain.CurrentDomain.SetPrincipalPolicy(
                System.Security.Principal.PrincipalPolicy.UnauthenticatedPrincipal);

            GenericIdentity Identity = new GenericIdentity("SuperUsuario");
            GenericPrincipal Principal = new GenericPrincipal(Identity, new string[] { "Administradores"});

            System.Threading.Thread.CurrentPrincipal = Principal;

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
