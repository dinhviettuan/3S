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
            var list = await _productServices.GetListAsync();
            return View(list);
        }
        


        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.CategoryId = new SelectList(_categoryServices.Categories, "CategoryId", "CategoryName");
            ViewBag.BrandId = new SelectList(_brandServices.Brands, "BrandId", "BrandName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddViewModel product)
        {
            if (ModelState.IsValid)
            {
                var list = await _productServices.Add(product);
                if (list)
                {
                    ViewBag.CategoryId = new SelectList(_categoryServices.Categories, "CategoryId", "CategoryName",product.CategoryId);
                    ViewBag.BrandId = new SelectList(_brandServices.Brands, "BrandId", "BrandName",product.BrandId);
                    TempData["Product"] = "Add Product Success";
                    return RedirectToAction("Index");
                }
            }

            ViewBag.ErrorMessage = "Add Product Failure";
            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var list =  await _productServices.GetId(id);
            if (list == null)
            {
                return NotFound();
            }
            ViewBag.CategoryId = new SelectList(_categoryServices.Categories, "CategoryId", "CategoryName");
            ViewBag.BrandId = new SelectList(_brandServices.Brands, "BrandId", "BrandName");
            return View(list);
        }
        
        [HttpPost]
        public async Task<IActionResult> Edit(EditViewModel product)
        {

            if (ModelState.IsValid)
            {
                ViewBag.CategoryId = new SelectList(_categoryServices.Categories, "CategoryId", "CategoryName", product.CategoryId);
                ViewBag.BrandId = new SelectList(_brandServices.Brands, "BrandId", "BrandName",product.BrandId);
               await _productServices.Edit(product);
                TempData["Product"] = "Edit Product Success";
                return RedirectToAction("Index");
            }

            ViewBag.Err = "Edit Product Failure";
            return View(product);
        }
        
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            await _productServices.Delete(id);
            TempData["Product"] = "Delete Product Success";
            return  RedirectToAction("Index");
        }
    }
}