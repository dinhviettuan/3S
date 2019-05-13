using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LoginCodeFirst.Models;
using LoginCodeFirst.Models.Products;
using LoginCodeFirst.ViewModels.Stock;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace LoginCodeFirst.Services
{
    public interface IStockServices
    {
        IEnumerable<Stock> GetStocks();
        Task<List<IndexViewModel>> GetStockListAsync();
        Task<bool> AddAsync(IndexViewModel stock);
        Task<IndexViewModel> GetIdAsync(int? storeId, int? productId);
        Task<bool> EditAsync(IndexViewModel stockViewModel);
        Task<bool> DeleteAsync(int? storeId, int? productId);
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
        
        public IEnumerable<Stock> GetStocks()
        {
            return _context.Stock;
        }

        public async Task<List<IndexViewModel>> GetStockListAsync()
        {
            var stocks = await _context.Stock
                .Include(stock => stock.Product)
                .Include(stock => stock.Store)
                .ToListAsync();
            var list = _mapper.Map<List<IndexViewModel>>(stocks);
            return list;
        }

        public async Task<bool> AddAsync(IndexViewModel stockViewModel)
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

        public async Task<IndexViewModel> GetIdAsync(int? storeId, int? productId)
        {
            var stock = await _context.Stock.FindAsync(storeId, productId);
            var getViewModel = _mapper.Map<IndexViewModel>(stock);
            return getViewModel;
        }

        public async Task<bool> EditAsync(IndexViewModel stockViewModel)
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

        public async Task<bool> DeleteAsync(int? storeId, int? productId)
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