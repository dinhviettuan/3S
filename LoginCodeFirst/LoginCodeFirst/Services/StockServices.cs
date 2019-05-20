using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LoginCodeFirst.Models;
using LoginCodeFirst.ViewModels.Stock;
using Microsoft.EntityFrameworkCore;

namespace LoginCodeFirst.Services
{
    public interface IStockServices
    {
        /// <summary>
        /// GetStocks
        /// </summary>
        /// <returns>Stocks</returns>
        IEnumerable<Stock> GetStocks();
        /// <summary>
        /// GetStockListAsync
        /// </summary>
        /// <returns>ListStock</returns>
        Task<List<StockViewModel>> GetStockListAsync();
        /// <summary>
        /// AddAsync
        /// </summary>
        /// <param name="stock">StockViewModel</param>
        /// <returns>Could Be Addted?</returns>
        Task<bool> AddAsync(StockViewModel stock);
        /// <summary>
        /// GetIdAsync
        /// </summary>
        /// <param name="storeId">Store Id</param>
        /// <param name="productId">Product Id</param>
        /// <returns>StockViewModel</returns>
        Task<StockViewModel> GetIdAsync(int storeId, int productId);
        /// <summary>
        /// EditAsync
        /// </summary>
        /// <param name="stockViewModel">StockViewModel</param>
        /// <returns>Could Be Editted?</returns>
        Task<bool> EditAsync(StockViewModel stockViewModel);
        /// <summary>
        /// DeleteAsync
        /// </summary>
        /// <param name="storeId">Store Id</param>
        /// <param name="productId">Product Id</param>
        /// <returns>Could Be Deleted?</returns>
        Task<bool> DeleteAsync(int storeId, int productId);
    }

    public class StockServices : IStockServices
    {
        private readonly CodeDataContext _context;
        private readonly IMapper _mapper;


        public StockServices(CodeDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// GetStocks
        /// </summary>
        /// <returns>Stocks</returns>
        public IEnumerable<Stock> GetStocks()
        {
            return _context.Stock;
        }
        /// <summary>
        /// GetStockListAsync
        /// </summary>
        /// <returns>ListStock</returns>
        public async Task<List<StockViewModel>> GetStockListAsync()
        {
            var stocks = await _context.Stock
                .Include(stock => stock.Product)
                .Include(stock => stock.Store)
                .ToListAsync();
            var list = _mapper.Map<List<StockViewModel>>(stocks);
            return list;
        }
        /// <summary>
        /// AddAsync
        /// </summary>
        /// <param name="stockViewModel">StockViewModel</param>
        /// <returns>Could Be Addted?</returns>
        public async Task<bool> AddAsync(StockViewModel stockViewModel)
        {
            try
            {
                var st = await _context.Stock.FindAsync(stockViewModel.ProductId, stockViewModel.StoreId);
                if (st != null)
                {
                    st.Quantity += stockViewModel.Quantity;
                    _context.Stock.Update(st);
                    await _context.SaveChangesAsync();
                    return true;
                }                
                var stocks = new Stock
                {
                    StoreId = stockViewModel.StoreId,
                    ProductId = stockViewModel.ProductId,
                    Quantity = stockViewModel.Quantity
                };
                _context.Stock.Add(stocks);
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
        /// GetIdAsync
        /// </summary>
        /// <param name="storeId">Store Id</param>
        /// <param name="productId">Product Id</param>
        /// <returns>StockViewModel</returns>
        public async Task<StockViewModel> GetIdAsync(int storeId, int productId)
        {
            var stock = await _context.Stock.FindAsync(storeId, productId);
            var getViewModel = _mapper.Map<StockViewModel>(stock);
            return getViewModel;
        }
        /// <summary>
        /// EditAsync
        /// </summary>
        /// <param name="stockViewModel">StockViewModel</param>
        /// <returns>Could Be Editted?</returns>
        public async Task<bool> EditAsync(StockViewModel stockViewModel)
        {
            try
            {
                var stocks = await _context.Stock.FindAsync(stockViewModel.ProductId,stockViewModel.StoreId);

                stocks.Quantity = stockViewModel.Quantity;

                _context.Stock.Update(stocks);
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
        /// <param name="storeId">Store Id</param>
        /// <param name="productId">Product Id</param>
        /// <returns>Could Be Deleted?</returns>
        public async Task<bool> DeleteAsync(int storeId, int productId)
        {
            try
            {
                var stock = await _context.Stock.FindAsync(storeId,productId);
                _context.Stock.Remove(stock);
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