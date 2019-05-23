using Microsoft.EntityFrameworkCore.Migrations;

namespace LoginCodeFirst.Migrations
{
    public partial class AddRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Role",
                table: "User",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "Password", "Role" },
                values: new object[] { "10000:4i+HfkR4PJZs4iWO7xqT22y2/p98NWNeh0qjRy3LUq7l6OTz", 1 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "Password", "Role" },
                values: new object[] { "10000:rMO0ZX7I7whcvRG64+E7qam7ECjKNsYzJjjtl1Jcfqkm9ViC", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "User",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "Password", "Role" },
                values: new object[] { "10000:FeE0tSfa0EYkMuYs+HZDpNbNj2FnVQaU9j/VPbQ4n7uT1i+Y", "Admin" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "Password", "Role" },
                values: new object[] { "10000:3cXPnf5tr5bkX6OZixIOrG3NXLRLMs0WsYXuEoQhKhHh+SjN", "User" });
        }
    }
}
