using System.Threading.Tasks;
using LoginCodeFirst.Resources;
using LoginCodeFirst.Services;
using LoginCodeFirst.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;


namespace LoginCodeFirst.Controllers
{
//    [ServiceFilter(typeof(ActionFilter))]
    [Authorize]
    public class StoreController : Controller
    {
        private readonly ResourcesServices<CommonResources> _commonLocalizer;
        private readonly ResourcesServices<StoreResources> _storeLocalizer;
        private readonly IStoreServices _storeService;
        public StoreController(IStoreServices storeService,
            ResourcesServices<CommonResources> commonLocalizer,
            ResourcesServices<StoreResources> storeLocalizer)
        {
            _commonLocalizer = commonLocalizer;
            _storeService = storeService;
            _storeLocalizer = storeLocalizer;
        }


        /// <summary>
        /// Index Store
        /// </summary>
        /// <returns>Store Index View</returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var liststore = await _storeService.GetStoreListAsync();
            Log.Information("Get Store List Async");
            return View(liststore);
        }

        /// <summary>
        /// Add Store
        /// </summary>
        /// <returns>Store Index View</returns>
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        /// <summary>
        /// Add Store
        /// </summary>
        /// <param name="storeViewModel">StoreViewModel</param>
        /// <returns>Store Index View</returns>
        [HttpPost]
        public async Task<IActionResult> Add(StoreViewModel storeViewModel)
        {
            if (ModelState.IsValid)
            { 
                var store = await _storeService.AddAsync(storeViewModel);
                if (store)
                {
                    TempData["Success"] = _commonLocalizer.GetLocalizedHtmlString("msg_AddSuccess").ToString();
                    return RedirectToAction("Index");
                }                
                ViewData["Error"] = _storeLocalizer.GetLocalizedHtmlString("err_AddStoreFailure");
                return View(storeViewModel);
            }
            Log.Error("Add Store Error");
            return View(storeViewModel);
        }

        /// <summary>
        /// Edit Store
        /// </summary>
        /// <param name="id">Store Id</param>
        /// <returns>Store Index View</returns>
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                Log.Warning("Id Equal Null");
                return BadRequest();
            }
            var store = await _storeService.GetIdAsync(id.Value);
            if (store == null)
            {
                Log.Warning("Store Equal Null");
                return NotFound();
            } 
            return View(store);
        }
        
        /// <summary>
        ///  Edit Store
        /// </summary>
        /// <param name="storeViewModel">StoreViewModel</param>
        /// <returns>Store Index View</returns>
        [HttpPost]
        public async Task<IActionResult> Edit(StoreViewModel storeViewModel)
        {
            if (ModelState.IsValid)
            {
                var store = await _storeService.EditAsync(storeViewModel);
                if (store)
                {
                    TempData["Success"] = _commonLocalizer.GetLocalizedHtmlString("msg_EditSuccess").ToString();
                    return RedirectToAction("Index");
                }
                ViewData["Error"] = _storeLocalizer.GetLocalizedHtmlString("err_EditStoreFailure");
                return View(storeViewModel);
            }
            Log.Error("Edit Store Error");
            return View(storeViewModel);
        }

        /// <summary>
        /// Delete Store
        /// </summary>
        /// <param name="id">Store Id</param>
        /// <returns>Store Index View</returns>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                Log.Warning("Id Store Equal Null");
                return BadRequest();
            }
            var  store = await _storeService.DeleteAsync(id.Value);
            if (store)
            {
                TempData["Success"] = _commonLocalizer.GetLocalizedHtmlString("msg_DeleteSuccess").ToString();
                return  RedirectToAction("Index");
            }
            TempData["Error"] = _commonLocalizer.GetLocalizedHtmlString("msg_DeleteError").ToString();
            Log.Error("Delete Store Error");
            return  RedirectToAction("Index");
        }
   }
}