using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using WEBApi.Models.Photostocks;

namespace WEBApi.Services.Interfaces
{
    public interface IPhotoStockService
    {
        Task<PhotoViewModel> UploadPhoto(IFormFile photo);
        Task<bool> DeletePhoto(string photoUrl);
    }
}
