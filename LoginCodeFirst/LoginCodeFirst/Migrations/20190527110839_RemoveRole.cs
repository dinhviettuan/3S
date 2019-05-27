using Microsoft.EntityFrameworkCore.Migrations;

namespace LoginCodeFirst.Migrations
{
    public partial class RemoveRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "User",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Password",
                value: "10000:sK3XxXBZO4L2um4IL56snrr/kijdQ4YRqDMu8bwtDh5QvrOP");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Password",
                value: "10000:vkoj1s/Fe56e5nzqEx5tuWVC9xu9vogaQcxUXzD5B8yM6CTN");
        }
    }
}
