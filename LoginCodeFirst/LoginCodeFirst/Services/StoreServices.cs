using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LoginCodeFirst.Models;
using LoginCodeFirst.ViewModels.Store;
using Microsoft.EntityFrameworkCore;


namespace LoginCodeFirst.Services
{
    public interface IStoreServices
    {
        IEnumerable<Store> GetStores();
        Task<List<IndexViewModel>> GetStoreListAsync();
        Task<bool> AddAsync(IndexViewModel store);
        Task<IndexViewModel> GetIdAsync(int? id);
        Task<bool> EditAsync(IndexViewModel store);
        Task<bool> DeleteAsync(int? id);


    }

    public class StoreServices : IStoreServices
    {
        private readonly CodeDataContext _context;
        private readonly IMapper _mapper;

        public StoreServices(CodeDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public IEnumerable<Store> GetStores()
        {
            return _context.Store;
        }

        public async Task<List<IndexViewModel>> GetStoreListAsync()
        {
            var stores = await _context.Store.ToListAsync();
            var storeViewModels = _mapper.Map<List<IndexViewModel>>(stores);
            return storeViewModels;
        }

        public async Task<bool> AddAsync(IndexViewModel store)
        {
            try
            {
                var stores = new Store
                {

                    StoreName = store.StoreName,
                    Phone = store.Phone,
                    Email = store.Email,
                    Street = store.Street,
                    City = store.City,
                    State = store.State,
                    ZipCode = store.ZipCode
                };
                  
                _context.Store.Add(stores);
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
            var store = await _context.Store.FindAsync(id);
            var storeEditViewModel = _mapper.Map<IndexViewModel>(store);
            return storeEditViewModel;
        }

        public async Task<bool> EditAsync(IndexViewModel store)
        {
            try
            {
                var stores = await _context.Store.FindAsync(store.StoreId);

                stores.StoreName = store.StoreName;
                stores.Phone = store.Phone;
                stores.Street = store.Street;
                stores.City = store.City;
                stores.State = store.State;
                stores.ZipCode = store.ZipCode;
                
                _context.Store.Update(stores);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
//
        public async Task<bool> DeleteAsync(int? id)
        {
            try
            {
                var store = await _context.Store.FindAsync(id);
                _context.Store.Remove(store);
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