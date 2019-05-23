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
        /// <summary>
        /// Get Brands
        /// </summary>
        /// <returns>Brands</returns>
        IEnumerable<Brand> GetBrands();
        
        /// <summary>
        /// GetListBrandAsync
        /// </summary>
        /// <returns>ListBrand</returns>
        Task<List<BrandViewModel>> GetBrandListAsync();
        
        /// <summary>
        /// AddBrand
        /// </summary>
        /// <param name="brand">BrandViewModel</param>
        /// <returns>Could be Addted?</returns>
        Task<bool> AddAsync(BrandViewModel brand);
        
        /// <summary>
        /// GetIdAsync
        /// </summary>
        /// <param name="id">Brand Id</param>
        /// <returns>Brand</returns>
        Task<BrandViewModel> GetIdAsync(int id);
        
        /// <summary>
        /// EditBrand
        /// </summary>
        /// <param name="brand">BrandViewModel</param>
        /// <returns>Could be Edited?</returns>
        Task<bool> EditAsync(BrandViewModel brand);
        
        /// <summary>
        /// DeleteBrand
        /// </summary>
        /// <param name="id">Brand Id</param>
        /// <returns>Could be Deleted?</returns>
        Task<bool> DeleteAsync(int id);
        
        /// <summary>
        /// IsExistedName
        /// </summary>
        /// <param name="name">Brand Name</param>
        /// <param name="id">Brand Id</param>
        /// <returns>ExistedName</returns>
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

        /// <inheritdoc />
        /// <summary>
        /// GetBrands
        /// </summary>
        /// <returns>Brands</returns>
        public IEnumerable<Brand> GetBrands()
        {
            return _context.Brand;
        }

        /// <inheritdoc />
        /// <summary>
        /// GetBrandListAsync
        /// </summary>
        /// <returns>ListBrand</returns>
        public async Task<List<BrandViewModel>> GetBrandListAsync()
        {
            var brand = await _context.Brand.ToListAsync();
            var brandViewModel = _mapper.Map<List<BrandViewModel>>(brand);
            return brandViewModel;
        }

        /// <inheritdoc />
        /// <summary>
        /// AddAsync
        /// </summary>
        /// <param name="brand">BrandViewModel</param>
        /// <returns>Could be Addted?</returns>
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

        /// <inheritdoc />
        /// <summary>
        /// GetIdAsync
        /// </summary>
        /// <param name="id">Brand Id</param>
        /// <returns>Brand</returns>
        public async Task<BrandViewModel> GetIdAsync(int id)
        {
            var brand = await _context.Brand.FindAsync(id);
            var brandViewModel = _mapper.Map<BrandViewModel>(brand);
            return brandViewModel;
        }

        /// <inheritdoc />
        /// <summary>
        /// EditAsync
        /// </summary>
        /// <param name="brand">BrandViewModel</param>
        /// <returns>Could be Editted?</returns>
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

        /// <inheritdoc />
        /// <summary>
        /// DeleteAsync
        /// </summary>
        /// <param name="id">Brand Id</param>
        /// <returns>Could Be Deleted?</returns>
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

        /// <inheritdoc />
        /// <summary>
        /// IsExistedName
        /// </summary>
        /// <param name="name">Brand Name</param>
        /// <param name="id">Brand Id</param>
        /// <returns>ExistedName?</returns>
        public bool IsExistedName(string name,int id)
        {
            return  _context.Brand.Any(x => x.BrandName == name && x.BrandId != id);
        }
    }
}