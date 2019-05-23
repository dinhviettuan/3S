using System.Threading.Tasks;
using LoginCodeFirst.Filter;
using LoginCodeFirst.Resources;
using LoginCodeFirst.Services;
using LoginCodeFirst.ViewModels.Category;
using Microsoft.AspNetCore.Mvc;

namespace LoginCodeFirst.Controllers
{
    [ServiceFilter(typeof(ActionFilter))]
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
        /// <param name="categoryViewModel">CategoryViewModel</param>
        /// <returns>Category Index View</returns>
        [HttpPost]
        public async Task<IActionResult> Add(CategoryViewModel categoryViewModel)
        {

            if (ModelState.IsValid)
            {
                var category = await _categoryServices.AddAsync(categoryViewModel);
                if (category)
                {
                    TempData["Success"] =_commonLocalizer.GetLocalizedHtmlString("msg_AddSuccess").ToString();
                    return RedirectToAction("Index");
                }
                ViewData["Error"] =_categoryLocalizer.GetLocalizedHtmlString("err_AddCategoryFailure");
                return View(categoryViewModel);
            }
            ViewData["Error"] =_categoryLocalizer.GetLocalizedHtmlString("err_AddCategoryFailure");
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
                return BadRequest();
            }
            var getId = await _categoryServices.GetIdAsync(id.Value);
            if (getId == null)
            {
                return NotFound();
            }

            return View(getId);
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
            ViewData["Error"] = _categoryLocalizer.GetLocalizedHtmlString("err_EditCategoryFailure");
            return View(categoryViewModel);
        }

        /// <summary>
        /// Delete Category 
        /// </summary>
        /// <param name="id">Category id</param>
        /// <returns>Category Index View</returns>
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var category = await _categoryServices.DeleteAsync(id.Value);
            if (category)
            {
                TempData["Success"] = _categoryLocalizer.GetLocalizedHtmlString("msg_DeleteSuccess").ToString();
                return RedirectToAction("Index");            
            }
            TempData["Error"] = _categoryLocalizer.GetLocalizedHtmlString("msg_DeleteError").ToString();
            return RedirectToAction("Index");
        }
    }
}
