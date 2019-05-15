using System.Threading.Tasks;
using LoginCodeFirst.Services;
using LoginCodeFirst.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LoginCodeFirst.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductServices _productServices;

        public readonly ICategoryServices _categoryServices;

        public readonly IBrandServices _brandServices;

        public ProductController(IProductServices productServices, ICategoryServices categoryServices, IBrandServices brandServices)
        {
            _productServices = productServices;

            _categoryServices = categoryServices;

            _brandServices = brandServices;
        }



        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var list = await _productServices.GetProductListAsync();
            return View(list);
        }
        


        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.CategoryId = new SelectList(_categoryServices.GetCategorys(), "CategoryId", "CategoryName");
            ViewBag.BrandId = new SelectList(_brandServices.GetBrands(), "BrandId", "BrandName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                var list = await _productServices.AddAsync(product);
                if (list)
                {
                    TempData["Success"] = "Add Product Success";
                    return RedirectToAction("Index");
                }
                ViewBag.ErrorMessage = "Add Product Failure";
                ViewBag.CategoryId = new SelectList(_categoryServices.GetCategorys(), "CategoryId", "CategoryName",product.CategoryId);
                ViewBag.BrandId = new SelectList(_brandServices.GetBrands(), "BrandId", "BrandName",product.BrandId);
                return View(product);
                
            }
            ViewBag.CategoryId = new SelectList(_categoryServices.GetCategorys(), "CategoryId", "CategoryName",product.CategoryId);
            ViewBag.BrandId = new SelectList(_brandServices.GetBrands(), "BrandId", "BrandName",product.BrandId);
            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var list =  await _productServices.GetIdAsync(id.Value);
            if (list == null)
            {
                return BadRequest();
            }
            ViewBag.CategoryId = new SelectList(_categoryServices.GetCategorys(), "CategoryId", "CategoryName");
            ViewBag.BrandId = new SelectList(_brandServices.GetBrands(), "BrandId", "BrandName");
            return View(list);
        }
        
        [HttpPost]
        public async Task<IActionResult> Edit(ProductViewModel product)
        {

            if (ModelState.IsValid)
            {
                var list = await _productServices.EditAsync(product);
                if (list)
                {
                    ViewBag.CategoryId = new SelectList(_categoryServices.GetCategorys(), "CategoryId", "CategoryName", product.CategoryId);
                    ViewBag.BrandId = new SelectList(_brandServices.GetBrands(), "BrandId", "BrandName",product.BrandId);
                    TempData["Success"] = "Edit Product Success";
                    return RedirectToAction("Index"); 
                }
                ViewBag.Err = "Edit Product Failure";
                return View(product);
            }
            return View(product);
        }
        
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            await _productServices.DeleteAsync(id.Value);

            TempData["Success"] = "Delete Product Success";
            return  RedirectToAction("Index");
        }
    }
}