using XpressMart.Application.Persistence;
using XpressMart.Application.Repositories.IRepositories;
using XpressMart.Core.Entities;
using XpressMart.Core.Models.Request;

namespace XpressMart.Application.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDBContext _context;

        public CategoryRepository(AppDBContext context)
        {
            _context = context;
        }
        public Category CreateCategory(CategoryRequestModel request)
        {
            var category = new Category
            {
                Name = request.Name,
                Description = request.Description
            };
            _context.Categories.Add(category);
            _context.SaveChanges();
            return category;
        }

        public Category UpdateCategory(int categoryId, CategoryRequestModel request)
        {
            var categoryUpdate = new Category
            {
                Id = categoryId,
                Name = request.Name,
                Description = request.Description
            };
            _context.Categories.Update(categoryUpdate);
            _context.SaveChanges();
            return categoryUpdate;
        }

        public bool DeleteCategory(int categoryId)
        {
            var category = GetCategory(categoryId);
            _context.Categories.Remove(category);
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public Category GetCategory(int categoryId)
        {
            return _context.Categories.FirstOrDefault(c => c.Id == categoryId);
        }

        public List<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public bool CategoryExists(int categoryId)
        {
            return _context.Categories.Any(c => c.Id == categoryId);
        }
    }
}
