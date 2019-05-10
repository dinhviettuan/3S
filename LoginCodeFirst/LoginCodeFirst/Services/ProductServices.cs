using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LoginCodeFirst.Models;
using LoginCodeFirst.Models.Products;
using LoginCodeFirst.ViewModels.Brand;
using LoginCodeFirst.ViewModels.Product;
using Microsoft.EntityFrameworkCore;
using AddViewModel = LoginCodeFirst.ViewModels.Product.AddViewModel;
using EditViewModel = LoginCodeFirst.ViewModels.Product.EditViewModel;
using IndexViewModel = LoginCodeFirst.ViewModels.Product.IndexViewModel;

namespace LoginCodeFirst.Services
{
    public interface IProductServices
    {
        IEnumerable<Product> Products { get; }
        Task<List<IndexViewModel>> GetListAsync();
        Task<bool> Add(AddViewModel product);
        Task<EditViewModel> GetId(int? id);
        Task<bool> Edit(EditViewModel product);
        Task<bool> Delete(int? id);
//        Task<bool> UpLoadFile(IndexProductViewModel Image);
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

        public IEnumerable<Product> Products => _context.Product;
        
        
        public async Task<List<IndexViewModel>> GetListAsync()
        {
           var product = await _context.Product
               .Include(p => p.Brand)
               .Include(p => p.Category).ToListAsync();
           var list = _mapper.Map<List<IndexViewModel>>(product);
            return list;
        }

       
        
        public async Task<bool> Add(AddViewModel product)
        {
            try
            {
                var products = new Product
                {
                    ProductName = product.ProductName,
                    BrandId = product.BrandId,
                    CategoryId = product.CategoryId,
                    ModelYear = product.ModelYear,
                    ListPrice = product.ListPrice
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

        public async Task<EditViewModel> GetId(int? id)
        {
            var product = await _context.Product.FindAsync(id);
            var list = _mapper.Map<EditViewModel>(product);
            return list;
        }

        public async Task<bool> Edit(EditViewModel product)
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
        
        public async Task<bool> Delete(int? id)
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

//        public async Task<bool> UpLoadFile(IndexProductViewModel Image)
//        {
//            var images = _context.Product.Find(Image);
//            _context.Product.Update(images);
//            _context.SaveChanges();
//            return true;
        }
    }