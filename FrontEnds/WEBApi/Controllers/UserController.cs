using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WEBApi.Models;
using WEBApi.Services.Interfaces;

namespace WEBApi.Controllers
{
    [Authorize]
    public class UserController : Controller
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {

            return View(await _userService.GetUser());
        }


    }
}
