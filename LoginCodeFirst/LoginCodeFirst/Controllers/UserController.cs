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
                var isValidator = await _userService.LoginAsync(user.Email, user.Password);
                if (isValidator)
                {
                    var users = _userService.GetEmailAsync(user.Email);
                    HttpContext.Session.SetString("fullname", user.Email);
                    return RedirectToAction("Index");
                }
                ViewBag.Err = "Login Fail!!! Email or Password is wrong!";
                return View(user);
            }
            return View(user);
        }

            
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var listuser = await _userService.GetUserListAsync();
            return View(listuser);
        }


        //ADD
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.StoreId = new SelectList(_storeServices.GetStores(), "StoreId", "StoreName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(IndexViewModel user)
        {
            if (ModelState.IsValid)
            {

                var list = await _userService.AddAsync(user);
                if (list)
                {
                    ViewBag.StoreId = new SelectList(_storeServices.GetStores(), "StoreId", "StoreName", user.StoreId);
                    TempData["User"] = "Add user success!";
                    return RedirectToAction("Index");
                }
                ViewBag.Err = "Add User Failure";
                ViewBag.StoreId = new SelectList(_storeServices.GetStores(), "StoreId", "StoreName", user.StoreId);
                return View(user);
            }
            ViewBag.StoreId = new SelectList(_storeServices.GetStores(), "StoreId", "StoreName", user.StoreId);
            return View(user);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var findUser = await _userService.GetIdAsync(id);
            if (findUser == null)
            {
                return NotFound();
            }
            ViewBag.StoreId = new SelectList(_storeServices.GetStores(), "StoreId", "StoreName");
            return View(findUser);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditViewModel user)
        {

            if (ModelState.IsValid)
            {
                var list = await _userService.EditAsync(user);
                if (list)
                {
                    TempData["User"] = "Edit User Success";
                    return RedirectToAction("Index"); 
                }  
                ViewBag.StoreId = new SelectList(_storeServices.GetStores(), "StoreId", "StoreName", user.StoreId);
                return View(user);
            }
            ViewBag.StoreId = new SelectList(_storeServices.GetStores(), "StoreId", "StoreName", user.StoreId);
            return View(user);
        }

        
        [HttpGet]
        public async Task<IActionResult> EditPassword(int? id)
        {

            var users = await _userService.GetEditPasswordAsync(id);
            if (users == null)
            {
                return NotFound();
            }
            return View(users); 

        }

        [HttpPost]
        public async Task<IActionResult> EditPassword(PasswordViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                if (await _userService.EditPasswordAsync(userViewModel))
                {
                    TempData["User"] = "Edit Password Success";
                    return RedirectToAction("Index");
                }
                ViewBag.Err = "Edit Password Failure";
                return View(userViewModel);
            }

            return View(userViewModel);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            await _userService.DeleteAsync(id);
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