using Microsoft.EntityFrameworkCore;
using webapifirst.Models;

namespace webapifirst.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly FoodDeliveryContext _db;
        public ProductRepository(FoodDeliveryContext context) 
        {
            _db = context;
        }

        public List<ProductDTO> Get() 
        {
            var products = _db.Products
                                  .Where(d => d.dlt == 0 && d.Category.dlt == 0)
                                  .Select(p => new ProductDTO
                                  {
                                     ProductName = p.ProductName,
                                     ProductId = p.ProductId,
                                      ProductDescription = p.ProductDescription,
                                      ProductPrice = p.ProductPrice,
                                      ProductCount = p.ProductCount,
                                      CategoryName = p.Category.Name,
                                  }).ToList();

            return products;
        }

        public ProductDTO GetById(string id)
        {
            var product = _db.Products
                .Select(p => new ProductDTO
                {
                    ProductId = p.ProductId,
                    CategoryId = p.CategoryId,
                    ProductName = p.ProductName,
                    ProductDescription = p.ProductDescription,
                    ProductCount = p.ProductCount,
                    ProductPrice = p.ProductPrice,
                    CategoryName = p.Category.Name
                }).FirstOrDefault(s => s.ProductId == id);
            return product;
        }

        public void Add(Product product)
        {
            _db.Products.Add(product);
        }
        public Product Delete(string id)
        {
            return _db.Products.Find(id);
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}
