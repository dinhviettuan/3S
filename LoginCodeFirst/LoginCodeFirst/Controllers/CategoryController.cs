using System.Threading.Tasks;
using LoginCodeFirst.Services;
using LoginCodeFirst.ViewModels.Category;
using Microsoft.AspNetCore.Mvc;

namespace LoginCodeFirst.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryServices _categoryServices;

        public CategoryController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }


        /// <summary>
        /// Index Category Get Function
        /// </summary>
        /// <returns>Category Index View</returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var liststore = await _categoryServices.GetCategoryListAsync();
            return View(liststore);
        }

        /// <summary>
        ///  Add Category Get Function
        /// </summary>
        /// <returns>Category Index View</returns>
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        /// <summary>
        /// Add Category Post Function
        /// </summary>
        /// <param name="category"></param>
        /// <returns>Category Index View</returns>
        [HttpPost]
        public async Task<IActionResult> Add(CategoryViewModel category)
        {

            if (ModelState.IsValid)
            {
                var list = await _categoryServices.AddAsync(category);
                if (list)
                {
                    TempData["Success"] = "Add Category Success";
                    return RedirectToAction("Index");
                }
                ViewBag.Err = "Add Category Failure";
                return View(category);
            }
            return View(category);
        }

        /// <summary>
        /// Edit Category Get Function
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Category Index View</returns>
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var list = await _categoryServices.GetIdAsync(id.Value);
            if (list == null)
            {
                return NotFound();
            }

            return View(list);
        }

        /// <summary>
        /// Edit Category Post Function
        /// </summary>
        /// <param name="category"></param>
        /// <returns>Category Index View</returns>
        [HttpPost]
        public async Task<IActionResult> Edit(CategoryViewModel category)
        {

            if (ModelState.IsValid)
            {
                var list = await _categoryServices.EditAsync(category);
                if (list)
                {
                    TempData["Success"] = "Edit Category Success";
                    return RedirectToAction("Index");
                }
                ViewBag.Err = "Edit Category Failure";
                return View(category);
            }
            return View(category);
        }

        /// <summary>
        /// Delete Category Get Function
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Category Index View</returns>
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            await _categoryServices.DeleteAsync(id.Value);

            TempData["Success"] = "Delete Category Success";

 
            return RedirectToAction("Index");
        }
    }
}
