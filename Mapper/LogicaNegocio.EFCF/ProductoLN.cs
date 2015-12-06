using AccesoDatos.EFCF;
using Entidades.EFCF;
using System.Collections.Generic;

namespace LogicaNegocio.EFCF
{
    public class ProductoLN
    {
        ProductDAO prodDAO = new ProductDAO();

        public IEnumerable<ProductModel> GetProductModels()
        {
            return prodDAO.GetProductModels();
        }

        public IEnumerable<ProductSubcategory> GetProductSubsctegories()
        {
            return prodDAO.GetProductSubsctegories();
        }

        public IEnumerable<UnitMeasure> GetUnitMeasures()
        {
            return prodDAO.GetUnitMeasures();
        }

        public IEnumerable<Product> SelectAll()
        {
            return prodDAO.SelectAll();
        }

        public Product Select(Product producto)
        {
            return prodDAO.Select(producto);
        }

        public int Insert(Product producto)
        {
            return prodDAO.Insert(producto);
        }

        public bool Update(Product producto)
        {
            return prodDAO.Update(producto);
        }

        public bool Delete(Product producto)
        {
            return prodDAO.Delete(producto);
        }
    }
}
