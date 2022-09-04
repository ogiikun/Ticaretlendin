using IdentityModel.Client;
using Shared.Dtos;
using System.Threading.Tasks;
using WEBApi.Models;

namespace WEBApi.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<Response<bool>> SignIn(SıgnInInput sıgnInInput);
        Task<TokenResponse> GetAccessTokenByRefreshToken();
        Task RevokeRefreshToken();

    }
}
