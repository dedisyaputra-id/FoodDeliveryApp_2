using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Security.Claims;
using webapifirst.Models;
using webapifirst.Repository;

namespace webapifirst.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repo)
        {
            _repository = repo;
        }

        public List<ProductDTO> Get()
        {
             return _repository.Get();
        }

        public ProductDTO GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }
            else
            {
                return _repository.GetById(id);
            }
        }
        
        public void Add(ProductDTO model)
        {
            var oObject = new Product();
            if (string.IsNullOrEmpty(Convert.ToString(model.ProductId)))
            {
                oObject.ProductId = Convert.ToString(Guid.NewGuid());
                oObject.opAdd = "admin";
                oObject.pcAdd = Environment.MachineName;
                oObject.dateAdd = DateTime.Now;
                oObject.dlt = 0;
                _repository.Add(oObject);
            }
            else
            {
                //oObject = _repository.GetById(Convert.ToString(model.ProductId));
                if (oObject != null)
                {
                    oObject.opEdit = "admin";
                    oObject.pcEdit = Environment.MachineName;
                    oObject.dateEdit = DateTime.Now;
                }
            }
            if (oObject != null)
            {
                oObject.ProductName = model.ProductName;
                oObject.ProductDescription = model.ProductDescription;
                oObject.ProductPrice = Convert.ToInt32(model.ProductPrice);
                oObject.ProductCount = Convert.ToInt32(model.ProductCount);
                oObject.CategoryId = Convert.ToString(model.CategoryId);
            }
           _repository.SaveChanges();
        }

        public Product Delete(string id) 
        {
            if (string.IsNullOrEmpty(id))
            {
                return new Product();
            }
            var oObject = _repository.Delete(id);
            if (oObject != null)
            {
                oObject.dlt = 1;
                oObject.opEdit = "admin";
                oObject.pcEdit= Environment.MachineName;
                oObject.dateEdit = DateTime.Now;

                _repository.SaveChanges();

                return oObject;
            }
            else
            {
                return new Product();
            }
        }

    }
}
