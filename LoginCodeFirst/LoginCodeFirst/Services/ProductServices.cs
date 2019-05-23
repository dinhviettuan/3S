using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LoginCodeFirst.Models;
using LoginCodeFirst.ViewModels.Product;
using Microsoft.EntityFrameworkCore;

namespace LoginCodeFirst.Services
{
    public interface IProductServices
    {
        /// <summary>
        /// GetProducts
        /// </summary>
        /// <returns>Products</returns>
        IEnumerable<Product> GetProducts();
        /// <summary>
        /// GetProductListAsync
        /// </summary>
        /// <returns>ListProduct</returns>
        Task<List<ProductViewModel>> GetProductListAsync();
        /// <summary>
        /// AddAsync
        /// </summary>
        /// <param name="product">ProductViewModel</param>
        /// <returns>Could be Addted?</returns>
        Task<bool> AddAsync(ProductViewModel product);
        /// <summary>
        /// GetIdAsync
        /// </summary>
        /// <param name="id">Product Id</param>
        /// <returns>ProductViewModel</returns>
        Task<ProductViewModel> GetIdAsync(int id);
        /// <summary>
        /// EditAsync
        /// </summary>
        /// <param name="product">ProductViewModel</param>
        /// <returns>Could Be Editted</returns>
        Task<bool> EditAsync(ProductViewModel product);
        /// <summary>
        /// DeleteAsync
        /// </summary>
        /// <param name="id">Product Id</param>
        /// <returns>Could Be Deleted?</returns>
        Task<bool> DeleteAsync(int id);
        /// <summary>
        /// IsExistedName
        /// </summary>
        /// <param name="name">Product Name</param>
        /// <param name="id">Product Id</param>
        /// <returns>ExistedName</returns>
        bool IsExistedName(string name, int id);
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

        /// <inheritdoc />
        /// <summary>
        /// GetProducts
        /// </summary>
        /// <returns>Products</returns>
        public IEnumerable<Product> GetProducts()
        {
            return _context.Product;
        }

        /// <inheritdoc />
        /// <summary>
        /// GetProductListAsync
        /// </summary>
        /// <returns>ListProduct</returns>
        public async Task<List<ProductViewModel>> GetProductListAsync()
        {
           var product = await _context.Product
               .Include(p => p.Brand)
               .Include(p => p.Category)
               .ToListAsync();
           var list = _mapper.Map<List<ProductViewModel>>(product);
            return list;
        }


        /// <inheritdoc />
        /// <summary>
        /// AddAsync
        /// </summary>
        /// <param name="product">ProductViewModel</param>
        /// <returns>Could Be Addted?</returns>
        public async Task<bool> AddAsync(ProductViewModel product)
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
        /// <inheritdoc />
        /// <summary>
        /// GetIdAsync
        /// </summary>
        /// <param name="id">Product Id</param>
        /// <returns>ProductViewModel</returns>
        public async Task<ProductViewModel> GetIdAsync(int id)
        {
            var product = await _context.Product.FindAsync(id);
            var list = _mapper.Map<ProductViewModel>(product);
            return list;
        }
        /// <inheritdoc />
        /// <summary>
        /// EditAsync
        /// </summary>
        /// <param name="product">ProductViewModel</param>
        /// <returns>Could Be Editted?</returns>
        public async Task<bool> EditAsync(ProductViewModel product)
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
        /// <summary>
        /// DeleteAsync
        /// </summary>
        /// <param name="id">Product Id</param>
        /// <returns>Could Be Deleted?</returns>
        public async Task<bool> DeleteAsync(int id)
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
        /// <inheritdoc />
        /// <summary>
        /// IsExistedName
        /// </summary>
        /// <param name="name">Product Name</param>
        /// <param name="id">Product Id</param>
        /// <returns>ExistedName</returns>
        public bool IsExistedName(string name,int id)
        {
            return  _context.Product.Any(x => x.ProductName == name && x.ProductId != id);
        }
               
        }
    }