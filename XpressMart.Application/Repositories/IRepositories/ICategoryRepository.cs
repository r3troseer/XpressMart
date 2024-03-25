using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XpressMart.Core.Entities;
using XpressMart.Core.Models.Request;
using XpressMart.Core.Models.Response;

namespace XpressMart.Application.Repositories.IRepositories
{
    public interface ICategoryRepository
    {
        Task<BaseResponse<Category>> CreateCategory(CategoryRequestModel request);
        Task<BaseResponse<Category>> UpdateCategory(CategoryRequestModel request);
        Task<BaseResponse<Category>> DeleteCategory(int categoryId);
        Task<BaseResponse<Category>> GetCategory(int categoryId);
        Task<BaseResponse<List<Category>>> GetCategories();
        bool CategoryExists(int categoryId);
    }
}
