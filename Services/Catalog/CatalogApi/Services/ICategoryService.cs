using CatalogApi.Dtos;
using CatalogApi.Models;
using Shared.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatalogApi.Services
{
    public interface ICategoryService
    {
        Task<Response<List<CategoryDto>>> GetAllAsync();
        Task<Response<CategoryDto>> CreateAsync(CategoryDto category);
        Task<Response<CategoryDto>> GetByIdAsync(string id);



    }
}
