 using Shared.Dtos;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WEBApi.Helpers;
using WEBApi.Models;
using WEBApi.Models.Catalogs;
using WEBApi.Services.Interfaces;

namespace WEBApi.Services
{
    public class CatalogService : ICatalogService
    {

        private readonly HttpClient _client;
        private readonly IPhotoStockService _photoStockService;
        private readonly PhotoHelper _photoHelper;

        public CatalogService(HttpClient client, IPhotoStockService photoStockService, PhotoHelper photoHelper)
        {
            _client = client;
            _photoStockService = photoStockService;
            _photoHelper = photoHelper;
        }

        public async Task<bool> CreateCourseAsync(ProductCreateInput productCreateInput)
        {
            var resultPhotoService = await _photoStockService.UploadPhoto(productCreateInput.PhotoFormFile);

            if (resultPhotoService != null)
            {
                productCreateInput.Picture = resultPhotoService.Url;
            }




            var response = await _client.PostAsJsonAsync<ProductCreateInput>("products", productCreateInput);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteCourseAsync(string productId)
        {
            var response = await _client.DeleteAsync($"products/{productId}");

            return response.IsSuccessStatusCode;
        }

        public async Task<List<CategoryViewModel>> GetAllCategoryAsync()
        {
            var response = await _client.GetAsync("categories");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var responseSuccess = await response.Content.ReadFromJsonAsync<Response<List<CategoryViewModel>>>();

            return responseSuccess.Data;
        }

        public async Task<List<ProductViewModel>> GetAllCourseAsync()
        {
            var response = await _client.GetAsync("products");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var responseSuccess = await response.Content.ReadFromJsonAsync<Response<List<ProductViewModel>>>();


            responseSuccess.Data.ForEach(x =>
            {
                x.StockPictureUrl = _photoHelper.GetPhotoStockUrl(x.Picture);
            });

            return responseSuccess.Data;
        }

        public async Task<List<ProductViewModel>> GetAllCourseByUserIdAsync(string userId)
        {
            var response = await _client.GetAsync($"products/GetAllByUserId/{userId}");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var responseSuccess = await response.Content.ReadFromJsonAsync<Response<List<ProductViewModel>>>();


            responseSuccess.Data.ForEach(x =>
            {
               x.StockPictureUrl = _photoHelper.GetPhotoStockUrl(x.Picture);
            });


            return responseSuccess.Data;
        }

        public async Task<ProductViewModel> GetByCourseId(string productId)
        {
            var response = await _client.GetAsync($"products/{productId}");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var responseSuccess = await response.Content.ReadFromJsonAsync<Response<ProductViewModel>>();

            responseSuccess.Data.StockPictureUrl=_photoHelper.GetPhotoStockUrl(responseSuccess.Data.Picture);


            return responseSuccess.Data;
        }

        public async Task<bool> UpdateCourseAsync(ProductUpdateInput productUpdateInput)
        {

            var resultPhotoService = await _photoStockService.UploadPhoto(productUpdateInput.PhotoFormFile);

            if (resultPhotoService != null)
            {
                await _photoStockService.DeletePhoto(productUpdateInput.Picture);
                productUpdateInput.Picture = resultPhotoService.Url;
            }




            var response = await _client.PutAsJsonAsync<ProductUpdateInput>("products", productUpdateInput);

            return response.IsSuccessStatusCode;
        }
    }
}
