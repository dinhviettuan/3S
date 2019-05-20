using System.Threading.Tasks;
using LoginCodeFirst.Services;
using LoginCodeFirst.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoginCodeFirst.Controllers
{
    public class LoginController : Controller
    {


        private readonly IUserServices _userServices;
        
        public LoginController(IUserServices userServices)
        {

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
        /// Login Post Function
        /// </summary>
        /// <param name="loginViewModel"></param>
        /// <returns>Login View</returns>
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel user)
        { 
            if (ModelState.IsValid)
            { 
                var isValidator = _userServices.Login(user.Email, user.Password);
                if (isValidator)
                {
                    var getEmail = await _userServices.GetEmail(user.Email);
                    HttpContext.Session.SetString("fullname",getEmail.FullName);
                    return RedirectToAction("Index","User");
                }
            }
            ViewData["errorMessage"] = "Login Fail";
            return View(user);
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