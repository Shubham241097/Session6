using Microsoft.Data.SqlClient;
using Session6.AppDbContext;
using Session6.Models;

namespace Session6.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _productDb;

        public ProductRepository(ProductDbContext productDb)
        {
            _productDb = productDb;
        }

        public List<Product> GetProducts()
        {
            return _productDb.HealthProducts.ToList();
        }
    }
}
