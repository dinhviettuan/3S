using Microsoft.EntityFrameworkCore.Migrations;

namespace LoginCodeFirst.Migrations
{
    public partial class AddPassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Password",
                value: "10000:FeE0tSfa0EYkMuYs+HZDpNbNj2FnVQaU9j/VPbQ4n7uT1i+Y");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Password",
                value: "10000:3cXPnf5tr5bkX6OZixIOrG3NXLRLMs0WsYXuEoQhKhHh+SjN");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Password",
                value: "10000:xqjOusyesNCymYsDRlATdoVvTaZMpCD2RheKLMEYBUYZhe3U");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Password",
                value: "10000:Fle5cEP4Rh3AC31BuSWbItUWl2EyWmzCImOVZhkXKCDb+nIX");
        }
    }
}
