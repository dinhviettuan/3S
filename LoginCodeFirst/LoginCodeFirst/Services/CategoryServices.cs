using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LoginCodeFirst.Models;
using LoginCodeFirst.Models.Products;
using LoginCodeFirst.ViewModels.Category;
using Microsoft.EntityFrameworkCore;

namespace LoginCodeFirst.Services
{
    public interface ICategoryServices
    {
        IEnumerable<Category> GetCategory();
        Task<List<IndexViewModel>> GetCategoryListAsync();
        Task<bool>AddAsync(IndexViewModel category);
        Task<IndexViewModel> GetIdAsync(int? id);
        Task<bool> EditAsync(IndexViewModel categoryPro);
        Task<bool> DeleteAsync(int? id);
        
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

        public IEnumerable<Category> GetCategory()
        {
            return _context.Category;
        }

        public async Task<List<IndexViewModel>> GetCategoryListAsync()
        {
            var category = await _context.Category.ToListAsync();
            var list = _mapper.Map<List<IndexViewModel>>(category);
            return list;
        }
        
        
        //add
        public async Task<bool>AddAsync(IndexViewModel category)
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
                Console.WriteLine(e);
                return false;
            }
            
        }

        public async Task<IndexViewModel> GetIdAsync(int? id)
        {
            var category = await _context.Category.FindAsync(id);
            var categoryViewModel = _mapper.Map<IndexViewModel>(category);
            return categoryViewModel;
        }
    
        
        public async Task<bool> EditAsync(IndexViewModel categoryViewModel)
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
                Console.WriteLine(e);
                return false;
            }
            
        }
        
        public async Task<bool> DeleteAsync(int? id)
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
                Console.WriteLine(e);
                return false;
            }
           
        }
    }
}