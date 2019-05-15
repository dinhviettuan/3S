using System.Threading.Tasks;
using LoginCodeFirst.Services;
using LoginCodeFirst.ViewModels.Brand;
using Microsoft.AspNetCore.Mvc;

namespace LoginCodeFirst.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrandServices _brandServices;

        public BrandController(IBrandServices brandServices)
        {
            _brandServices  = brandServices;
        }
        
        
        
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var listBrand = await _brandServices.GetBrandListAsync();
            return View(listBrand);
        }

        
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Add(BrandViewModel brand)
        {

            if (ModelState.IsValid)
            { 
                var  list= await _brandServices.AddAsync(brand);
                if (list)
                {
                    TempData["Success"] = "Add Brand Success";
                    return RedirectToAction("Index"); 
                }
                ViewBag.Err = "Add Brand Failure";
                return View(brand);
            }
            return View(brand);
        }

        
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var brand = await _brandServices.GetIdAsync(id.Value);
            if (brand == null)
            {
                return NotFound();
            }

            return View(brand);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(BrandViewModel brand)
        {

            if (ModelState.IsValid)
            {
                var list= await _brandServices.EditAsync(brand);
                if (list)
                {
                    TempData["Success"] = "Edit Brand Success";
                    return RedirectToAction("Index");
                } 
                ViewBag.Err = "Edit Brand Failure";
                return View(brand);
            }
            return View(brand);
        }
        
        [HttpGet]
        public async  Task<IActionResult> Delete(int? id)
        {
            await _brandServices.DeleteAsync(id.Value);
<<<<<<< HEAD
            TempData["Success"] = "Delete Brand Success";
=======
            TempData["Brand"] = "Delete Brand Success";
>>>>>>> master
            return  RedirectToAction("Index");
        }   
    }
}