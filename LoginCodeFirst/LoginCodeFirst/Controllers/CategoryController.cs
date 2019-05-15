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


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var liststore = await _categoryServices.GetCategoryListAsync();
            return View(liststore);
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Add(CategoryViewModel category)
        {

            if (ModelState.IsValid)
            {
                var list = await _categoryServices.AddAsync(category);
                if (list)
                {
                    TempData["Category"] = "Add Category Success";
                    return RedirectToAction("Index");
                }
                ViewBag.ErrorMessage = "Add Category Failure";
                return View(category);
            }
            return View(category);
        }
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

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryViewModel category)
        {

            if (ModelState.IsValid)
            {
                var list = await _categoryServices.EditAsync(category);
                if (list)
                {
                    TempData["Category"] = "Edit Category Success";
                    return RedirectToAction("Index");
                }
                ViewBag.Err = "Edit Category Failure";
                return View(category);
            }
            return View(category);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            await _categoryServices.DeleteAsync(id.Value);
            TempData["Category"] = "Delete Category Success";
            return RedirectToAction("Index");
        }
    }
}
