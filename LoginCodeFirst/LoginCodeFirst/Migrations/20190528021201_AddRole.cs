using Microsoft.EntityFrameworkCore.Migrations;

namespace LoginCodeFirst.Migrations
{
    public partial class AddRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "User",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "Password", "Role" },
                values: new object[] { "10000:5BVOvtPmK//FO/GDjOXUS7+HvfuVmIcHAO+lmDPV+Lf7DIhU", 1 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "Password", "Role" },
                values: new object[] { "10000:K4M4S4C5lT/AljnmgHmKffA3wDHLI2B2cbGKD5S+d8Oges9e", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "User");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Password",
                value: "10000:xS8nrtH0x5oWNkRrZYCeYZdLc5NU/JRGqW811FBvXExJTCht");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Password",
                value: "10000:gMBOFhHDH8RDq2UAG+H6Sxy7MbrgU+P6pYuJ0IrS4UbFB0hw");
        }
    }
}
