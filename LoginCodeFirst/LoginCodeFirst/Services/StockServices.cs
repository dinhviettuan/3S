using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LoginCodeFirst.Models;
using LoginCodeFirst.Models.Products;
using LoginCodeFirst.ViewModels.Stock;
using Microsoft.EntityFrameworkCore;

namespace LoginCodeFirst.Services
{
    public interface IStockServices
    {
        Task<List<IndexViewModel>> GetListAsync();
        Task<bool> Add(IndexViewModel stock);
        Task<IndexViewModel> GetId(int? storeId, int? productId);
        Task<bool> Edit(IndexViewModel stockViewModel);
        Task<bool> Delete(int? storeId, int? productId);
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

        public async Task<List<IndexViewModel>> GetListAsync()
        {
            var stocks = await _context.Stock
                .Include(stock => stock.Product)
                .Include(stock => stock.Store)
                .ToListAsync();
            var list = _mapper.Map<List<IndexViewModel>>(stocks);
            return list;
        }

        public async Task<bool> Add(IndexViewModel stock)
        {
            try
            {
                var stocks = new Stock
                {
                    StoreId = stock.StoreId,
                    ProductId = stock.ProductId,
                    Quantity = stock.Quantity
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

        public async Task<IndexViewModel> GetId(int? storeId, int? productId)
        {
            var stock = await _context.Stock.FindAsync(storeId, productId);
            var getViewModel = _mapper.Map<IndexViewModel>(stock);
            return getViewModel;
        }

        public async Task<bool> Edit(IndexViewModel stockViewModel)
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

        public async Task<bool> Delete(int? storeId, int? productId)
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