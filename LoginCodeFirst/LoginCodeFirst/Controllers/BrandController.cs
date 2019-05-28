using System.Threading.Tasks;
using LoginCodeFirst.Resources;
using LoginCodeFirst.Services;
using LoginCodeFirst.ViewModels.Brand;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;

namespace LoginCodeFirst.Controllers
{
//    [ServiceFilter(typeof(ActionFilter))]
    [Authorize]
    public class BrandController : Controller
    {
        private readonly IBrandServices _brandServices;
        private readonly ResourcesServices<CommonResources> _commonLocalizer;
        private readonly ResourcesServices<BrandResources> _brandLocalizer;

        public BrandController(IBrandServices brandServices,
            ResourcesServices<CommonResources> commonLocalizer,
            ResourcesServices<BrandResources> brandLocalizer)
        {
            _brandServices = brandServices;
            _commonLocalizer = commonLocalizer;
            _brandLocalizer = brandLocalizer;
        }
               
        /// <summary>
        /// Index Brand
        /// </summary>
        /// <returns>Brand Index View</returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var listBrands = await _brandServices.GetBrandListAsync();
            Log.Information("Get Brand List Async");
            return View(listBrands);
        }

        /// <summary>
        /// Add Brand
        /// </summary>
        /// <returns>Brand Index View</returns>
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        
        /// <summary>
        /// Add Brand
        /// </summary>
        /// <param name="brandViewModel">BrandViewModel</param>
        /// <returns>Brand Index View</returns>
        [HttpPost]
        public async Task<IActionResult> Add(BrandViewModel brandViewModel)
        {
            if (ModelState.IsValid)
            { 
                var  brands = await _brandServices.AddAsync(brandViewModel);
                if (brands)
                {
                    TempData["Success"] = _commonLocalizer.GetLocalizedHtmlString("msg_AddSuccess").ToString();
                    return RedirectToAction("Index"); 
                }
                ViewData["Error"] = _brandLocalizer.GetLocalizedHtmlString("err_AddBrandFailure");
                return View(brandViewModel);
            }
            Log.Error("Add Brand Error");
            return View(brandViewModel);
        }

        /// <summary>
        /// Edit Brand
        /// </summary>
        /// <param name="id">Brand Id</param>
        /// <returns>Brand Index View</returns>
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                Log.Error("Id equal null");
                return BadRequest();
            }
            var brand = await _brandServices.GetIdAsync(id.Value);
            if (brand == null)
            {
                Log.Error("brand equal null");
                return BadRequest();
            }
            return View(brand);
        }

        /// <summary>
        /// Edit Brand
        /// </summary>
        /// <param name="brandViewModel">BrandViewModel</param>
        /// <returns>Brand Index View</returns>
        [HttpPost]
        public async Task<IActionResult> Edit(BrandViewModel brandViewModel)
        {
            if (ModelState.IsValid)
            {
                var brand = await _brandServices.EditAsync(brandViewModel);
                if (brand)
                {
                    TempData["Success"] = _commonLocalizer.GetLocalizedHtmlString("msg_EditSuccess").ToString();
                    return RedirectToAction("Index");
                } 
                ViewData["Error"] =_brandLocalizer.GetLocalizedHtmlString("err_EditBrandFailure");                
                return View(brandViewModel);
            } 
            Log.Error("Edit Brand Error");
            return View(brandViewModel);
        }

        /// <summary>
        /// Delete Brand
        /// </summary>
        /// <param name="id">Brand Id</param>
        /// <returns>Brand Index View</returns>       
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async  Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                Log.Warning("Id Brand Equal Null");
                return BadRequest();
            }         
            var brand = await _brandServices.DeleteAsync(id.Value);
            if (brand)
            {
                TempData["Success"] = _commonLocalizer.GetLocalizedHtmlString("msg_DeleteSuccess").ToString();
                return  RedirectToAction("Index");
            }
            TempData["Error"] = _commonLocalizer.GetLocalizedHtmlString("msg_DeleteError").ToString();
            Log.Warning("Brand Equal Null");
            return  RedirectToAction("Index");
        }   
    }
}