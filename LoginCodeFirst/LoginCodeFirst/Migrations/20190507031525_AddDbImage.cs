using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LoginCodeFirst.Migrations
{
    public partial class AddDbImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    BrandId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BrandName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.BrandId);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    StoreId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StoreName = table.Column<string>(maxLength: 255, nullable: false),
                    Phone = table.Column<string>(maxLength: 25, nullable: false),
                    Email = table.Column<string>(maxLength: 255, nullable: false),
                    Street = table.Column<string>(maxLength: 255, nullable: true),
                    City = table.Column<string>(maxLength: 255, nullable: true),
                    State = table.Column<string>(maxLength: 10, nullable: true),
                    ZipCode = table.Column<string>(maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.StoreId);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductName = table.Column<string>(nullable: true),
                    BrandId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    ModelYear = table.Column<int>(nullable: false),
                    ListPrice = table.Column<decimal>(nullable: false),
                    Image = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Product_Brand_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brand",
                        principalColumn: "BrandId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StoreId = table.Column<int>(nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(maxLength: 100, nullable: false),
                    Fullname = table.Column<string>(maxLength: 100, nullable: true),
                    Phone = table.Column<string>(maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_User_Store_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Store",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    StoreId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => new { x.ProductId, x.StoreId });
                    table.ForeignKey(
                        name: "FK_Stock_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stock_Store_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Store",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "BrandId", "BrandName" },
                values: new object[] { 1, "chanel" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 1, "tui sach" });

            migrationBuilder.InsertData(
                table: "Store",
                columns: new[] { "StoreId", "City", "Email", "Phone", "State", "StoreName", "Street", "ZipCode" },
                values: new object[] { 1, "Hue City", "Tuan1@gmail.com", "0768407899", "Hue", "TuanStore", "51 minh mang", "20000" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "BrandId", "CategoryId", "Image", "ListPrice", "ModelYear", "ProductName" },
                values: new object[] { 1, 1, 1, (byte)1, 123456m, 1, "giay" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Email", "Fullname", "IsActive", "Password", "Phone", "StoreId" },
                values: new object[] { 1, "tuan1@gmail.com", "Dinh Viet Tuan", true, "10000:ltHdEFS7PKMnLev8kQoiY1+sG99zNSrtnS+e/wqCI1DNM5MR", "123456789", 1 });

            migrationBuilder.InsertData(
                table: "Stock",
                columns: new[] { "ProductId", "StoreId", "Quantity" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Product_BrandId",
                table: "Product",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_StoreId",
                table: "Stock",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_User_StoreId",
                table: "User",
                column: "StoreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stock");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Store");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
