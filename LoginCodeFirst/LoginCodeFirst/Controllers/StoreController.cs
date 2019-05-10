using System.Threading.Tasks;
using LoginCodeFirst.Services;
using LoginCodeFirst.ViewModels.Store;
using Microsoft.AspNetCore.Mvc;


namespace LoginCodeFirst.Controllers
{
    public class StoreController : Controller
    {
        private readonly IStoreServices _storeService;
        public StoreController(IStoreServices storeService)
        {
            _storeService = storeService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var liststore = await _storeService.GetStore();
            return View(liststore);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(IndexViewModel store)
        {

            if (ModelState.IsValid)
            { 
                var list = await _storeService.Add(store);
                if (list)
                {
                    TempData["Store"] = "Add Store Success";
                    return RedirectToAction("Index");
                }
            }

            ViewBag.Err = "Add Store Failure";
            return View(store);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var store = await _storeService.GetId(id);
            if (store == null)
            {
                return NotFound();
            }
 
            return View(store);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(IndexViewModel store)
        {

            if (ModelState.IsValid)
            {
              await _storeService.Edit(store);
                TempData["Store"] = "Edit Store Success";
                return RedirectToAction("Index");
            }

            ViewBag.Err = "Edit Store Failure";
            return View(store);
        }
//        
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            await _storeService.Delete(id);
            TempData["Store"] = "Delete Store Success";
            return  RedirectToAction("Index");
        }
   }
}