using System.Threading.Tasks;
using LoginCodeFirst.Controllers;
using LoginCodeFirst.Models;
using LoginCodeFirst.Resources;
using LoginCodeFirst.Services;
using LoginCodeFirst.ViewModels.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Moq;
using TaskTranning.Infrastructure;
using Xunit;

namespace TestCodeFirst.ControllerTest
{
    
    public class UserControllerTest
    {
        private readonly UserController _userController;
        private readonly CodeDataContext _codeDataContext;

        public UserControllerTest()
        {
            _codeDataContext = TestHelpers.GetCodeDataContext();
            AutoMapperConfig.Initialize();
            var mapper = AutoMapperConfig.GetMapper();
            var userServices = new UserServices(_codeDataContext, mapper); 
            var storeServices = new StoreServices(_codeDataContext,mapper);
            var options = Options.Create(new LocalizationOptions()); // you should not need any params here if using a StringLocalizer<T>
            var factory = new ResourceManagerStringLocalizerFactory(options, NullLoggerFactory.Instance); 
            
            var localizer = new ResourcesServices<CommonResources>(factory);           
            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>())
            {
                ["Success"] = localizer.GetLocalizedHtmlString("msg_AddSuccess")
            };

            _userController = new UserController(userServices,storeServices,localizer)
            {
                TempData = tempData
            }; 
        }

        private void DbSeed()
        {

            var store = new Store
            {
                StoreName = "Tuan Store",
                Phone = "01216935296",
                Email = "tuanadmin@gmail.com",
                Street = "51 minh mang",
                City = "hue",
                State = "hue",
                ZipCode = "2323"
            };
            _codeDataContext.Store.Add(store);
            
            var user = new User
            {
                StoreId = store.Id,
                Email = "tuan1@gmail.com",
                Password = SecurePasswordHasher.Hash("Aa123456"),
                Fullname = "Dinh Viet Tuan",
                Phone = "0768407899",
                IsActive = true,
                Role = 1
            };
            _codeDataContext.User.Add(user);
            _codeDataContext.SaveChanges();
        }

        [Fact]
        public async Task Index_ReturnListUser()
        {
            var listuser = await _userController.Index();
            Assert.IsType<ViewResult>(listuser);          
        }

        [Fact]
        public void Add_Return()
        {
            var users = _userController.Add();
            Assert.IsType<ViewResult>(users);      
        }

        [Fact]
        public async Task Add_ReturnUser()
        {     
            DbSeed();
            var userViewModel = new UserViewModel
            {
                StoreId = 1,
                Email = "tuan1@gmail.com",
                Password = SecurePasswordHasher.Hash("Aa123456"),
                FullName = "Dinh Viet Tuan",
                Phone = "0768407899",
                IsActive = true,
                Role = 1
            };
            var users = await _userController.Add(userViewModel);
            Assert.IsType<ViewResult>(users);
        }
        
        [Fact]
        public async Task Add_ReturnIndex()
        {     
            DbSeed();
            var userViewModel = new UserViewModel
            {
                StoreId = 1,
                Email = "tuan1@gmail.com",
                Password = SecurePasswordHasher.Hash("Aa123456"),
                FullName = "Dinh Viet Tuan",
                Phone = "0768407899",
                IsActive = true,
                Role = 1
            };
            var users = await _userController.Add(userViewModel);
            Assert.IsType<RedirectToActionResult>(users);
        }

        [Fact]
        public async Task Edit_ReturnBadRequest()
        {
            DbSeed();
            const int id = 0;
            var user = await _userController.Edit(id);
            Assert.IsType<BadRequestResult>(user);
        }

        [Fact]
        public async Task Edit_GetReturnUser()
        {
            DbSeed();
            const int id = 1;
            var user = await _userController.Edit(id);
            Assert.IsType<ViewResult>(user);
        }

        [Fact]
        public async Task Edit_PostReturnIndex()
        {           
            var userViewModel = new EditViewModel
            { 
                Id =  1,
                StoreId = 1,
                Email = "tuan1@gmail.com",
                FullName = "Dinh Viet Tuan",
                Phone = "0768407899",
                IsActive = true,
                Role = 1
            };            
            var user = await _userController.Edit(userViewModel);
            Assert.IsType<ViewResult>(user);
        }
        [Fact]
        public async Task Edit_PostReturnIsValidError()
        {           
            var userViewModel = new EditViewModel
            { 
                Id =  1,
                StoreId = 1,
                Email = "",
                FullName = "",
                Phone = "0768407899",
                IsActive = true,
                Role = 1
            };            
            var user = await _userController.Edit(userViewModel);
            _userController.ModelState.AddModelError("error","error");
            Assert.IsType<ViewResult>(user);
        }

        [Fact]
        public async Task EditPassword_GetReturnBadRequest()
        {
            DbSeed();
            const int id = 0;
            var user = await _userController.EditPassword(id);
            Assert.IsType<BadRequestResult>(user);
        }
        
        [Fact]
        public async Task EditPassword_GetReturnView()
        {
            DbSeed();
            const int id = 1;
            var user = await _userController.EditPassword(id);
            Assert.IsType<PartialViewResult>(user);
        }
        
        [Fact]
        public async Task EditPassword_PostReturnUser()
        {
            var userViewModel = new PasswordViewModel
            {
                Id = 1,
                NewPassword = "",
                ConfirmPassword = "Tuan123"
            };  
            var user = await _userController.EditPassword(userViewModel);
            _userController.ModelState.AddModelError("Error","Error");
            Assert.IsType<PartialViewResult>(user);
        }
        

        [Fact]
        public async Task Delete_ReturnBadRequest()
        {
            var user = await _userController.Delete(null);
            Assert.IsType<BadRequestResult>(user);
        }  
        
        [Fact]
        public async Task Delete_ReturnUser()
        {
            DbSeed();
            const int id = 1;
            var user = await _userController.Delete(id);
            Assert.IsType<RedirectToActionResult>(user);
        }   
    }  
}