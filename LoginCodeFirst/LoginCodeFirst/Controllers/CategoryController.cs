﻿using System.Threading.Tasks;
using LoginCodeFirst.Services;
using LoginCodeFirst.ViewModels.Category;
using Microsoft.AspNetCore.Mvc;

namespace LoginCodeFirst.Controllers
{
        public class CategoryController : Controller
        {
            private readonly ICategoryServices _categoryServices;

            public CategoryController(ICategoryServices categoryServices)
            {
                _categoryServices  = categoryServices;
            }
            
     
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var liststore = await _categoryServices.GetListAsync();
            return View(liststore);
        } 
            
   
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
       
        
        [HttpPost]
        public async Task<IActionResult> Add(IndexViewModel category)
        {

            if (ModelState.IsValid)
            { 
                var list = await _categoryServices.Add(category);
                if (list != null)
                {
                    TempData["Category"] = "Add Category Success";
                    return RedirectToAction("Index");
                }
            }
            ViewBag.ErrorMessage = "Add Category Failure";
            return View(category);
        }   
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var list = await _categoryServices.GetId(id);
            if (list == null)
            {
                return NotFound();
            }

            return View(list);
        }
        
        [HttpPost]
        public async Task<IActionResult> Edit(int? id,IndexViewModel category)
        {

            if (ModelState.IsValid)
            {
                  await _categoryServices.Edit(category);
                    TempData["Category"] = "Edit Category Success";
                  return RedirectToAction("Index");
               
            }

            ViewBag.Err = "Edit Category Failure";
            return View(category);
        }
        
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            await _categoryServices.Delete(id);
            TempData["Category"] = "Delete Category Success";
            return  RedirectToAction("Index");
        }
    } 
}
