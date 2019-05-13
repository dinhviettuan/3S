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
        IEnumerable<Store> Stores { get; }
        Task<IEnumerable<Store>> StoreAsync();
        Task<List<IndexViewModel>> GetStore();
        Task<bool> Add(IndexViewModel store);
        Task<IndexViewModel> GetId(int? id);
        Task<bool> Edit(IndexViewModel store);
        Task<bool> Delete(int? id);


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

        public IEnumerable<Store> Stores => _context.Store;

        public async Task<IEnumerable<Store>> StoreAsync()
        {
            return await _context.Store.ToListAsync();
        }

        public async Task<List<IndexViewModel>> GetStore()
        {
            var stores = await _context.Store.ToListAsync();
            var storeViewModels = _mapper.Map<List<IndexViewModel>>(stores);
            return storeViewModels;
        }

        public async Task<bool> Add(IndexViewModel store)
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

        public async Task<IndexViewModel> GetId(int? id)
        {
            var store = await _context.Store.FindAsync(id);
            var storeEditViewModel = _mapper.Map<IndexViewModel>(store);
            return storeEditViewModel;
        }

        public async Task<bool> Edit(IndexViewModel store)
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
        public async Task<bool> Delete(int? id)
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