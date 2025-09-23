using webapifirst.Models;
using webapifirst.Repository;

namespace webapifirst.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        public CategoryService(ICategoryRepository repository) 
        {
            _repository = repository;
        }

        public List<Category> Get()
        {
            var categories = _repository.Get();
            return categories;
        }

        public Category GetById(string id)
        {
            var category = _repository.GetById(id);
            return category;
        }

        public void Add(CategoryDTO model)
        {
            var oObject = new Category();
            if (string.IsNullOrEmpty(Convert.ToString(model.CategoryId)))
            {
                oObject.CategoryId = Convert.ToString(Guid.NewGuid());
                oObject.OpAdd = "Admin";
                oObject.PcAdd = Environment.MachineName;
                oObject.DateAdd = DateTime.Now;

                _repository.Add(oObject);
            }
            else
            {
                oObject = _repository.GetById(Convert.ToString(model.CategoryId));
                if (oObject != null)
                {
                    oObject.OpEdit = "admin";
                    oObject.PcEdit = Environment.MachineName;
                    //oObject.DateEdit = DateTime.Now;
                }
            }
            if (oObject != null)
            {
                oObject.Name = model.Name;
            }
            _repository.SaveChanges();
        }

        public Category UpdateDlt(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }
            var oObject = _repository.GetById(id);
            if (oObject != null)
            {
                oObject.dlt = 1;
                oObject.OpEdit = "admin";
                oObject.PcEdit = Environment.MachineName;
                //oObject.DateEdit = Convert.ToString(DateTime.Now);
                _repository.SaveChanges();
                return oObject;
            }
            else
            {
                return null;
            }
        } 
    }
}
