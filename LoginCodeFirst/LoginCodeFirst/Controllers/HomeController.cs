﻿using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LoginCodeFirst.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Serilog;

namespace LoginCodeFirst.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
            
        }

        public IActionResult Privacy()
        {
            return View();
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
        

        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );
            return LocalRedirect(returnUrl);
        }
        
    }
}