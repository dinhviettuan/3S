using System.Threading.Tasks;
using LoginCodeFirst.Resources;
using LoginCodeFirst.Services;
using LoginCodeFirst.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Serilog;

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
        /// Index Product
        /// </summary>
        /// <returns>Product Index View</returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var list = await _productServices.GetProductListAsync();
            Log.Information("Get Product List Async");
            return View(list);
        }


        /// <summary>
        /// Add Product
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
        /// Add Product
        /// </summary>
        /// <param name="productViewModel">ProductViewModel</param>
        /// <returns>Product Index View</returns>
        [HttpPost]
        public async Task<IActionResult> Add(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                var products = await _productServices.AddAsync(productViewModel);
                if (products)
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
            Log.Error("Add Product Error");
            return View(productViewModel);
        }

        /// <summary>
        /// Edit Product
        /// </summary>
        /// <param name="id">Product Id</param>
        /// <returns>Product Index View</returns>
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                Log.Warning("Id Equal Null");
                return BadRequest();
            }

            var product =  await _productServices.GetIdAsync(id.Value);
            if (product == null)
            {
                Log.Warning("Product Equal Null");
                return BadRequest();
            }
            ViewBag.CategoryId = new SelectList(_categoryServices.GetCategorys(), "CategoryId", "CategoryName");
            ViewBag.BrandId = new SelectList(_brandServices.GetBrands(), "BrandId", "BrandName");
            return View(product);
        }

        /// <summary>
        /// Edit Product
        /// </summary>
        /// <param name="productViewModel">ProductViewModel</param>
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
            Log.Error("Edit Product Error");
            return View(productViewModel);
        }

        /// <summary>
        /// Delete Product
        /// </summary>
        /// <param name="id">Product Id</param>
        /// <returns>Product Index View</returns>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                Log.Warning("Id Product Equal Null");
                return BadRequest();
            }
            var product = await _productServices.DeleteAsync(id.Value);
            if (product)
            {
                TempData["Success"] = _commonLocalizer.GetLocalizedHtmlString("msg_DeleteSuccess").ToString();
                return  RedirectToAction("Index");
            }
            TempData["Error"] = _commonLocalizer.GetLocalizedHtmlString("msg_DeleteError").ToString();
            Log.Error("Delete Product Error");
            return  RedirectToAction("Index");
        }
    }
}