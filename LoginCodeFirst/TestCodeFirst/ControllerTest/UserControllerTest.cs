using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginCodeFirst.Controllers;
using LoginCodeFirst.Services;
using LoginCodeFirst.ViewModels.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace TestCodeFirst.ControllerTest
{
    public class UserControllerTest
    {
        private static List<UserViewModel> DbSeed()
        {
            var users = new List<UserViewModel>
            {
                new UserViewModel
                {                    
                    StoreId = 1,
                    Email = "tuan1@gmail.com",
                    Password = "Tuan123",
                    FullName = "Dinh Viet Tuan",
                    Phone = "0768407899",
                    IsActive = true,
                    Role = 1
                }
            };
            return users;
        }

        [Fact]
        public async Task IndexUser()
        {
            var userRepo = new Mock<IUserServices>();
            userRepo.Setup(repo => repo.GetUserListAsync()).ReturnsAsync(DbSeed);
            var storeRepo = new Mock<IStoreServices>();
            var userController = new UserController(userRepo.Object,storeRepo.Object,null,null); 
            var actionResult = await userController.Index();
            var viewResult = Assert.IsType<ViewResult>(actionResult);
            var model = Assert.IsAssignableFrom<IEnumerable<UserViewModel>>(viewResult.ViewData.Model);
            Assert.Equal(1,model.Count());
            Assert.NotNull(model);
        }
    }
}