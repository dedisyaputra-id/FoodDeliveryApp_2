using webapifirst.Models;

namespace webapifirst.Service
{
    public interface IProductService
    {
        List<ProductDTO> Get();
        ProductDTO GetById(string id);
        void Add(ProductDTO model);
        Product Delete(string id);
    }
}
