using Microsoft.EntityFrameworkCore.Migrations;

namespace LoginCodeFirst.Migrations
{
    public partial class RemoveRole : Migration
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
                values: new object[] { "10000:sK3XxXBZO4L2um4IL56snrr/kijdQ4YRqDMu8bwtDh5QvrOP", 1 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "Password", "Role" },
                values: new object[] { "10000:vkoj1s/Fe56e5nzqEx5tuWVC9xu9vogaQcxUXzD5B8yM6CTN", 2 });
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
                values: new object[] { "10000:B1En2ET+8j3OTdhCUMbkDWDoMhM0CMl4S18d5sDh8jjdGa4H", "1" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "Password", "Role" },
                values: new object[] { "10000:SLffoH9fszsxc8GOH7gGwbvjdPp2L47zoAcfq5al5WwRKexC", "1" });
        }
    }
}
