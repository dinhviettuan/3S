﻿using System.Threading.Tasks;
using LoginCodeFirst.Resources;
using LoginCodeFirst.Services;
using LoginCodeFirst.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Serilog;


namespace LoginCodeFirst.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly ResourcesServices<CommonResources> _commonLocalizer;
        private readonly IUserServices _userServices;
        private readonly IStoreServices _storeServices;

        public UserController(
            IUserServices userService,
            IStoreServices storeServices,
            ResourcesServices<CommonResources> commonLocalizer)
        {
            _userServices = userService;
            _storeServices = storeServices;
            _commonLocalizer = commonLocalizer;
           
        }

        /// <summary>
        /// Index User
        /// </summary>
        /// <returns>User Index View</returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var listuser = await _userServices.GetUserListAsync();
            Log.Information("Get User List Async");
            return View(listuser);
        }

        /// <summary>
        /// Add User
        /// </summary>
        /// <returns>User Index View</returns>
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.StoreId = new SelectList(_storeServices.GetStores(), "Id", "StoreName");
            return View();
        }

        /// <summary>
        /// Add User Post Function
        /// </summary>
        /// <param name="userViewModel">UserViewModel</param>
        /// <returns>User Index View</returns>
        [HttpPost]
        public async Task<IActionResult> Add(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userServices.AddAsync(userViewModel);
                if (user)
                {
                    ViewBag.StoreId = new SelectList(_storeServices.GetStores(), "Id", "StoreName", userViewModel.StoreId);
                    TempData["Succces"] = _commonLocalizer.GetLocalizedHtmlString("msg_AddSuccess").ToString();
                    return RedirectToAction("Index");
                }
                ViewData["Error"] = _commonLocalizer.GetLocalizedHtmlString("err_AddUserFailure");
                ViewBag.StoreId = new SelectList(_storeServices.GetStores(), "Id", "StoreName", userViewModel.StoreId);
                return View(userViewModel);
            }
            ViewBag.StoreId = new SelectList(_storeServices.GetStores(), "Id", "StoreName", userViewModel.StoreId);
            Log.Error("Add User Error");
            return View(userViewModel);
        }

        /// <summary>
        /// Edit User
        /// </summary>
        /// <param name="id">User Id</param>
        /// <returns>User Index View</returns>
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                Log.Warning("Id Equal Null");
                return BadRequest();
            }
            var user = await _userServices.GetIdAsync(id.Value);
            if (user == null)
            {
                Log.Warning("Id Equal Null");
                return BadRequest();
            }
            ViewBag.StoreId = new SelectList(_storeServices.GetStores(), "Id", "StoreName");
            return View(user);
        }

        /// <summary>
        /// Edit User
        /// </summary>
        /// <param name="userViewModel">EditViewModel</param>
        /// <returns>User Index View</returns>
        [HttpPost]
        public async Task<IActionResult> Edit(EditViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userServices.EditAsync(userViewModel);
                if (user)
                {
                    TempData["Success"] = _commonLocalizer.GetLocalizedHtmlString("msg_EditSuccess").ToString();
                    return RedirectToAction("Index"); 
                }
                ViewData["Error"] = _commonLocalizer.GetLocalizedHtmlString("err_EditUserFailure");
                ViewBag.StoreId = new SelectList(_storeServices.GetStores(), "Id", "StoreName", userViewModel.StoreId);
                return View(userViewModel);
            }
            ViewBag.StoreId = new SelectList(_storeServices.GetStores(), "Id", "StoreName", userViewModel.StoreId);
            Log.Error("Edit User Error");
            return View(userViewModel);
        }

        /// <summary>
        /// EditPassword User
        /// </summary>
        /// <param name="id">User Id</param>
        /// <returns>User Index View</returns>
        [HttpGet]
        public async Task<IActionResult> EditPassword(int? id)
        {
            if (id == null)
            {
                Log.Warning("Id Password Equal Null");
                return BadRequest();
            }
            var getId = await _userServices.GetEditPasswordAsync(id.Value);
            if (getId == null)
            {
                Log.Warning("Id Password Equal Null");
                return BadRequest();
            }
            return PartialView("_ChangePassword", getId);
        }

        /// <summary>
        /// EditPassword User
        /// </summary>
        /// <param name="userViewModel">PasswordViewModel</param>
        /// <returns>User Index View</returns>
        [HttpPost]
        public async Task<IActionResult> EditPassword(PasswordViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                var usersPassword = await _userServices.EditPasswordAsync(userViewModel);
                if (usersPassword)
                {
                    TempData["Success"] = _commonLocalizer.GetLocalizedHtmlString("msg_EditPasswordSuccess").ToString();
                    return PartialView("_ChangePassword",userViewModel);
                }
                ViewData["Error"] = _commonLocalizer.GetLocalizedHtmlString("err_EditPasswordFailure");
                return PartialView("_ChangePassword",userViewModel); 
            }
            Log.Error("Edit Password User Error");
            return PartialView("_ChangePassword",userViewModel);
        }

        /// <summary>
        /// Delete User
        /// </summary>
        /// <param name="id">User Id</param>
        /// <returns>>User Index View</returns>
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                Log.Warning("Id User Equal Null");
                return BadRequest();
            }
            var user = await _userServices.DeleteAsync(id.Value);
            if (user)
            {
                TempData["Success"] = _commonLocalizer.GetLocalizedHtmlString("msg_DeleteSuccess").ToString();
                return RedirectToAction("Index");
            } 
            TempData["Error"] = _commonLocalizer.GetLocalizedHtmlString("msg_DeleteError").ToString();
            Log.Error("Delete User Error");
            return RedirectToAction("Index");
        }
    }
}