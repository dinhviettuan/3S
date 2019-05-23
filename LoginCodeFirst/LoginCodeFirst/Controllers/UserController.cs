using System.Threading.Tasks;
using LoginCodeFirst.Resources;
using LoginCodeFirst.Services;
using LoginCodeFirst.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace LoginCodeFirst.Controllers
{
//    [ServiceFilter(typeof(ActionFilter))]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly ResourcesServices<CommonResources> _commonLocalizer;
        private readonly ResourcesServices<UserResources> _userLocalizer;
        private readonly IUserServices _userService;

        private readonly IStoreServices _storeServices;

        public UserController(IUserServices userService,IStoreServices storeServices,
            ResourcesServices<CommonResources> commonLocalizer,
            ResourcesServices<UserResources> userLocalizer)
        {

            _userService = userService;
            _storeServices = storeServices;
            _commonLocalizer = commonLocalizer;
            _userLocalizer = userLocalizer;
        }


        /// <summary>
        /// Index User Get Funciton
        /// </summary>
        /// <returns>User Index View</returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var listuser = await _userService.GetUserListAsync();
            return View(listuser);
        }


        /// <summary>
        /// Add User Get Function
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
        /// <param name="userViewModel"></param>
        /// <returns>User Index View</returns>
        [HttpPost]
        public async Task<IActionResult> Add(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userService.AddAsync(userViewModel);
                if (user)
                {
                    ViewBag.StoreId = new SelectList(_storeServices.GetStores(), "Id", "StoreName", userViewModel.StoreId);
                    TempData["Succces"] = _commonLocalizer.GetLocalizedHtmlString("msg_AddSuccess").ToString();
                    return RedirectToAction("Index");
                }
                ViewData["Error"] = _userLocalizer.GetLocalizedHtmlString("err_AddUserFailure");
                ViewBag.StoreId = new SelectList(_storeServices.GetStores(), "Id", "StoreName", userViewModel.StoreId);
                return View(userViewModel);
            }
            ViewBag.StoreId = new SelectList(_storeServices.GetStores(), "Id", "StoreName", userViewModel.StoreId);
            return View(userViewModel);
        }

        /// <summary>
        /// Edit User Get Function
        /// </summary>
        /// <param name="id"></param>
        /// <returns>User Index View</returns>
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var user = await _userService.GetIdAsync(id.Value);
            if (user == null)
            {
                return BadRequest();
            }
            ViewBag.StoreId = new SelectList(_storeServices.GetStores(), "Id", "StoreName");
            return View(user);
        }

        /// <summary>
        /// Edit User Post Function
        /// </summary>
        /// <param name="userViewModel"></param>
        /// <returns>User Index View</returns>
        [HttpPost]
        public async Task<IActionResult> Edit(EditViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userService.EditAsync(userViewModel);
                if (user)
                {
                    TempData["Success"] = _commonLocalizer.GetLocalizedHtmlString("msg_EditSuccess").ToString();
                    return RedirectToAction("Index"); 
                }

                ViewData["Error"] = _userLocalizer.GetLocalizedHtmlString("err_EditUserFailure");
                ViewBag.StoreId = new SelectList(_storeServices.GetStores(), "Id", "StoreName", userViewModel.StoreId);
                return View(userViewModel);
            }
            ViewBag.StoreId = new SelectList(_storeServices.GetStores(), "Id", "StoreName", userViewModel.StoreId);
            return View(userViewModel);
        }

        /// <summary>
        /// EditPassword User Get Function
        /// </summary>
        /// <param name="id"></param>
        /// <returns>User Index View</returns>
        [HttpGet]
        public async Task<IActionResult> EditPassword(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var getId = await _userService.GetEditPasswordAsync(id.Value);
            if (getId == null)
            {
                return BadRequest();
            }
            return PartialView("_ChangePassword", getId);
        }

        /// <summary>
        /// EditPassword User Post Function
        /// </summary>
        /// <param name="userViewModel"></param>
        /// <returns>User Index View</returns>
        [HttpPost]
        public async Task<IActionResult> EditPassword(PasswordViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                var usersPassword = await _userService.EditPasswordAsync(userViewModel);
                if (usersPassword)
                {
                    TempData["Success"] = _userLocalizer.GetLocalizedHtmlString("msg_EditPasswordSuccess").ToString();
                    return PartialView("_ChangePassword",userViewModel);
                }
                ViewData["Error"] = _userLocalizer.GetLocalizedHtmlString("err_EditPasswordFailure");
                return PartialView("_ChangePassword",userViewModel); 
            }
            return PartialView("_ChangePassword",userViewModel);
        }

        /// <summary>
        /// Delete User Get Function
        /// </summary>
        /// <param name="id"></param>
        /// <returns>>User Index View</returns>
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var user = await _userService.DeleteAsync(id.Value);
            if (user)
            {
                TempData["Success"] = _commonLocalizer.GetLocalizedHtmlString("msg_DeleteSuccess").ToString();
                return RedirectToAction("Index");
            } 
            TempData["Error"] = _commonLocalizer.GetLocalizedHtmlString("msg_DeleteError").ToString();
            return RedirectToAction("Index");
        }
    }
}