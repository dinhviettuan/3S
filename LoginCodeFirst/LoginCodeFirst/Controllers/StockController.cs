﻿using System.Threading.Tasks;
using LoginCodeFirst.Services;
using LoginCodeFirst.ViewModels.Stock;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LoginCodeFirst.Controllers
{
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
        
        
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var listStock = await _stockServices.GetStockListAsync();
            return View(listStock);
        }
        
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.ProductId = new SelectList(_productServices.GetProducts(), "ProductId", "ProductName");
            ViewBag.StoreId = new SelectList(_storeServices.GetStores(), "StoreId", "StoreName");
            return View();
        }
        
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