using System.Globalization;
using System.Web.Mvc;
using WebMvcEfcf.Utils;

namespace WebMvcEfcf.ValueProviders
{
    public class ProductValueProvider : IValueProvider
    {
        public bool ContainsPrefix(string prefix)
        {
            return prefix.Contains("ProductNumber");
        }

        public ValueProviderResult GetValue(string key)
        {
            if (ContainsPrefix(key))
            {
                return new ValueProviderResult(Service.GetProductNumber(), Service.GetProductNumber(), CultureInfo.InvariantCulture);
            }
            else
            {
                return null;
            }
        }
    }

    public class ProductValueProviderFactory : ValueProviderFactory
    {
        /// <summary>
        /// Este metodo es llamado cuando el model binder quiere obtener valores para realizar el enlace de los datos.
        /// </summary>
        /// <param name="controllerContext"></param>
        /// <returns></returns>
        public override IValueProvider GetValueProvider(ControllerContext controllerContext)
        {
            return new ProductValueProvider();
        }
    }
}