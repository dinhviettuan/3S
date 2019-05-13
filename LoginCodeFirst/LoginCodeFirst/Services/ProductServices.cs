using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using LoginCodeFirst.Models;
using LoginCodeFirst.Models.Products;
using LoginCodeFirst.ViewModels.Brand;
using LoginCodeFirst.ViewModels.Product;
using Microsoft.EntityFrameworkCore;
using IndexViewModel = LoginCodeFirst.ViewModels.Product.IndexViewModel;

namespace LoginCodeFirst.Services
{
    public interface IProductServices
    {
        IEnumerable<Product> GetProducts();
        Task<List<IndexViewModel>> GetProductListAsync();
        Task<bool> AddAsync(IndexViewModel product);
        Task<IndexViewModel> GetIdAsync(int? id);
        Task<bool> EditAsync(IndexViewModel product);
        Task<bool> DeleteAsync(int? id);
    }

    public class ProductServices : IProductServices
    {
        private readonly CodeDataContext _context;
        private readonly IMapper _mapper;


        public ProductServices(CodeDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.Product;
        }
        
        
        public async Task<List<IndexViewModel>> GetProductListAsync()
        {
           var product = await _context.Product
               .Include(p => p.Brand)
               .Include(p => p.Category).ToListAsync();
           var list = _mapper.Map<List<IndexViewModel>>(product);
            return list;
        }

       
        
        public async Task<bool> AddAsync(IndexViewModel product)
        {
            try
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", product.ImageFile.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await product.ImageFile.CopyToAsync(stream);
                }
                var products = new Product
                {
                    ProductName = product.ProductName,
                    BrandId = product.BrandId,
                    CategoryId = product.CategoryId,
                    ModelYear = product.ModelYear,
                    ListPrice = product.ListPrice,
                    Image = product.ImageFile.FileName
                };
            
                _context.Product.Add(products);
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
            var product = await _context.Product.FindAsync(id);
            var list = _mapper.Map<IndexViewModel>(product);
            return list;
        }

        public async Task<bool> EditAsync(IndexViewModel product)
        {
            try
            {
                var listProduct = await _context.Product.FindAsync(product.ProductId);

                listProduct.ProductName = product.ProductName;
                listProduct.BrandId = product.BrandId;
                listProduct.CategoryId = product.CategoryId;
                listProduct.ModelYear = product.ModelYear;
                listProduct.ListPrice = product.ListPrice;

                _context.Product.Update(listProduct);
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
                var product = await _context.Product.FindAsync(id);
                _context.Product.Remove(product);
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