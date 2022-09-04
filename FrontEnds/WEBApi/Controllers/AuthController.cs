using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WEBApi.Models;
using WEBApi.Services.Interfaces;

namespace WEBApi.Controllers
{
    public class AuthController : Controller
    {

        private readonly IIdentityService _ıdentityService;

        public AuthController(IIdentityService ıdentityService)
        {
            _ıdentityService = ıdentityService;
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn (SıgnInInput sıgnInInput)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            var response = await _ıdentityService.SignIn(sıgnInInput);

            if (!response.IsSuccessful)
            {
                response.Errors.ForEach(x =>
                {
                    ModelState.AddModelError(string.Empty, x);
                });
                

                return View();
            }

            return RedirectToAction(nameof(Index), "Home");


        }


        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            await _ıdentityService.RevokeRefreshToken();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

    }
}
