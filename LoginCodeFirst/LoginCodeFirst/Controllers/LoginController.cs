﻿using System.Collections.Generic;
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
        /// Login
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
        /// <param name="login">Login</param>
        /// <returns>Login</returns>
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login)
        { 
            if (ModelState.IsValid)
            { 
                var isLogin = _userServices.Login(login.Email, login.Password);
                if (isLogin)
                {
                    var user = await _userServices.GetEmail(login.Email);
                    var role = "";
                    if (user.Role == 1)
                    {
                        role = "Admin";
                    }
                    else if (user.Role == 2)
                    {
                        role = "User";
                    }
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, login.Email),
                        new Claim("FullName", login.Email),
                        new Claim(ClaimTypes.Role, role)
                    };
                    var claimsIdentity = new ClaimsIdentity(
                        claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties();
                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme, 
                        new ClaimsPrincipal(claimsIdentity), 
                        authProperties);

                    
                    
                    HttpContext.Session.SetString("fullname",user.FullName);
                    return RedirectToAction("Index","User");
                }
                ViewData["Error"] = _userLocalizer.GetLocalizedHtmlString("err_LoginFailure");
                return View(login);
            }
            return View(login);
        }
        
        /// <summary>
        /// Logout
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
