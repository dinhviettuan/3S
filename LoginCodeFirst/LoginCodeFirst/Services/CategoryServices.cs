using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LoginCodeFirst.Models;
using LoginCodeFirst.ViewModels.Category;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace LoginCodeFirst.Services
{
    public interface ICategoryServices
    {
        /// <summary>
        /// GetCategorys
        /// </summary>
        /// <returns>Categorys</returns>
        IEnumerable<Category> GetCategorys();
        
        /// <summary>
        /// GetCategoryListAsync
        /// </summary>
        /// <returns>ListCategory</returns>
        Task<List<CategoryViewModel>> GetCategoryListAsync();
        
        /// <summary>
        /// AddAsync
        /// </summary>
        /// <param name="category">CategoryViewModel</param>
        /// <returns>Could Be Addted?</returns>
        Task<bool>AddAsync(CategoryViewModel category);
        
        /// <summary>
        /// GetIdAsync
        /// </summary>
        /// <param name="id">Category Id</param>
        /// <returns>CategoryViewModel</returns>
        Task<CategoryViewModel> GetIdAsync(int id);
        
        /// <summary>
        /// EditAsync
        /// </summary>
        /// <param name="categoryViewModel">CategoryViewModel</param>
        /// <returns>Could be Editted?</returns>
        Task<bool> EditAsync(CategoryViewModel categoryViewModel);
        
        /// <summary>
        /// DeleteAsync
        /// </summary>
        /// <param name="id"> Category Id</param>
        /// <returns>Could be Deleted</returns>
        Task<bool> DeleteAsync(int id);
        
        /// <summary>
        /// IsExistedName
        /// </summary>
        /// <param name="name">Category Name</param>
        /// <param name="id">Category Id</param>
        /// <returns>ExistedName</returns>
        bool IsExistedName(string name,int id);
    }

    public class CategoryServices : ICategoryServices
    {
        private readonly CodeDataContext _context;
        private readonly IMapper _mapper;
        public CategoryServices(CodeDataContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <inheritdoc />
        /// <summary>
        /// GetCategorys
        /// </summary>
        /// <returns>categorys</returns>
        public IEnumerable<Category> GetCategorys()
        {
            return _context.Category;
        }

        /// <inheritdoc />
        /// <summary>
        /// GetCategoryListAsync
        /// </summary>
        /// <returns>ListCategory</returns>
        public async Task<List<CategoryViewModel>> GetCategoryListAsync()
        {
            try
            {
                var category = await _context.Category.ToListAsync();
                var list = _mapper.Map<List<CategoryViewModel>>(category);
                return list;
            }
            catch (Exception e)
            {
                Log.Information("Get Category List Async: {0}",e.Message );
                throw;
            }           
        }


        /// <inheritdoc />
        /// <summary>
        /// AddAsync
        /// </summary>
        /// <param name="category">CategoryViewModel</param>
        /// <returns>Could Be Addted?</returns>
        public async Task<bool>AddAsync(CategoryViewModel category)
        {
            try
            {
                var categorys = new Category
                {
                    CategoryName = category.CategoryName
                };
                _context.Category.Add(categorys);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Log.Error("Add Categoy Async Error: {0}",e.Message);
                return false;
            }    
        }
        
        /// <inheritdoc />
        /// <summary>
        /// GetIdAsync
        /// </summary>
        /// <param name="id">Category Id</param>
        /// <returns>CategoryViewModel</returns>
        public async Task<CategoryViewModel> GetIdAsync(int id)
        {
            try
            {
                var category = await _context.Category.FindAsync(id);
                var categoryViewModel = _mapper.Map<CategoryViewModel>(category);
                return categoryViewModel;
            }
            catch (Exception e)
            {
                Log.Warning("Get Id Category Async Error: {0}",e.Message);
                throw;
            }         
        }

        /// <inheritdoc />
        /// <summary>
        /// EditAsync
        /// </summary>
        /// <param name="categoryViewModel">CategoryViewModel</param>
        /// <returns>Could Be Editted?</returns>
        public async Task<bool> EditAsync(CategoryViewModel categoryViewModel)
        {
            try
            {
                var categorys = await _context.Category.FindAsync(categoryViewModel.CategoryId);

                categorys.CategoryName = categoryViewModel.CategoryName;
            
                _context.Category.Update(categorys);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Log.Error("Edit Category Async Error: {0}",e.Message);
                return false;
            }
        }
        
        /// <inheritdoc />
        /// <summary>
        /// DeleteAsync
        /// </summary>
        /// <param name="id">Category Id</param>
        /// <returns>Could Be Deleted?</returns>
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var category = await _context.Category.FindAsync(id);
                if (category != null)
                {
                    _context.Category.Remove(category);
                    await _context.SaveChangesAsync();
                }
                return true;
            }
            catch (Exception e)
            {
               Log.Error("Delete Category Async Error:{0}",e.Message);
                return false;
            }        
        }

        /// <inheritdoc />
        /// <summary>
        /// IsExistedName
        /// </summary>
        /// <param name="name">Category Name</param>
        /// <param name="id">Category Id</param>
        /// <returns>ExistedName?</returns>
        public bool IsExistedName(string name,int id)
        {
            try
            {
                return  _context.Category.Any(x => x.CategoryName == name && x.CategoryId != id);
            }
            catch (Exception e)
            {
                Log.Warning("Is Category Existed Name Error :{0}",e.Message);
                throw;
            }
            
        }
    }
}