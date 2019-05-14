using System;
using System.Collections.Generic;
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
        IEnumerable<User> GetUsers();
        Task<bool> LoginAsync(string email, string password);
        Task<List<IndexViewModel>> GetUserListAsync();
        Task<EditViewModel> GetIdAsync(int? id);
        Task<PasswordViewModel> GetEditPasswordAsync(int? Id);
        Task<bool> AddAsync(IndexViewModel user);
        Task<bool>EditAsync(EditViewModel user);
        Task<bool> EditPasswordAsync(PasswordViewModel editPasswordUser);
        Task<bool> DeleteAsync(int? id);
        Task<User> GetEmailAsync(string email);

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


        

        public IEnumerable<User> GetUsers()
        {
            return _context.User;
        }

        public async Task<bool> LoginAsync(string email, string password)
        {
            try
            {
                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                {
                    return false;
                }

                var user = await _context.User.FirstOrDefaultAsync(u =>
                    u.Email == email && SecurePasswordHasher.Verify(password, u.Password));
                if (user != null)
                {
                    return true;
                }
                    return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public async Task<List<IndexViewModel>> GetUserListAsync()
        {
            var users = await _context.User
                .Include(u => u.Store)
                .ToListAsync();
            var list = _mapper.Map<List<IndexViewModel>>(users);
            return list;
         
        }
        
        public async Task<EditViewModel> GetIdAsync(int? id)
        {
            var user = await _context.User.FindAsync(id);
            var userViewModel = _mapper.Map<EditViewModel>(user);
            return userViewModel;
        }

        public async Task<PasswordViewModel> GetEditPasswordAsync(int? Id)
        {
            var user = await _context.User.FindAsync(Id);
            var passwordViewModel = _mapper.Map<PasswordViewModel>(user);
            return passwordViewModel;
        }


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

        public async Task<bool> DeleteAsync(int? id)
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

        public async Task<User> GetEmailAsync(string email)
        {
            var user = await _context.User.FindAsync(email);
            return user;
        }

        
    }
}