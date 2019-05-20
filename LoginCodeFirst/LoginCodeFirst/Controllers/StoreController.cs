    using System.Threading.Tasks;
    using LoginCodeFirst.Filter;
    using LoginCodeFirst.Services;
using LoginCodeFirst.ViewModels.Store;
using Microsoft.AspNetCore.Mvc;


namespace LoginCodeFirst.Controllers
{
    [ServiceFilter(typeof(ActionFilter))]

    public class StoreController : Controller
    {
        private readonly IStoreServices _storeService;
        public StoreController(IStoreServices storeService)
        {
            _storeService = storeService;
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
        /// <param name="store"></param>
        /// <returns>Store Index View</returns>
        [HttpPost]
        public async Task<IActionResult> Add(StoreViewModel store)
        {

            if (ModelState.IsValid)
            { 
                var list = await _storeService.AddAsync(store);
                if (list)
                {
                    TempData["Success"] = "Add Store Success";
                    return RedirectToAction("Index");
                }
                ViewBag.Err = "Add Store Failure";
                return View(store);
            }
            return View(store);
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
            var store = await _storeService.GetIdAsync(id.Value);
            if (store == null)
            {
                return NotFound();
            }
 
            return View(store);
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
                    TempData["Success"] = "Edit Store Success";
                    return RedirectToAction("Index");
                }
                ViewBag.Err = "Edit Store Failure";
                return View(storeViewModel);
            }
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
            await _storeService.DeleteAsync(id.Value);
            TempData["Success"] = "Delete Store Success";
            return  RedirectToAction("Index");
        }
   }
}