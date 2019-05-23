using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using LoginCodeFirst.Resources;
using LoginCodeFirst.Services;
using LoginCodeFirst.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoginCodeFirst.Controllers
{
//    [Authorize]
    public class LoginController : Controller
    {

        
        private readonly IUserServices _userServices;
        private readonly ResourcesServices<UserResources> _userLocalizer;
        
        public LoginController(IUserServices userServices,
            ResourcesServices<UserResources> userLocalizer)
        {
            _userLocalizer = userLocalizer;
            _userServices = userServices;         
        }

        /// <summary>
        /// Login Get Function
        /// </summary>
        /// <returns>Login View</returns>
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login)
        { 
            if (ModelState.IsValid)
            { 
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, login.Email),
                    new Claim("FullName", login.Email),
                    new Claim(ClaimTypes.Role, "Admin"),
                    new Claim(ClaimTypes.Role, "User")
                };
                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties();
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme, 
                    new ClaimsPrincipal(claimsIdentity), 
                    authProperties);
                var isValidator = _userServices.Login(login.Email, login.Password);
                if (isValidator)
                {
                    var getEmail = await _userServices.GetEmail(login.Email);
                    HttpContext.Session.SetString("fullname",getEmail.FullName);
                    return RedirectToAction("Index","User");
                }
                ViewData["Error"] = _userLocalizer.GetLocalizedHtmlString("err_LoginFailure");
                return View(login);
            }
            return View(login);
        }
        
        /// <summary>
        /// Logout Get Function
        /// </summary>
        /// <returns>Login View</returns>
        [HttpGet]
        public async Task<IActionResult> LogOut()
        { 
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Remove("fullname");
            return RedirectToAction("Login");
        }
    }
}
