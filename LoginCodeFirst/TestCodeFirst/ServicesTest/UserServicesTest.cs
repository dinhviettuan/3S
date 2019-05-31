using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AutoMapper;
using LoginCodeFirst.Models;
using LoginCodeFirst.Services;
using TaskTranning.Infrastructure;
using Xunit;

namespace TestCodeFirst.ServicesTest
{
    public class UserServicesTest
    {
        private readonly CodeDataContext _codedataContext;
        private readonly UserServices _userServices;
        private readonly IMapper _mapper;

        public UserServicesTest()
        {
            _codedataContext = TestHelpers.GetCodeDataContext();
            AutoMapperConfig.Initialize();
            _mapper = AutoMapperConfig.GetMapper();
            _userServices = new UserServices(_codedataContext, _mapper);
        }
       

        public void DbSeed()
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
        public async Task GetUser_ReturnListUser_Test()
        {
            DbSeed();
            var users = await _userServices.GetUserListAsync();            
            Assert.Equal(users.Count,1);
        }
        
        [Fact]
        public async Task GetUser_ReturnNull_Test()
        {
            var users = await _userServices.GetUserListAsync();            
            Assert.Equal(users.Count,0);
        }
        
        public bool Login(string email, string password)
        {   
            var user = _context.User.FirstOrDefault(x => x.Email == email && SecurePasswordHasher.Verify(password,x.Password));
        }
    }
}