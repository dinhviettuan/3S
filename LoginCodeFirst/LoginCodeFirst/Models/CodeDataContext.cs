using Microsoft.EntityFrameworkCore;
using TaskTranning.Infrastructure;

namespace LoginCodeFirst.Models
{
    public class CodeDataContext : DbContext
    {
       
        public CodeDataContext(DbContextOptions<CodeDataContext> options)
            : base(options)
        {
        }

        public DbSet<Store> Store { get; set;}
        public DbSet<User> User { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Stock> Stock { get; set; }
        
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(t => t.Email)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<User>()
                .Property(t => t.Password)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<User>()
                .Property(t => t.Fullname)
                .HasMaxLength(100);
            modelBuilder.Entity<User>()
                .Property(t => t.Phone)
                .HasMaxLength(100);
            modelBuilder.Entity<User>()
                .Property(t => t.IsActive);
            modelBuilder.Entity<User>()
                .Property(t => t.StoreId);
            modelBuilder.Entity<User>()
                .Property(t => t.Role);
            
            modelBuilder.Entity<Store>()
                .Property(t => t.StoreName)
                .IsRequired()
                .HasMaxLength(255);
            modelBuilder.Entity<Store>()
                .Property(t => t.Phone)
                .IsRequired()
                .HasMaxLength(25);
            modelBuilder.Entity<Store>()
                .Property(t => t.Email)
                .IsRequired()
                .HasMaxLength(255);
            modelBuilder.Entity<Store>()
                .Property(t => t.Street)
                .HasMaxLength(255);
            modelBuilder.Entity<Store>()
                .Property(t => t.City)
                .HasMaxLength(255);
            modelBuilder.Entity<Store>()
                .Property(t => t.State)
                .HasMaxLength(10);
            modelBuilder.Entity<Store>()
                .Property(t => t.ZipCode)
                .HasMaxLength(5);
            
            
            modelBuilder.Entity<Category>()
                .Property(t => t.CategoryName);
//            
//            
            modelBuilder.Entity<Brand>()
                .Property(t => t.BrandName);

//            
            modelBuilder.Entity<Product>()
                .Property(t => t.ProductName);
            modelBuilder.Entity<Product>()
                .Property(t => t.BrandId);
            modelBuilder.Entity<Product>()
                .Property(t => t.CategoryId);
            modelBuilder.Entity<Product>()
                .Property(t => t.ModelYear);
            modelBuilder.Entity<Product>()
                .Property(t => t.ListPrice);
            modelBuilder.Entity<Product>()
                .Property(t => t.Image);
//            
            modelBuilder.Entity<Stock>()
                .Property(t => t.StoreId);
            modelBuilder.Entity<Stock>()
                .Property(t => t.ProductId);
            modelBuilder.Entity<Stock>()
                .Property(t => t.Quantity);
            

            
//             Khoa ngoai tu bang Product sang category, brand 
            modelBuilder.Entity<Product>().HasOne(d => d.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId);
            modelBuilder.Entity<Product>().HasOne(d => d.Brand)
                .WithMany(p => p.Products)
                .HasForeignKey(d => d.BrandId);
            
//            Khoa ngoai tu bang Stock sang store, product 
            modelBuilder.Entity<Stock>().HasOne(d => d.Store)
                .WithMany(p => p.Stocks)
                .HasForeignKey(d => d.StoreId);
            modelBuilder.Entity<Stock>().HasOne(d => d.Product)
                .WithMany(p => p.Stocks)
                .HasForeignKey(d => d.ProductId);
            
            
//            khoa ngoai tu store qua user
            modelBuilder.Entity<User>().HasOne(d => d.Store)
                .WithMany(p => p.Users)
                .HasForeignKey(d => d.StoreId);
            
            modelBuilder.Entity<Store>().ToTable("Store");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Brand>().ToTable("Brand");
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Stock>().ToTable("Stock");
            modelBuilder.Entity<Stock>().HasKey(st => new {st.ProductId, st.StoreId});
            
           
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = 1,
                    Email = "tuan1@gmail.com",
                    Password = SecurePasswordHasher.Hash("12345"),
                    Fullname = "Dinh Viet Tuan",
                    Phone = "123456789",
                    StoreId = 3,
                    IsActive = true,
                    Role = "Admin"
                },
            new User
            {
                UserId = 2,
                Email = "tuan@gmail.com",
                Password = SecurePasswordHasher.Hash("12345"),
                Fullname = "Dinh Viet Tuan",
                Phone = "123456789",
                StoreId = 2,
                IsActive = true,
                Role = "User"
            });
            
            
            modelBuilder.Entity<Store>().HasData(
                new Store
                {
                    Id = 1,
                    StoreName = "TuanStore",
                    Phone = "0768407899",
                    Email = "Tuan1@gmail.com",
                    Street = "51 minh mang",
                    City = "Hue City",
                    State = "Hue",
                    ZipCode = "20000"
                });
            
            

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    CategoryId   = 1,
                    CategoryName = "tui sach"
                });
//
//           
            modelBuilder.Entity<Brand>().HasData(
                new Brand
                {
                    BrandId   = 1,
                    BrandName = "chanel"
                });
          
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId   = 1,
                    ProductName = "giay",
                    BrandId     = 1,
                    CategoryId = 1,
                    ModelYear = 1,
                    ListPrice = 123456,
                    Image = "wewqe"
                });
//
            modelBuilder.Entity<Stock>().HasData(
                new Stock
                {
                    StoreId = 1,
                    ProductId = 1,
                    Quantity = 1
                });
        }
    }
}