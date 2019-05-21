﻿    using System.Threading.Tasks;
    using LoginCodeFirst.Filter;
    using LoginCodeFirst.Resources;
    using LoginCodeFirst.Services;
using LoginCodeFirst.ViewModels.Store;
using Microsoft.AspNetCore.Mvc;


namespace LoginCodeFirst.Controllers
{
    [ServiceFilter(typeof(ActionFilter))]

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
        /// Index Store Get Function
        /// </summary>
        /// <returns>Store Index View</returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var liststore = await _storeService.GetStoreListAsync();
            return View(liststore);
        }

        /// <summary>
        /// Add Store Get Function
        /// </summary>
        /// <returns>Store Index View</returns>
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        /// <summary>
        /// Add Store Post Function
        /// </summary>
        /// <param name="storeViewModel"></param>
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
            ViewData["Error"] = _storeLocalizer.GetLocalizedHtmlString("err_AddStoreFailure");
            return View(storeViewModel);
        }

        /// <summary>
        /// Edit Store Get Function
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Store Index View</returns>
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var getId = await _storeService.GetIdAsync(id.Value);
            if (getId == null)
            {
                return NotFound();
            }
 
            return View(getId);
        }
        /// <summary>
        ///  Edit Store Post Function
        /// </summary>
        /// <param name="storeViewModel"></param>
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
            ViewData["Error"] = _storeLocalizer.GetLocalizedHtmlString("err_EditStoreFailure");
            return View(storeViewModel);
        }

        /// <summary>
        /// Delete Store Get Function
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Store Index View</returns>
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            await _storeService.DeleteAsync(id.Value);
            TempData["Success"] = _commonLocalizer.GetLocalizedHtmlString("msg_DeleteSuccess").ToString();
            return  RedirectToAction("Index");
        }
   }
}