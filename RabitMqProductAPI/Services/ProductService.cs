using RabitMqProductAPI.Data;
using RabitMqProductAPI.Model;

namespace RabitMqProductAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly DbContextClass _dbContext;
        public ProductService(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }
        public Product AddProduct(Product product)
        {
            var result = _dbContext.products.Add(product);
            _dbContext.SaveChanges();
            return result.Entity;
        }

        public bool DeleteProduct(int Id)
        {
            var filteredData = _dbContext.products.Where(x => x.ProductId == Id).FirstOrDefault();
            var result = _dbContext.Remove(filteredData);
            _dbContext.SaveChanges();
            return result != null ? true : false;
        }

        public Product GetProductById(int id)
        {
            return _dbContext.products.Where(x => x.ProductId == id).FirstOrDefault();
        }

        public IEnumerable<Product> GetProductList()
        {
            return _dbContext.products.ToList();
        }

        public Product UpdateProduct(Product product)
        {
            var result = _dbContext.products.Update(product);
            _dbContext.SaveChanges();
            return result.Entity;
        }
    }
}
