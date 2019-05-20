using System.Threading.Tasks;
using LoginCodeFirst.Services;
using LoginCodeFirst.ViewModels.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace LoginCodeFirst.Controllers
{
    public class UserController : Controller
    {

        private readonly IUserServices _userService;

        private readonly IStoreServices _storeServices;

        public UserController(IUserServices userService,IStoreServices storeServices)
        {

            _userService = userService;
            _storeServices = storeServices;
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
            ViewBag.StoreId = new SelectList(_storeServices.GetStores(), "StoreId", "StoreName");
            return View();
        }

        /// <summary>
        /// Add User Post Function
        /// </summary>
        /// <param name="user"></param>
        /// <returns>User Index View</returns>
        [HttpPost]
        public async Task<IActionResult> Add(IndexViewModel user)
        {
            if (ModelState.IsValid)
            {

                var list = await _userService.AddAsync(user);
                if (list)
                {
                    ViewBag.StoreId = new SelectList(_storeServices.GetStores(), "StoreId", "StoreName", user.StoreId);
                    TempData["Success"] = "Add user success!";
                    return RedirectToAction("Index");
                }
                ViewBag.Err = "Add User Failure";
                ViewBag.StoreId = new SelectList(_storeServices.GetStores(), "StoreId", "StoreName", user.StoreId);
                return View(user);
            }
            ViewBag.StoreId = new SelectList(_storeServices.GetStores(), "StoreId", "StoreName", user.StoreId);
            return View(user);
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
            ViewBag.StoreId = new SelectList(_storeServices.GetStores(), "StoreId", "StoreName");
            return View(user);
        }

        /// <summary>
        /// Edit User Post Function
        /// </summary>
        /// <param name="user"></param>
        /// <returns>User Index View</returns>
        [HttpPost]
        public async Task<IActionResult> Edit(EditViewModel user)
        {

            if (ModelState.IsValid)
            {
                var list = await _userService.EditAsync(user);
                if (list)
                {
                    TempData["Success"] = "Edit User Success";
                    return RedirectToAction("Index"); 
                }  
                ViewBag.StoreId = new SelectList(_storeServices.GetStores(), "StoreId", "StoreName", user.StoreId);
                return View(user);
            }
            ViewBag.StoreId = new SelectList(_storeServices.GetStores(), "StoreId", "StoreName", user.StoreId);
            return View(user);
        }

        /// <summary>
        /// EditPassword User Get Function
        /// </summary>
        /// <param name="id"></param>
        /// <returns>User Index View</returns>
        [HttpGet]
        public async Task<IActionResult> EditPassword(int? id)
        {

            var users = await _userService.GetEditPasswordAsync(id.Value);
            if (users == null)
            {
                return BadRequest();
            }
            return PartialView("_ChangePassword", users); 

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
                if (await _userService.EditPasswordAsync(userViewModel))
                {
                    TempData["Success"] = "Edit Password Success";
                    return RedirectToAction("Index");
                }
                ViewBag.Err = "Edit Password Failure";
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
            await _userService.DeleteAsync(id.Value);

            TempData["Success"] = "Delete User Success";
            return RedirectToAction("Index");
        }

        
    }
}