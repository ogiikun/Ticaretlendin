using System;
using System.Threading.Tasks;

namespace WEBApi.Services.Interfaces
{
    public interface IClientCredentialTokenService
    {
        Task<String> GetToken();
    }
}
