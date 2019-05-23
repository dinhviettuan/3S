using System.Threading.Tasks;
using LoginCodeFirst.Filter;
using LoginCodeFirst.Resources;
using LoginCodeFirst.Services;
using LoginCodeFirst.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LoginCodeFirst.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductServices _productServices;
        private readonly ICategoryServices _categoryServices;
        private readonly IBrandServices _brandServices;
        private readonly ResourcesServices<CommonResources> _commonLocalizer;
        private readonly ResourcesServices<ProductResources> _productLocalizer;

        public ProductController(IProductServices productServices,
            ICategoryServices categoryServices, 
            IBrandServices brandServices,
            ResourcesServices<CommonResources> commonLocalizer,
            ResourcesServices<ProductResources> productLocalizer
        )
        {
            _productServices = productServices;
            _categoryServices = categoryServices;
            _brandServices = brandServices;
            _commonLocalizer = commonLocalizer;
            _productLocalizer = productLocalizer;
        }


        /// <summary>
        /// Index Product Get Function
        /// </summary>
        /// <returns>Product Index View</returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var list = await _productServices.GetProductListAsync();
            return View(list);
        }


        /// <summary>
        /// Add Product Get Function
        /// </summary>
        /// <returns>Product Index View</returns>
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.CategoryId = new SelectList(_categoryServices.GetCategorys(), "CategoryId", "CategoryName");
            ViewBag.BrandId = new SelectList(_brandServices.GetBrands(), "BrandId", "BrandName");
            return View();
        }

        /// <summary>
        /// Add Product Post Function
        /// </summary>
        /// <param name="productViewModel"></param>
        /// <returns>Product Index View</returns>
        [HttpPost]
        public async Task<IActionResult> Add(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                var product = await _productServices.AddAsync(productViewModel);
                if (product)
                {
                    TempData["Success"] = _commonLocalizer.GetLocalizedHtmlString("msg_AddSuccess").ToString();
                    return RedirectToAction("Index");
                }
                ViewData["Error"] = _productLocalizer.GetLocalizedHtmlString("err_AddProductFailure");
                ViewBag.CategoryId = new SelectList(_categoryServices.GetCategorys(), "CategoryId", "CategoryName",productViewModel.CategoryId);
                ViewBag.BrandId = new SelectList(_brandServices.GetBrands(), "BrandId", "BrandName",productViewModel.BrandId);
                return View(productViewModel);                
            }
            ViewBag.CategoryId = new SelectList(_categoryServices.GetCategorys(), "CategoryId", "CategoryName",productViewModel.CategoryId);
            ViewBag.BrandId = new SelectList(_brandServices.GetBrands(), "BrandId", "BrandName",productViewModel.BrandId);
            return View(productViewModel);
        }

        /// <summary>
        /// Edit Product Get Function
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Product Index View</returns>
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var getId =  await _productServices.GetIdAsync(id.Value);
            if (getId == null)
            {
                return BadRequest();
            }
            ViewBag.CategoryId = new SelectList(_categoryServices.GetCategorys(), "CategoryId", "CategoryName");
            ViewBag.BrandId = new SelectList(_brandServices.GetBrands(), "BrandId", "BrandName");
            return View(getId);
        }

        /// <summary>
        /// Edit Product Post Function
        /// </summary>
        /// <param name="productViewModel"></param>
        /// <returns>Product Index View</returns>
        [HttpPost]
        public async Task<IActionResult> Edit(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                var product = await _productServices.EditAsync(productViewModel);
                if (product)
                {
                    ViewBag.CategoryId = new SelectList(_categoryServices.GetCategorys(), "CategoryId", "CategoryName", productViewModel.CategoryId);
                    ViewBag.BrandId = new SelectList(_brandServices.GetBrands(), "BrandId", "BrandName",productViewModel.BrandId);
                    TempData["Success"] = _commonLocalizer.GetLocalizedHtmlString("msg_EditSuccess").ToString();
                    return RedirectToAction("Index"); 
                }
                ViewData["Error"] = _productLocalizer.GetLocalizedHtmlString("err_EditProductFailure");
                return View(productViewModel);
            }
            return View(productViewModel);
        }

        /// <summary>
        /// Delete Product Get Function
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Product Index View</returns>
        [Authorize(Roles = "User")]
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var product = await _productServices.DeleteAsync(id.Value);
            if (product)
            {
                TempData["Success"] = _commonLocalizer.GetLocalizedHtmlString("msg_DeleteSuccess").ToString();
                return  RedirectToAction("Index");
            }
            TempData["Error"] = _commonLocalizer.GetLocalizedHtmlString("msg_DeleteError").ToString();
            return  RedirectToAction("Index");
        }
    }
}