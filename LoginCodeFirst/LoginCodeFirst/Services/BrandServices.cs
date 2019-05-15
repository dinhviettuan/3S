using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LoginCodeFirst.Models;
using LoginCodeFirst.ViewModels.Brand;
using Microsoft.EntityFrameworkCore;

namespace LoginCodeFirst.Services
{
    public interface IBrandServices
    {
        IEnumerable<Brand> GetBrands();
        Task<List<BrandViewModel>> GetBrandListAsync();
        Task<bool> AddAsync(BrandViewModel brand);
        Task<BrandViewModel> GetIdAsync(int id);
        Task<bool> EditAsync(BrandViewModel brand);
        Task<bool> DeleteAsync(int id);
        bool IsExistedName(string name,int id);

        
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
        
        public IEnumerable<Brand> GetBrands()
        {
            return _context.Brand;
        }


        
        public async Task<List<BrandViewModel>> GetBrandListAsync()
        {
            var brand = await _context.Brand.ToListAsync();
            var brandViewModel = _mapper.Map<List<BrandViewModel>>(brand);
            return brandViewModel;
        }

        
        public async Task<bool> AddAsync(BrandViewModel brand)
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

        public async Task<BrandViewModel> GetIdAsync(int id)
        {
            var brand = await _context.Brand.FindAsync(id);
            var brandViewModel = _mapper.Map<BrandViewModel>(brand);
            return brandViewModel;
        }

        
        
        public async Task<bool> EditAsync(BrandViewModel brand)
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
            
        

        public async Task<bool> DeleteAsync(int id)
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

        public bool IsExistedName(string name,int id)
        {
            return  _context.Brand.Any(x => x.BrandName == name && x.BrandId != id);
        }
    }
}