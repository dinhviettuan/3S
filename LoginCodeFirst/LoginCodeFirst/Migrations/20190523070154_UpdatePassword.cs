using Microsoft.EntityFrameworkCore.Migrations;

namespace LoginCodeFirst.Migrations
{
    public partial class UpdatePassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Password",
                value: "10000:fqo2BEiALOFpGxRsTcag1ynJUmKNaTbkDhZg1atAOvpji2m7");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Password",
                value: "10000:lbKBDXoZxouYqOwYaXLXbBuDpr7mHgyBzaU7UxjwV+glEoZP");
        }
    }
}
