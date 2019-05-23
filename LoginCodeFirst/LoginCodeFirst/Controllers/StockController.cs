using System.Threading.Tasks;
using LoginCodeFirst.Filter;
using LoginCodeFirst.Resources;
using LoginCodeFirst.Services;
using LoginCodeFirst.ViewModels.Stock;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LoginCodeFirst.Controllers
{
    [ServiceFilter(typeof(ActionFilter))]
    public class StockController : Controller
    {
        private readonly IStockServices _stockServices;
        private readonly IProductServices _productServices;
        private readonly IStoreServices _storeServices;
        private readonly ResourcesServices<CommonResources> _commonLocalizer;
        private readonly ResourcesServices<StockResources> _stockLocalizer;
        public StockController(IStockServices stockServices, 
            IProductServices productServices,
            IStoreServices storeServices,
            ResourcesServices<CommonResources> commonLocalizer,
            ResourcesServices<StockResources> stockLocalizer
            )
        {
            _stockServices = stockServices;
            _productServices = productServices;
            _storeServices = storeServices;
            _commonLocalizer = commonLocalizer;
            _stockLocalizer = stockLocalizer;
        }

        /// <summary>
        /// Index Stock Get Funciton
        /// </summary>
        /// <returns>Stock Index View</returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var listStock = await _stockServices.GetStockListAsync();
            return View(listStock);
        }

        /// <summary>
        ///  Add Stock Get Funciton
        /// </summary>
        /// <returns>Stock Index View</returns>
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.ProductId = new SelectList(_productServices.GetProducts(), "ProductId", "ProductName");
            ViewBag.StoreId = new SelectList(_storeServices.GetStores(), "StoreId", "StoreName");
            return View();
        }

        /// <summary>
        /// Add Stock Post Funciton
        /// </summary>
        /// <param name="stockViewModel"></param>
        /// <returns>Stock Index View</returns>
        [HttpPost]
        public async Task<IActionResult> Add(StockViewModel stockViewModel)
        {

            if (ModelState.IsValid)
            { 
                var stock = await _stockServices.AddAsync(stockViewModel);
                if (stock)
                {
                    TempData["Success"] = _commonLocalizer.GetLocalizedHtmlString("msg_AddSuccess").ToString();
                    return RedirectToAction("Index");
                }
                ViewBag.ProductId = new SelectList(_productServices.GetProducts(), "ProductId", "ProductName",stockViewModel.ProductId);
                ViewBag.StoreId = new SelectList(_storeServices.GetStores(), "StoreId", "StoreName",stockViewModel.StoreId);
                ViewData["Error"] = _stockLocalizer.GetLocalizedHtmlString("err_AddStockFailure");
                return View(stockViewModel);
            }
            ViewBag.ProductId = new SelectList(_productServices.GetProducts(), "ProductId", "ProductName",stockViewModel.ProductId);
            ViewBag.StoreId = new SelectList(_storeServices.GetStores(), "StoreId", "StoreName",stockViewModel.StoreId);
            ViewData["Error"] = _stockLocalizer.GetLocalizedHtmlString("err_AddStockFailure");
            return View(stockViewModel);
        }

        /// <summary>
        /// Edit Stock Get Function
        /// </summary>
        /// <param name="storeId"></param>
        /// <param name="productId"></param>
        /// <returns>Stock Index View</returns>
        [HttpGet]
        public async Task<IActionResult> Edit(int? storeId, int? productId)
        {
            if (storeId == null || productId == null)
            {
                return BadRequest();
            }
            var getId = await _stockServices.GetIdAsync(storeId.Value, productId.Value);
            if (getId == null)
            {
                return BadRequest();
            }
            ViewBag.ProductId = new SelectList(_productServices.GetProducts(), "ProductId", "ProductName");
            ViewBag.StoreId = new SelectList(_storeServices.GetStores(), "StoreId", "StoreName");
            return View(getId);
        }

        /// <summary>
        /// Edit Stock Post Function
        /// </summary>
        /// <param name="stockViewModel"></param>
        /// <returns>Stock Index View</returns>
        [HttpPost]
        public async Task<IActionResult> Edit(StockViewModel stockViewModel)
        {

            if (ModelState.IsValid)
            {
                  var stock =   await _stockServices.EditAsync(stockViewModel);
                if (stock)
                {
                    TempData["Success"] = _commonLocalizer.GetLocalizedHtmlString("msg_EditSuccess").ToString();
                    return RedirectToAction("Index"); 
                }
                ViewBag.ProductId = new SelectList(_productServices.GetProducts(), "ProductId", "ProductName",stockViewModel.ProductId);
                ViewBag.StoreId = new SelectList(_storeServices.GetStores(), "StoreId", "StoreName",stockViewModel.StoreId);
                ViewData["Error"] = _stockLocalizer.GetLocalizedHtmlString("err_EditStockFailure");
                return View(stockViewModel);
                    
            } 
            ViewBag.ProductId = new SelectList(_productServices.GetProducts(), "ProductId", "ProductName",stockViewModel.ProductId);
            ViewBag.StoreId = new SelectList(_storeServices.GetStores(), "StoreId", "StoreName",stockViewModel.StoreId);
            ViewData["Error"] = _stockLocalizer.GetLocalizedHtmlString("err_EditStockFailure");
            return View(stockViewModel);
        }

        /// <summary>
        /// Delete Stock Get Function
        /// </summary>
        /// <param name="storeId"></param>
        /// <param name="productId"></param>
        /// <returns>Stock Index View</returns>
        [HttpGet]
        public async Task<IActionResult> Delete(int? storeId, int? productId)
        {
            if (storeId == null || productId == null)
            {
                return BadRequest();
            }
            var stock = await _stockServices.DeleteAsync(storeId.Value,productId.Value);
            if (stock)
            {
                TempData["Success"] = _commonLocalizer.GetLocalizedHtmlString("msg_DeleteSuccess").ToString();
                return  RedirectToAction("Index");
            }
            TempData["Error"] = _commonLocalizer.GetLocalizedHtmlString("msg_DeleteError").ToString();
            return  RedirectToAction("Index");
        }
    }
}