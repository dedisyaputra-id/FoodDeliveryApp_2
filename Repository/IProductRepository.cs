using Microsoft.AspNetCore.Mvc;
using webapifirst.Models;

namespace webapifirst.Repository
{
    public interface IProductRepository
    {
        List<ProductDTO> Get();
        ProductDTO GetById(string id);
        void Add(Product model);
        Product Delete(string id);

        void SaveChanges();
    }
}
