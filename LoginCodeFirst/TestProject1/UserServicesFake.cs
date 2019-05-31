using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LoginCodeFirst.Models;
using LoginCodeFirst.Services;
using LoginCodeFirst.ViewModels.User;
using Microsoft.EntityFrameworkCore;
using TestProject1.Models;
using Xunit;

namespace TestProject1
{
    public class UserServicesFake
    {
        public readonly UserServices _userServices;
        
        
        private UserServicesFake GetInMemoryPersonRepository()
        {
            DbContextOptions<CodeDataContext> options;
            var builder = new DbContextOptionsBuilder<CodeDataContext>();
            builder.UserServicesFake();
            options = builder.Options;
            var personDataContext = new CodeDataContext(options);
            personDataContext.Database.EnsureDeleted();
            personDataContext.Database.EnsureCreated();
            return new UserServicesFake(CodeDataContext);

        }
        
        public void TestListBloggersAutoMapperMapperConfigDto()
        {
            //SETUP
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Mapper, Mapper>(); });

            var options = SqliteInMemory.CreateOptions<CodeDataContext>();
            using (var context = new CodeDataContext(options))
            {
                context.Database.EnsureCreated();
                context.AddRange(SetupPosts());
                context.SaveChanges();
                var logs = new List<string>();
                SqliteInMemory.SetupLogging(context, logs);

                //ATTEMPT
                var dtos = context.Bloggers
                    .ProjectTo<ListBloggersDto>(config)
                    .ToList();

                //VERIFY
                dtos.Count.ShouldEqual(2);
                dtos.Select(x => x.Name).ShouldEqual(new[] { AdaName, SherlockName });
                dtos.Select(x => x.PostsCount).ShouldEqual(new[] { 2, 1 });

                foreach (var log in logs)
                {
                    _output.WriteLine(log);
                }
            }
        }
    }
    
}