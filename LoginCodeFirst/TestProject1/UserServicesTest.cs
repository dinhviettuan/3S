//using System.Collections.Generic;
//using System.Threading.Tasks;
//using AutoMapper;
//using LoginCodeFirst.Models;
//using LoginCodeFirst.ViewModels.User;
//
//namespace TestProject1
//{
//    public interface IUserServicesTest
//    {
//        Task<List<UserViewModel>> GetUserListAsync();
//    }
//
//    public class UserServicesTest : IUserServicesTest
//    {
//        private readonly CodeDataContext _context;
//        private readonly IMapper _mapper;
//        
//        public UserServicesTest(CodeDataContext context,IMapper mapper)
//        {
//            _mapper = mapper;
//            _context = context;
//        }
//
//        public async Task<List<UserViewModel>> GetUserListAsync()
//        {
//                return _context ;                   
//        }
//           
//}
//}