using webapifirst.Models;

namespace webapifirst.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly FoodDeliveryContext _db;
        public CategoryRepository(FoodDeliveryContext db) 
        {
            _db = db;
        }

        public List<Category> Get()
        {
            var categories = _db.Categories.Where(c => c.dlt == 0).ToList();
            return categories;
        }

        public Category GetById(string id)
        {
            var category = _db.Categories.Find(id);
            return category;
        }

        public void Add(Category category)
        { 
            _db.Categories.Add(category);
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}
