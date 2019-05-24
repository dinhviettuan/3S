using System.Threading.Tasks;
using LoginCodeFirst.Resources;
using LoginCodeFirst.Services;
using LoginCodeFirst.ViewModels.Brand;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
                var  brand = await _brandServices.AddAsync(brandViewModel);
                if (brand)
                {
                    TempData["Success"] = _commonLocalizer.GetLocalizedHtmlString("msg_AddSuccess").ToString();
                    return RedirectToAction("Index"); 
                }
                ViewData["Error"] = _brandLocalizer.GetLocalizedHtmlString("err_AddBrandFailure");
                return View(brandViewModel);
            }
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
                return BadRequest();
            }
            var brand = await _brandServices.GetIdAsync(id.Value);
            if (brand == null)
            {
                return NotFound();
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
            return View(brandViewModel);
        }

        /// <summary>
        /// Delete Brand
        /// </summary>
        /// <param name="id">Brand Id</param>
        /// <returns>Brand Index View</returns>
        [Authorize(Roles = "User")]
        [HttpGet]
        public async  Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }         
            var brand = await _brandServices.DeleteAsync(id.Value);
            if (brand)
            {
                TempData["Success"] = _commonLocalizer.GetLocalizedHtmlString("msg_DeleteSuccess").ToString();
                return  RedirectToAction("Index");
            }
            TempData["Error"] = _commonLocalizer.GetLocalizedHtmlString("msg_DeleteError").ToString();
            return  RedirectToAction("Index");
        }   
    }
}