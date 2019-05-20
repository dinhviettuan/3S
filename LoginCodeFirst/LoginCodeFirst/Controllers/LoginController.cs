using System.Threading.Tasks;
using LoginCodeFirst.Services;
using LoginCodeFirst.ViewModels.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoginCodeFirst.Controllers
{
    public class LoginController : Controller
    {

        private readonly IUserServices _userService;



        public LoginController(IUserServices userService)
        {

            _userService = userService;
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
        /// Login Post Function
        /// </summary>
        /// <param name="loginViewModel"></param>
        /// <returns>Login View</returns>
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var isValidator = await _userService.LoginAsync(loginViewModel.Email, loginViewModel.Password);
                if (isValidator)
                {
                    var user = _userService.GetEmailAsync(loginViewModel.Email);
                    HttpContext.Session.SetString("fullname", loginViewModel.Email);
                    return RedirectToAction("Login");
                }

                ViewBag.Err = "Login Fail!!! Email or Password is wrong!";
                return View(loginViewModel);
            }

            return View(loginViewModel);
        }
        
        /// <summary>
        /// Logout Get Function
        /// </summary>
        /// <returns>Login View</returns>
        [HttpGet]
        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("fullname");
            return RedirectToAction("Login");
        }
    }
}