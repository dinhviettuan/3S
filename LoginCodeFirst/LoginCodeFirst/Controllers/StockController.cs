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
            Log.Error("Get Stock List Async");
            return View(listStock);
        }

        /// <summary>
        ///  Add Stock Get Funciton
        /// </summary>
        /// <returns>Stock Index View</returns>
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.ProductId = new SelectList(_productServices.GetProducts(), "Id", "ProductName");
            ViewBag.StoreId = new SelectList(_storeServices.GetStores(), "Id", "StoreName");
            return View();
        }

        /// <summary>
        /// Add Stock
        /// </summary>
        /// <param name="stockViewModel">StockViewModel</param>
        /// <returns>Stock Index View</returns>
        [HttpPost]
        public async Task<IActionResult> Add(StockViewModel stockViewModel)
        {
            if (ModelState.IsValid)
            { 
                var stocks = await _stockServices.AddAsync(stockViewModel);
                if (stocks)
                {
                    TempData["Success"] = _commonLocalizer.GetLocalizedHtmlString("msg_AddSuccess").ToString();
                    return RedirectToAction("Index");
                }
                ViewBag.ProductId = new SelectList(_productServices.GetProducts(), "Id", "ProductName",stockViewModel.ProductId);
                ViewBag.StoreId = new SelectList(_storeServices.GetStores(), "Id", "StoreName",stockViewModel.StoreId);
                ViewData["Error"] = _stockLocalizer.GetLocalizedHtmlString("err_AddStockFailure");
                return View(stockViewModel);
            }
            ViewBag.ProductId = new SelectList(_productServices.GetProducts(), "Id", "ProductName",stockViewModel.ProductId);
            ViewBag.StoreId = new SelectList(_storeServices.GetStores(), "Id", "StoreName",stockViewModel.StoreId);
            Log.Error("Add Stock Error");
            return View(stockViewModel);
        }

        /// <summary>
        /// Edit Stock
        /// </summary>
        /// <param name="storeId">Store Id</param>
        /// <param name="productId">Product Id</param>
        /// <returns>Stock Index View</returns>
        [HttpGet]
        public async Task<IActionResult> Edit(int? storeId, int? productId)
        {
            if (storeId == null || productId == null)
            {
                Log.Warning("Id Stock Equal Null ");
                return BadRequest();
            }
            var stock = await _stockServices.GetIdAsync(storeId.Value, productId.Value);
            if (stock == null)
            {
                Log.Warning("Stock Equal Null");
                return BadRequest();
            }
            ViewBag.ProductId = new SelectList(_productServices.GetProducts(), "Id", "ProductName");
            ViewBag.StoreId = new SelectList(_storeServices.GetStores(), "Id", "StoreName");
            return View(stock);
        }

        /// <summary>
        /// Edit Stock
        /// </summary>
        /// <param name="stockViewModel">StockViewModel</param>
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
                ViewBag.ProductId = new SelectList(_productServices.GetProducts(), "Id", "ProductName",stockViewModel.ProductId);
                ViewBag.StoreId = new SelectList(_storeServices.GetStores(), "Id", "StoreName",stockViewModel.StoreId);
                ViewData["Error"] = _stockLocalizer.GetLocalizedHtmlString("err_EditStockFailure");
                return View(stockViewModel);                    
            } 
            ViewBag.ProductId = new SelectList(_productServices.GetProducts(), "Id", "ProductName",stockViewModel.ProductId);
            ViewBag.StoreId = new SelectList(_storeServices.GetStores(), "Id", "StoreName",stockViewModel.StoreId);
            Log.Error("Edit Stock Error");
            return View(stockViewModel);
        }

        /// <summary>
        /// Delete Stock
        /// </summary>
        /// <param name="storeId">Store Id</param>
        /// <param name="productId">Product Id</param>
        /// <returns>Stock Index View</returns>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? storeId, int? productId)
        {
            if (storeId == null || productId == null)
            {
                Log.Warning("Id Stock Equal Null");
                return BadRequest();
            }
            var stock = await _stockServices.DeleteAsync(storeId.Value,productId.Value);
            if (stock)
            {
                TempData["Success"] = _commonLocalizer.GetLocalizedHtmlString("msg_DeleteSuccess").ToString();
                return  RedirectToAction("Index");
            }
            TempData["Error"] = _commonLocalizer.GetLocalizedHtmlString("msg_DeleteError").ToString();
            Log.Error("Delete Stock Error");
            return  RedirectToAction("Index");
        }
    }
}