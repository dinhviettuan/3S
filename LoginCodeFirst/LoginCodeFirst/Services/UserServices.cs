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
        Task<IEnumerable<User>> Users();
        Task<bool> Login(string email, string password);
        Task<List<IndexViewModel>> GetUserList();
        Task<EditViewModel> GetId(int? id);
        Task<PasswordViewModel> GetEditPassword(int? Id);
        Task<bool> Add(IndexViewModel user);
        Task<bool>Edit(EditViewModel user);
        Task<bool> EditPassword(PasswordViewModel editPasswordUser);
        Task<bool> Delete(int? id);
        Task<User> GetEmail(string email);

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

        public async Task<IEnumerable<User>> Users()
        {
            return await _context.User.ToListAsync();
        }

        public async Task<bool> Login(string email, string password)
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

        public async Task<List<IndexViewModel>> GetUserList()
        {
            var users = await _context.User
                .Include(u => u.Store)
                .ToListAsync();
            var list = _mapper.Map<List<IndexViewModel>>(users);
            return list;
         
        }
        
        public async Task<EditViewModel> GetId(int? id)
        {
            var user = await _context.User.FindAsync(id);
            var userViewModel = _mapper.Map<EditViewModel>(user);
            return userViewModel;
        }

        public async Task<PasswordViewModel> GetEditPassword(int? Id)
        {
            var user = await _context.User.FindAsync(Id);
            var passwordViewModel = _mapper.Map<PasswordViewModel>(user);
            return passwordViewModel;
        }


        public async Task<bool> Add(IndexViewModel user)
        {
            try
            {
                var users = new User
                {
                    Email = user.Email,
                    Fullname = user.FullName,
                    Password = SecurePasswordHasher.Hash(user.Password),
                    Phone = user.Phone,
                    IsActive = user.IsActive,
                    StoreId = user.StoreId
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
        
        public async Task<bool>Edit(EditViewModel user)
        {
            try
            {
                var users = await _context.User.FindAsync(user.UserId);
                users.Email = user.Email;
                users.Fullname = user.FullName;
                users.Phone = user.Phone;
                users.IsActive = user.IsActive;
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
        
       
        public async Task<bool> EditPassword(PasswordViewModel editPassword)
        {
            try
            {
                var user = await _context.User.FindAsync(editPassword.UserId);
                user.Password = SecurePasswordHasher.Hash(editPassword.Password);
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

        public async Task<bool> Delete(int? id)
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

        public async Task<User> GetEmail(string email)
        {
            var user = await _context.User.FindAsync(email);
            return user;
        }
        
    }
}