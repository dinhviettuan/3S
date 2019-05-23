using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LoginCodeFirst.Models;
using LoginCodeFirst.ViewModels.User;
using Microsoft.EntityFrameworkCore;
using TaskTranning.Infrastructure;


namespace LoginCodeFirst.Services
{
    public interface IUserServices
    {  
        /// <summary>
        /// GetUserListAsync
        /// </summary>
        /// <returns>ListUser</returns>
        Task<List<IndexViewModel>> GetUserListAsync();
        
        /// <summary>
        /// GetIdAsync
        /// </summary>
        /// <param name="id">User Id</param>
        /// <returns>EditViewModel</returns>
        Task<EditViewModel> GetIdAsync(int id);
        
        /// <summary>
        /// GetEditPasswordAsync
        /// </summary>
        /// <param name="id">User Id</param>
        /// <returns>PasswordViewModel</returns>
        Task<PasswordViewModel> GetEditPasswordAsync(int id);
        
        /// <summary>
        /// AddAsync
        /// </summary>
        /// <param name="user">IndexViewModel</param>
        /// <returns>Could Be Addted?</returns>
        Task<bool> AddAsync(IndexViewModel user);
        
        /// <summary>
        /// EditAsync
        /// </summary>
        /// <param name="user">EditViewModel</param>
        /// <returns>Could Be Editted?</returns>
        Task<bool>EditAsync(EditViewModel user);
        
        /// <summary>
        /// EditPasswordAsync
        /// </summary>
        /// <param name="editPasswordUser">PasswordViewModel</param>
        /// <returns>Could Be EditPassword?</returns>
        Task<bool> EditPasswordAsync(PasswordViewModel editPasswordUser);
        
        /// <summary>
        /// DeleteAsync
        /// </summary>
        /// <param name="id">User Id </param>
        /// <returns>Could Be Deleted?</returns>
        Task<bool> DeleteAsync(int id);

        /// <summary>
        /// IsExistedName
        /// </summary>
        /// <param name="email">User Email</param>
        /// <param name="id">User Id</param>
        /// <returns>ExistedName</returns>
        bool IsExistedName(string email, int id);
        
        /// <summary>
        /// Login
        /// </summary>
        /// <param name="email">Email</param>
        /// <param name="password">Password</param>
        /// <returns>Login?</returns>
        bool Login(string email, string password);
        
        /// <summary>
        /// GetEmail
        /// </summary>
        /// <param name="email">Email</param>
        /// <returns>IndexViewModel</returns>
        Task<IndexViewModel> GetEmail(string email);
    }

    public class UserServices : IUserServices
    {
        private readonly CodeDataContext _context;
        private readonly IMapper _mapper;
        public UserServices(CodeDataContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
 
        /// <inheritdoc />
        /// <summary>
        /// Login
        /// </summary>
        /// <param name="email">Email</param>
        /// <param name="password">Password</param>
        /// <returns>Login?</returns>
        public bool Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return false;
            }
            var user = _context.User.FirstOrDefault(x => x.Email == email && SecurePasswordHasher.Verify(password,x.Password));

            if (user == null)
            {
                return false;
            }
            return true;
        }
        
        /// <inheritdoc />
        /// <summary>
        /// GetEmail
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<IndexViewModel> GetEmail(string email)
        {
            var findEmail = await _context.User.FirstOrDefaultAsync(x => x.Email == email);
            var getEmail = _mapper.Map<IndexViewModel>(findEmail);
            return getEmail;
        }
       
        /// <inheritdoc />
        /// <summary>
        /// GetUserListAsync
        /// </summary>
        /// <returns>ListUser</returns>
        public async Task<List<IndexViewModel>> GetUserListAsync()
        {
            var users = await _context.User
                .Include(u => u.Store)
                .ToListAsync();
            var list = _mapper.Map<List<IndexViewModel>>(users);
            return list;         
        }
        
        /// <summary>
        /// GetIdAsync
        /// </summary>
        /// <param name="id">User Id</param>
        /// <returns>EditViewModel</returns>
        public async Task<EditViewModel> GetIdAsync(int id)
        {
            var user = await _context.User.FindAsync(id);
            var userViewModel = _mapper.Map<EditViewModel>(user);
            return userViewModel;
        }
        
        /// <inheritdoc />
        /// <summary>
        /// GetEditPasswordAsync
        /// </summary>
        /// <param name="id">User Id</param>
        /// <returns>PasswordViewModel</returns>
        public async Task<PasswordViewModel> GetEditPasswordAsync(int id)
        {
            var user = await _context.User.FindAsync(id);
            var passwordViewModel = _mapper.Map<PasswordViewModel>(user);
            return passwordViewModel;
        }
        
        /// <inheritdoc />
        /// <summary>
        /// AddAsync
        /// </summary>
        /// <param name="userViewModel">IndexViewModel</param>
        /// <returns>Could Be Addted?</returns>
        public async Task<bool> AddAsync(IndexViewModel userViewModel)
        {
            try
            {
                var users = new User
                {
                    Email = userViewModel.Email,
                    Fullname = userViewModel.FullName,
                    Password = SecurePasswordHasher.Hash(userViewModel.Password),
                    Phone = userViewModel.Phone,
                    IsActive = userViewModel.IsActive,
                    StoreId = userViewModel.StoreId
                };
                     _context.User.Add(users);
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
        /// EditAsync
        /// </summary>
        /// <param name="userViewModel">EditViewModel</param>
        /// <returns>Could Be Editted?</returns>
        public async Task<bool>EditAsync(EditViewModel userViewModel)
        {
            try
            {
                var users = await _context.User.FindAsync(userViewModel.UserId);
                users.Email = userViewModel.Email;
                users.Fullname = userViewModel.FullName;
                users.Phone = userViewModel.Phone;
                users.IsActive = userViewModel.IsActive;
                _context.User.Update(users);
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
        /// EditPasswordAsync
        /// </summary>
        /// <param name="passwordViewModel">PasswordViewModel</param>
        /// <returns>Could Be Edit?</returns>
        public async Task<bool> EditPasswordAsync(PasswordViewModel passwordViewModel)
        {
            try
            {
                var user = await _context.User.FindAsync(passwordViewModel.UserId);
                user.Password = SecurePasswordHasher.Hash(passwordViewModel.NewPassword);
                _context.User.Update(user);
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
        /// DeleteAsync
        /// </summary>
        /// <param name="id">User Id</param>
        /// <returns>Could Be Deleted?</returns>
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var user = await _context.User.FindAsync(id);
                _context.User.Remove(user);
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
        /// <param name="email">User email</param>
        /// <param name="id">User Id</param>
        /// <returns>ExistedName?</returns>
        public bool IsExistedName(string email,int id)
        {
            return  _context.User.Any(x => x.Email == email && x.UserId != id);
        }
    }
}