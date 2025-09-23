using webapifirst.Models;

namespace webapifirst.Repository
{
    public interface ICategoryRepository
    {
        List<Category> Get();
        Category GetById(string id);
        void Add(Category model);
        void SaveChanges();
    }
}
