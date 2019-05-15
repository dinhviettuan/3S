using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LoginCodeFirst.Models;
using LoginCodeFirst.ViewModels.Category;
using Microsoft.EntityFrameworkCore;

namespace LoginCodeFirst.Services
{
    public interface ICategoryServices
    {
        IEnumerable<Category> GetCategorys();
        Task<List<CategoryViewModel>> GetCategoryListAsync();
        Task<bool>AddAsync(CategoryViewModel category);
        Task<CategoryViewModel> GetIdAsync(int id);
        Task<bool> EditAsync(CategoryViewModel categoryPro);
        Task<bool> DeleteAsync(int id);
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

        public IEnumerable<Category> GetCategorys()
        {
            return _context.Category;
        }

        public async Task<List<CategoryViewModel>> GetCategoryListAsync()
        {
            var category = await _context.Category.ToListAsync();
            var list = _mapper.Map<List<CategoryViewModel>>(category);
            return list;
        }
        
        
        //add
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
                Console.WriteLine(e);
                return false;
            }
            
        }

        public async Task<CategoryViewModel> GetIdAsync(int id)
        {
            var category = await _context.Category.FindAsync(id);
            var categoryViewModel = _mapper.Map<CategoryViewModel>(category);
            return categoryViewModel;
        }
    
        
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
                Console.WriteLine(e);
                return false;
            }
            
        }
        
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
                Console.WriteLine(e);
                return false;
            }
           
        }
        
        
        public bool IsExistedName(string name,int id)
        {
            return  _context.Category.Any(x => x.CategoryName == name && x.CategoryId != id);
        }
    }
}