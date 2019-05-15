using System;
using System.Collections.Generic;
using System.Linq;
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
        Task<List<StoreViewModel>> GetStoreListAsync();
        Task<bool> AddAsync(StoreViewModel store);
        Task<StoreViewModel> GetIdAsync(int id);
        Task<bool> EditAsync(StoreViewModel store);
        Task<bool> DeleteAsync(int id);
        bool IsExistedName(string name, int id);


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

        public async Task<List<StoreViewModel>> GetStoreListAsync()
        {
            var stores = await _context.Store.ToListAsync();
            var storeViewModels = _mapper.Map<List<StoreViewModel>>(stores);
            return storeViewModels;
        }

        public async Task<bool> AddAsync(StoreViewModel store)
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

        public async Task<StoreViewModel> GetIdAsync(int id)
        {
            var store = await _context.Store.FindAsync(id);
            var storeEditViewModel = _mapper.Map<StoreViewModel>(store);
            return storeEditViewModel;
        }

        public async Task<bool> EditAsync(StoreViewModel store)
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
        public async Task<bool> DeleteAsync(int id)
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
        
        public bool IsExistedName(string email,int id)
        {
            return  _context.Store.Any(x => x.Email == email && x.StoreId != id);
        }
    }
}