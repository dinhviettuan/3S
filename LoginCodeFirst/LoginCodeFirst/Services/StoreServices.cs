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
        /// <summary>
        /// GetStores
        /// </summary>
        /// <returns>Stores</returns>
        IEnumerable<Store> GetStores();
        /// <summary>
        /// GetStoreListAsync
        /// </summary>
        /// <returns>ListStore</returns>
        Task<List<StoreViewModel>> GetStoreListAsync();
        /// <summary>
        /// AddAsync
        /// </summary>
        /// <param name="store">StoreViewModel</param>
        /// <returns>Could Be Addted?</returns>
        Task<bool> AddAsync(StoreViewModel store);
        /// <summary>
        /// GetIdAsync
        /// </summary>
        /// <param name="id">Store Id</param>
        /// <returns>StoreViewModel</returns>
        Task<StoreViewModel> GetIdAsync(int id);
        /// <summary>
        /// EditAsync
        /// </summary>
        /// <param name="store">StoreViewModel</param>
        /// <returns>Could Be Editted?</returns>
        Task<bool> EditAsync(StoreViewModel store);
        /// <summary>
        /// DeleteAsync
        /// </summary>
        /// <param name="id">Store Id</param>
        /// <returns>Could Be Deleted?</returns>
        Task<bool> DeleteAsync(int id);
        /// <summary>
        /// IsExistedName
        /// </summary>
        /// <param name="name">Store Name</param>
        /// <param name="id">Store Id</param>
        /// <returns>ExistedName</returns>
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

        /// <inheritdoc />
        /// <summary>
        /// GetStores
        /// </summary>
        /// <returns>Stores</returns>
        public IEnumerable<Store> GetStores()
        {
            return _context.Store;
        }
        /// <summary>
        /// GetStoreListAsync
        /// </summary>
        /// <returns>ListStore</returns>
        public async Task<List<StoreViewModel>> GetStoreListAsync()
        {
            var stores = await _context.Store.ToListAsync();
            var storeViewModels = _mapper.Map<List<StoreViewModel>>(stores);
            return storeViewModels;
        }
        /// <summary>
        /// AddAsync
        /// </summary>
        /// <param name="store">StoreViewModel</param>
        /// <returns>Could Be Addted?</returns>
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
        /// <summary>
        /// GetIdAsync
        /// </summary>
        /// <param name="id">Store Id</param>
        /// <returns>StoreViewModel</returns>
        public async Task<StoreViewModel> GetIdAsync(int id)
        {
            var store = await _context.Store.FindAsync(id);
            var storeEditViewModel = _mapper.Map<StoreViewModel>(store);
            return storeEditViewModel;
        }
        /// <summary>
        /// EditAsync
        /// </summary>
        /// <param name="store">StoreViewModel</param>
        /// <returns>Could Be Edited?</returns>
        public async Task<bool> EditAsync(StoreViewModel store)
        {
            try
            {
                var stores = await _context.Store.FindAsync(store.Id);

                stores.StoreName = store.StoreName;
                stores.Email = store.Email;
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
        /// <summary>
        /// DeleteAsync
        /// </summary>
        /// <param name="id">Store Id</param>
        /// <returns>Could Be Deleted?</returns>
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
        /// <summary>
        /// IsExistedName
        /// </summary>
        /// <param name="email">Store Name</param>
        /// <param name="id">Store Id</param>
        /// <returns>ExistedName</returns>
        public bool IsExistedName(string email,int id)
        {
            return  _context.Store.Any(x => x.Email == email && x.Id != id);
        }
    }
}