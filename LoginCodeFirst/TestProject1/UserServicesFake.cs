//using System.Collections.Generic;
//using System.Threading.Tasks;
//using LoginCodeFirst.ViewModels.User;
//using Microsoft.EntityFrameworkCore;
//using TestProject1.Models;
//using Xunit;
//
//namespace TestProject1
//{
//    public interface IUserServicesFake
//    {
//    }
//
//     public class UserServicesFake
//     {
//        [Fact]
//        public void AddEmail()
//        {
//            IUserServicesFake = GetUserServicesFake;
//        }
//        private readonly DataContextFake _context;
//
//        public UserServicesFake(DataContextFake context)
//        {
//            _context = context;
//        }
//
//
//        [Fact]
//        public async Task<List<UserViewModel>> GetUserListAsync()
//        {
//            var users = await _context.UserFakes.ToListAsync();
//            return UserViewModel;
//        }
//}
//}