using Microsoft.EntityFrameworkCore;
using XpressMart.Application.Persistence;
using XpressMart.Application.Repositories.IRepositories;
using XpressMart.Core.Entities;
using XpressMart.Core.Models.Request;
using XpressMart.Core.Models.Response;

namespace XpressMart.Application.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDBContext _context;

        public CategoryRepository(AppDBContext context)
        {
            _context = context;
        }
        public async Task<BaseResponse<Category>> CreateCategory(CategoryRequestModel request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var category = new Category
            {
                Name = request.Name,
                Description = request.Description
            };

            await _context.Categories.AddAsync(category);
            var saved  = await _context.SaveChangesAsync();

            if (!(saved > 0 ? true : false))
                return new BaseResponse<Category>(new List<string> {"Category creation failed"}, false );

            return new BaseResponse<Category>(data: category, success: true, message: "Category created sucessfuly");
        }

        public async Task<BaseResponse<Category>> UpdateCategory(CategoryRequestModel request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var categoryUpdate = new Category
            {
                Id = request.Id.GetValueOrDefault(),
                Name = request.Name,
                Description = request.Description
            };

            _context.Categories.Update(categoryUpdate);
            var saved = await _context.SaveChangesAsync();

            if (!(saved > 0 ? true : false))
                return new BaseResponse<Category>(new List<string> { "Category update failed" }, false);

            return new BaseResponse<Category>(data: categoryUpdate, success: true, message: "Category updated sucessfuly");
        }

        public async Task<BaseResponse<Category>> DeleteCategory(int categoryId)
        {
            var category = await GetCategory(categoryId);
            _context.Categories.Remove(category.Data);
            var saved = await _context.SaveChangesAsync();

            if (!(saved > 0 ? true : false))
                return new BaseResponse<Category>(new List<string> { "Category deletion failed" }, false);

            return new BaseResponse<Category>(success: true, message: "Category deleted sucessfuly");
        }

        public async Task<BaseResponse<Category>> GetCategory(int categoryId)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == categoryId);

            if (category == null)
                return new BaseResponse<Category>(new List<string> { "Category retrieval failed" }, false);

            return new BaseResponse<Category>(data: category, success: true, message: "Category retrieved sucessfuly");

        }

        public async Task<BaseResponse<List<Category>>> GetCategories()
        {
            var categories = await _context.Categories.ToListAsync();

            if (categories == null)
                return new BaseResponse<List<Category>>(new List<string> { "Category retrieval failed" }, false);

            return new BaseResponse<List<Category>>(data: categories, success: true, message: "Category retrieved sucessfuly");
        }

        public bool CategoryExists(int categoryId)
        {
            return _context.Categories.Any(c => c.Id == categoryId);
        }
    }
}
