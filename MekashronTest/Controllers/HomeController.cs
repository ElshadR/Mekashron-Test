using MekashronTest.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace MekashronTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly IICUTech _iCUTech;

        public HomeController(IICUTech iCUTech)
        {
            _iCUTech = iCUTech;
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View(new MyLoginRequest());
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(MyLoginRequest request)
        {
            if (ModelState.IsValid)
            {
                var response = await _iCUTech.LoginAsync(new LoginRequest()
                {
                    UserName = request.UserName,
                    Password = request.Password,
                });
                var loginResponse = JsonConvert.DeserializeObject<MyLoginResponse>(response.@return);

                if (loginResponse != null && loginResponse.ResultCode == -1)
                {
                    TempData["Error"] = loginResponse.ResultMessage;
                }
                else
                {
                    TempData["Success"] = $"user {loginResponse.FirstName} is logged in";
                }
            }
            return View(request);
        }
    }
}