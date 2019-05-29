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
    public class CategoryController : Controller
    {
        private readonly ICategoryServices _categoryServices;
        private readonly ResourcesServices<CommonResources> _commonLocalizer;
        private readonly ResourcesServices<CategoryResources> _categoryLocalizer;
        public CategoryController(ICategoryServices categoryServices,
            ResourcesServices<CommonResources> commonLocalizer,
            ResourcesServices<CategoryResources> categoryLocalizer)
        {
            _categoryServices = categoryServices;
            _categoryLocalizer = categoryLocalizer;
            _commonLocalizer = commonLocalizer;
        }


        /// <summary>
        /// Index Category
        /// </summary>
        /// <returns>Category Index View</returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var liststore = await _categoryServices.GetCategoryListAsync();
            Log.Information("Get Category List Async");
            return View(liststore);
        }

        /// <summary>
        ///  Add Category
        /// </summary>
        /// <returns>Category Index View</returns>
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        /// <summary>
        /// Add Category
        /// </summary>
        /// <param name="categoryViewModel">CategoryViewModel</param>
        /// <returns>Category Index View</returns>
        [HttpPost]
        public async Task<IActionResult> Add(CategoryViewModel categoryViewModel)
        {
            if (ModelState.IsValid)
            {
                var categories = await _categoryServices.AddAsync(categoryViewModel);
                if (categories)
                {
                    TempData["Success"] =_commonLocalizer.GetLocalizedHtmlString("msg_AddSuccess").ToString();
                    return RedirectToAction("Index");
                }
                ViewData["Error"] =_categoryLocalizer.GetLocalizedHtmlString("err_AddCategoryFailure");
                return View(categoryViewModel);
            }
            Log.Error("Add Category Error");
            return View(categoryViewModel);
        }

        /// <summary>
        /// Edit Category
        /// </summary>
        /// <param name="id">Category id</param>
        /// <returns>Category Index View</returns>
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                Log.Warning("Id Equal Null");
                return BadRequest();
            }
            var categoryViewModel = await _categoryServices.GetIdAsync(id.Value);
            if (categoryViewModel == null)
            {
                Log.Warning("Category Equal Null");
                return BadRequest();
            }
            return View(categoryViewModel);
        }

        /// <summary>
        /// Edit Category
        /// </summary>
        /// <param name="categoryViewModel">CategoryViewModel</param>
        /// <returns>Category Index View</returns>
        [HttpPost]
        public async Task<IActionResult> Edit(CategoryViewModel categoryViewModel)
        {
            if (ModelState.IsValid)
            {
                var category = await _categoryServices.EditAsync(categoryViewModel);
                if (category)
                {
                    TempData["Success"] = _commonLocalizer.GetLocalizedHtmlString("msg_EditSuccess").ToString();
                    return RedirectToAction("Index");
                }
                ViewData["Error"] = _categoryLocalizer.GetLocalizedHtmlString("err_EditCategoryFailure");
                return View(categoryViewModel);
            }
            Log.Error("Edit Category Error");
            return View(categoryViewModel);
        }

        /// <summary>
        /// Delete Category 
        /// </summary>
        /// <param name="id">Category id</param>
        /// <returns>Category Index View</returns>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                Log.Warning("Id Category Equal Null");
                return BadRequest();
            }
            var category = await _categoryServices.DeleteAsync(id.Value);
            if (category)
            {
                TempData["Success"] = _categoryLocalizer.GetLocalizedHtmlString("msg_DeleteSuccess").ToString();
                return RedirectToAction("Index");            
            }
            TempData["Error"] = _categoryLocalizer.GetLocalizedHtmlString("msg_DeleteError").ToString();
            Log.Error("Delete Category Error");
            return RedirectToAction("Index");
        }
    }
}
