using Entidades.EFCF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AccesoDatos.EFCF
{
    public class ProductDAO : IDisposable
    {
        AdventureWorksContext context = new AdventureWorksContext();

        public IEnumerable<ProductModel> GetProductModels()
        {
            var productoModels = context.ProductModels;
            return productoModels.ToList();
        }

        public IEnumerable<ProductSubcategory> GetProductSubsctegories()
        {
            var productSubcategories = context.ProductSubcategories;
            return productSubcategories.ToList();
        }

        public IEnumerable<UnitMeasure> GetUnitMeasures()
        {
            var unitMeasures = context.UnitMeasures;
            return unitMeasures.ToList();
        }

        public IEnumerable<Product> SelectAll()
        {
            var productos = context.Products.Include("ProductSubcategory");
            return productos.ToList();
        }
        public Product Select(Product producto)
        {
            var p = context.Products.Where(prods => prods.ProductID == producto.ProductID);
            return p.SingleOrDefault();
        }

        public int Insert(Product producto)
        {
            context.Products.Add(producto);
            return context.SaveChanges();
        }

        public bool Update(Product producto)
        {
            //Ya que el objeto producto fue creado fuera del contexto, es necesario indicarle al EF que lo agregue,
            //para esto se usa Attach.
            context.Products.Attach(producto);
            context.Entry(producto).State = EntityState.Modified;
            context.Entry(producto).Property("RowGuid").IsModified = false;
            return (context.SaveChanges() != 0);
        }

        public bool Delete(Product producto)
        {
            //Ya que el objeto producto fue creado fuera del contexto, es necesario indicarle al EF que lo agregue,
            //para esto se usa Attach.
            context.Products.Attach(producto);
            context.Products.Remove(producto);
            return (context.SaveChanges() != 0);
        }

        public void Dispose()
        {
            if (context != null) context.Dispose();
        }
    }
}
