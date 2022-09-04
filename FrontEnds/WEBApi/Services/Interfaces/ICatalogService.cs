using System.Collections.Generic;
using System.Threading.Tasks;
using WEBApi.Models.Catalogs;

namespace WEBApi.Services.Interfaces
{
    public interface ICatalogService
    {
        Task<List<ProductViewModel>> GetAllCourseAsync();
        Task<List<CategoryViewModel>> GetAllCategoryAsync();
        Task<List<ProductViewModel>> GetAllCourseByUserIdAsync(string userId);
        Task<ProductViewModel> GetByCourseId(string courseId);


        Task<bool> CreateCourseAsync(ProductCreateInput courseCreateInput);

        Task<bool> UpdateCourseAsync(ProductUpdateInput courseUpdateInput);


        Task<bool> DeleteCourseAsync(string courseId);
    }
}
