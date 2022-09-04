using System.Threading.Tasks;
using WEBApi.Models;

namespace WEBApi.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserViewModel> GetUser();
      
    }
}
