using System;
using System.Threading.Tasks;
using LoginCodeFirst.Services;
using LoginCodeFirst.ViewModels.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace LoginCodeFirst.Controllers
{
    public class UserController : Controller
    {

        private readonly IUserServices _userService;

        public readonly IStoreServices _storeServices;

        public UserController(IUserServices userService,IStoreServices storeServices)
        {

            _userService = userService;
            _storeServices = storeServices;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                var isValidator = await _userService.Login(user.Email, user.Password);
                if (isValidator)
                {
                    var users = _userService.GetEmail(user.Email);
                    HttpContext.Session.SetString("fullname", user.Email);
                    return RedirectToAction("Index");
                }
            }
            ViewBag.Err = "Login Fail!!! Email or Password is wrong!";
            return View(user);
        }

            
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var listuser = await _userService.GetUserList();
            return View(listuser);
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


        //ADD
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.StoreId = new SelectList(_storeServices.Stores, "StoreId", "StoreName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(IndexViewModel user)
        {
            if (ModelState.IsValid)
            {

                var list = await _userService.Add(user);
                if (list)
                {
                    ViewBag.StoreId = new SelectList(_storeServices.Stores, "StoreId", "StoreName", user.StoreId);
                    TempData["User"] = "Add user success!";
                    return RedirectToAction("Index");
                }
            }

                ViewBag.Err = "Add User Failure";
                ViewBag.StoreId = new SelectList(_storeServices.Stores, "StoreId", "StoreName", user.StoreId);
            return View(user);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var findUser = await _userService.GetId(id);
            if (findUser == null)
            {
                return NotFound();
            }
                ViewBag.StoreId = new SelectList(_storeServices.Stores, "StoreId", "StoreName");
            return View(findUser);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditViewModel user)
        {

            if (ModelState.IsValid)
            {
                await _userService.Edit(user);
                TempData["User"] = "Edit User Success";
                return RedirectToAction("Index"); 
            }

            return View(user);
        }

        
        [HttpGet]
        public async Task<IActionResult> EditPassword(int? id)
        {

            var users = await _userService.GetEditPassword(id);
            if (users == null)
            {
                return NotFound();
            }
            return View(users); 

        }

        [HttpPost]
        public async Task<IActionResult> EditPassword(PasswordViewModel user)
        {
            if (ModelState.IsValid)
            {
                if (await _userService.EditPassword(user))
                {
                    TempData["User"] = "Edit Password Success";
                    return RedirectToAction("Index");
                }
            }

            ViewBag.Err = "Edit Password Failure";
            return View(user);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            await _userService.Delete(id);
            TempData["User"] = "Delete User Success";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("fullname");
            return RedirectToAction("Login");
        }
    }
}