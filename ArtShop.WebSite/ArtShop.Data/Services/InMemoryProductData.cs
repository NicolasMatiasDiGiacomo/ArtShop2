using ArtShop.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ArtShop.Data.Services
{
    public class InMemoryProductData:BaseDataService<Product>
    {

        private List<Product> products;

        public InMemoryProductData()
        {
            products = new List<Product>
            {
                new Product() { Id = 1, Title = "Monalisa", Description = "copia", ArtistId = 10, Image = "monalisa.jpg", Price = 1000, QuantitySold = 2, AvgStars=11, CreatedOn = DateTime.Now, ChangedOn = DateTime.Now },
                new Product() { Id = 3, Title = "JuanXX", Description = "copia", ArtistId = 10, Image = "juanxx.jpg", Price = 2000, QuantitySold = 3, AvgStars=12, CreatedOn = DateTime.Now, ChangedOn = DateTime.Now },
                new Product() { Id = 2, Title = "FernandoXV", Description = "copia", ArtistId = 10, Image = "fernandoxv.jpg", Price = 3000, QuantitySold = 1, AvgStars=10, CreatedOn = DateTime.Now, ChangedOn = DateTime.Now }
            };
        }
        //Especializo la entidad
        public override List<Product> Get(Expression<Func<Product, bool>> whereExpression = null, Func<IQueryable<Product>, IOrderedQueryable<Product>> orderFunction = null, string includeEntities = "")
        {
            return products.OrderBy(o => o.Title).ToList();
        }

    }
}
