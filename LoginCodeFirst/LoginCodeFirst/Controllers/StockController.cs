using System.Threading.Tasks;
using LoginCodeFirst.Filter;
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

        public StockController(IStockServices stockServices, IProductServices productServices,IStoreServices storeServices)
        {
            _stockServices = stockServices;
            _productServices = productServices;
            _storeServices = storeServices;
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
        /// <param name="stock"></param>
        /// <returns>Stock Index View</returns>
        [HttpPost]
        public async Task<IActionResult> Add(StockViewModel stock)
        {

            if (ModelState.IsValid)
            { 
                var list = await _stockServices.AddAsync(stock);
                if (list)
                {
                    TempData["Success"] = "Add Stock Success";
                    return RedirectToAction("Index");
                }
                ViewBag.ProductId = new SelectList(_productServices.GetProducts(), "ProductId", "ProductName",stock.ProductId);
                ViewBag.StoreId = new SelectList(_storeServices.GetStores(), "StoreId", "StoreName",stock.StoreId);
                ViewBag.Err = "Add Stock Failure";
                return View(stock);
            }
            ViewBag.ProductId = new SelectList(_productServices.GetProducts(), "ProductId", "ProductName",stock.ProductId);
            ViewBag.StoreId = new SelectList(_storeServices.GetStores(), "StoreId", "StoreName",stock.StoreId);
            return View(stock);
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
            var list = await _stockServices.GetIdAsync(storeId.Value, productId.Value);
            if (list == null)
            {
                return BadRequest();
            }
            ViewBag.ProductId = new SelectList(_productServices.GetProducts(), "ProductId", "ProductName");
            ViewBag.StoreId = new SelectList(_storeServices.GetStores(), "StoreId", "StoreName");
            return View(list);
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
                  var stocks =   await _stockServices.EditAsync(stockViewModel);
                if (stocks)
                {
                    TempData["Success"] = "Edit Stock Success";
                    return RedirectToAction("Index"); 
                }
                ViewBag.ProductId = new SelectList(_productServices.GetProducts(), "ProductId", "ProductName",stockViewModel.ProductId);
                ViewBag.StoreId = new SelectList(_storeServices.GetStores(), "StoreId", "StoreName",stockViewModel.StoreId);
                ViewBag.Err = "Edit Stock Failure";
                return View(stockViewModel);
                    
            } 
            ViewBag.ProductId = new SelectList(_productServices.GetProducts(), "ProductId", "ProductName",stockViewModel.ProductId);
            ViewBag.StoreId = new SelectList(_storeServices.GetStores(), "StoreId", "StoreName",stockViewModel.StoreId);
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
            await _stockServices.DeleteAsync(storeId.Value,productId.Value);
            TempData["Success"] = "Delete Stock Success";

            TempData["Stock"] = "Delete Stock Success";
            return  RedirectToAction("Index");
        }
    }
}