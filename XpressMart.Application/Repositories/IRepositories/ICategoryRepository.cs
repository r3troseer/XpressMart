using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XpressMart.Core.Entities;
using XpressMart.Core.Models.Request;

namespace XpressMart.Application.Repositories.IRepositories
{
    public interface ICategoryRepository
    {
        Category CreateCategory(CategoryRequestModel request);
        Category UpdateCategory(int categoryId, CategoryRequestModel request);
        bool DeleteCategory(int categoryId);
        Category GetCategory(int categoryId);
        List<Category> GetCategories();
        bool CategoryExists(int categoryId);
    }
}
