using webapifirst.Models;

namespace webapifirst.Service
{
    public interface ICategoryService
    {
        List<Category> Get();
        Category GetById(string id);
        void Add(CategoryDTO model);
        Category UpdateDlt(string id);
    }
}
