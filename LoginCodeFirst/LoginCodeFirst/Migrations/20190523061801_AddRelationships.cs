using Microsoft.EntityFrameworkCore.Migrations;

namespace LoginCodeFirst.Migrations
{
    public partial class AddRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "Password", "StoreId" },
                values: new object[] { "10000:fqo2BEiALOFpGxRsTcag1ynJUmKNaTbkDhZg1atAOvpji2m7", 1 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "Password", "StoreId" },
                values: new object[] { "10000:lbKBDXoZxouYqOwYaXLXbBuDpr7mHgyBzaU7UxjwV+glEoZP", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_User_StoreId",
                table: "User",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Brand_BrandId",
                table: "Product",
                column: "BrandId",
                principalTable: "Brand",
                principalColumn: "BrandId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_CategoryId",
                table: "Product",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_Product_ProductId",
                table: "Stock",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_Store_StoreId",
                table: "Stock",
                column: "StoreId",
                principalTable: "Store",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Store_StoreId",
                table: "User",
                column: "StoreId",
                principalTable: "Store",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Brand_BrandId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_CategoryId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Stock_Product_ProductId",
                table: "Stock");

            migrationBuilder.DropForeignKey(
                name: "FK_Stock_Store_StoreId",
                table: "Stock");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Store_StoreId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_StoreId",
                table: "User");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "Password", "StoreId" },
                values: new object[] { "10000:9gWPEEV0lmFrg1HlQ9vl0PCeFj40y/lKmQHzR8pTe9Co1Rkx", 3 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "Password", "StoreId" },
                values: new object[] { "10000:3vDvROw1WPP/r0UbROwA3/t1+i3/w2i3nv5mI8rlmO0Bb7yg", 2 });
        }
    }
}
