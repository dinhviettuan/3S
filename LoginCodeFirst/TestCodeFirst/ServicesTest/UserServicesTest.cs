using System.Threading.Tasks;
using LoginCodeFirst.Models;
using LoginCodeFirst.Services;
using LoginCodeFirst.ViewModels.User;
using TaskTranning.Infrastructure;
using Xunit;

namespace TestCodeFirst.ServicesTest
{
    public class UserServicesTest
    {
        private readonly CodeDataContext _codedataContext;
        private readonly UserServices _userServices;

        public UserServicesTest()
        {
            _codedataContext = TestHelpers.GetCodeDataContext();
            AutoMapperConfig.Initialize();
            var mapper = AutoMapperConfig.GetMapper();
            _userServices = new UserServices(_codedataContext, mapper);
        }


        private void DbSeed()
        {
            var user = new User
            {
                StoreId = 1,
                Email = "tuan1@gmail.com",
                Password = SecurePasswordHasher.Hash("Aa123456"),
                Fullname = "Dinh Viet Tuan",
                Phone = "0768407899",
                IsActive = true,
                Role = 1
            };
            _codedataContext.User.Add(user);

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

            _codedataContext.Store.Add(store);
            _codedataContext.SaveChanges();

        }

        [Fact]
        public async Task GetUser_ReturnListUser()
        {
            DbSeed();
            var users = await _userServices.GetUserListAsync();
            Assert.Equal(users.Count, 1);
        }

        [Fact]
        public async Task GetUser_ReturnNull()
        {
            var users = await _userServices.GetUserListAsync();
            Assert.Equal(users.Count, 0);
        }

        [Fact]
        public void Login_Return_True()
        {
            DbSeed();
            const string email = "tuan1@gmail.com";
            const string password = "Aa123456";
            var isLogin = _userServices.Login(email, password);
            Assert.True(isLogin);
        }

        [Fact]
        public void Login_Return_False()
        {
            DbSeed();
            const string email = "tuan21@gmail.com";
            const string password = "Aa1234566";
            var isLogin = _userServices.Login(email, password);
            Assert.False(isLogin);
        }

        [Fact]
        public async Task GetEmail_ReturnUser()
        {
            DbSeed();
            const string email = "tuan1@gmail.com";
            var user = await _userServices.GetEmail(email);
            Assert.NotNull(user);
        }

        [Fact]
        public async Task GetEmail_ReturnNull()
        {
            DbSeed();
            const string email = "tuan11@gmail.com";
            var user = await _userServices.GetEmail(email);
            Assert.Null(user);
        }

        [Fact]
        public async Task GetId_ReturnUser()
        {
            DbSeed();
            const int id = 1;
            var user = await _userServices.GetIdAsync(id);
            Assert.NotNull(user);
        }

        [Fact]
        public async Task GetId_ReturNull()
        {
            DbSeed();
            const int id = 0;
            var user = await _userServices.GetIdAsync(id);
            Assert.Null(user);
        }

        [Fact]
        public async Task GetEditPassword_ReturnUser()
        {
            DbSeed();
            const int id = 1;
            var user = await _userServices.GetEditPasswordAsync(id);
            Assert.NotNull(user);
        }

        [Fact]
        public async Task GetEditPassword_ReturnNull()
        {
            DbSeed();
            const int id = 0;
            var user = await _userServices.GetEditPasswordAsync(id);
            Assert.Null(user);
        }

        [Fact]
        public async Task Add_ReturnTrue()
        {
            DbSeed();
            var user = new UserViewModel()
            {
                StoreId = 1,
                Email = "tuan11@gmail.com",
                Password = "Aa123456",
                FullName = "Dinh Viet Tuan",
                Phone = "0768407899",
                IsActive = true,
                Role = 1
            };
            var result = await _userServices.AddAsync(user);
            Assert.True(result);
        }
    }
}