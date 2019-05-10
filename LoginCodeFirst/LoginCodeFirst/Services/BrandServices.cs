using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LoginCodeFirst.Models;
using LoginCodeFirst.Models.Products;
using LoginCodeFirst.ViewModels.Brand;
using Microsoft.EntityFrameworkCore;

namespace LoginCodeFirst.Services
{
    public interface IBrandServices
    {
        IEnumerable<Brand> Brands { get; }
        Task<List<IndexViewModel>> GetBrandList();
        Task<bool> Add(IndexViewModel brand);
        Task<IndexViewModel> GetId(int? id);
        Task<bool> Edit(IndexViewModel brand);
        Task<bool> Delete(int? id);
       
    }
        
    public class BrandServices : IBrandServices
    {
        private readonly CodeDataContext _context;
        private readonly IMapper _mapper;
        
        
        public BrandServices(CodeDataContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public IEnumerable<Brand> Brands => _context.Brand;
        
        
        public async Task<List<IndexViewModel>> GetBrandList()
        {
            var brand = await _context.Brand.ToListAsync();
            var brandViewModel = _mapper.Map<List<IndexViewModel>>(brand);
            return brandViewModel;
        }

        
        public async Task<bool> Add(IndexViewModel brand)
        { 
           try
            {
              var brands = new Brand
                {
                    BrandName = brand.BrandName
                };
                _context.Brand.Add(brands);
               await _context.SaveChangesAsync();
               return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
               return false;
            }
         }

        public async Task<IndexViewModel> GetId(int? id)
        {
            var brand = await _context.Brand.FindAsync(id);
            var brandViewModel = _mapper.Map<IndexViewModel>(brand);
            return brandViewModel;
        }

        
        
        public async Task<bool> Edit(IndexViewModel brand)
        {
            try
            {   
            var brands = await _context.Brand.FindAsync(brand.BrandId);
           
            brands.BrandName = brand.BrandName;
            
            _context.Brand.Update(brands);
            await _context.SaveChangesAsync();
            return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
         }
            
        

        public async Task<bool> Delete(int? id)
        {   
            try
            {
             var brand = await _context.Brand.FindAsync(id);
            
            _context.Brand.Remove(brand);
            await _context.SaveChangesAsync();
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