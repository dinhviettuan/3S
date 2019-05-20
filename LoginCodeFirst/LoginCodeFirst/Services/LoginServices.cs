using System;
using System.Threading.Tasks;
using LoginCodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using TaskTranning.Infrastructure;

namespace LoginCodeFirst.Services
{
    public interface ILoginServices
    {
        Task<User> GetEmailAsync(string email);
        Task<bool> LoginAsync(string email, string password);
    }
    public class LoginServices : ILoginServices
    {
        private readonly CodeDataContext _context;
        
        public LoginServices(CodeDataContext context)
        {
            _context = context;
        }
        
        /// <summary>
        /// GetEmailAsync
        /// </summary>
        /// <param name="email">UserViewModel</param>
        /// <returns>Email</returns>
        public async Task<User> GetEmailAsync(string email)
        {
            var user = await _context.User.FindAsync(email);
            return user;
        }
        
        /// <inheritdoc />
        /// <summary>
        /// LoginAsync
        /// </summary>
        /// <param name="email">User Email</param>
        /// <param name="password">User Password</param>
        /// <returns>LoginViewModel</returns>
        public async Task<bool> LoginAsync(string email, string password)
        {
                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                {
                    return false;
                }

                var user = await _context.User.FirstOrDefaultAsync(u =>
                    u.Email == email && SecurePasswordHasher.Verify(password, u.Password));
                return user != null;
        }
    }
}