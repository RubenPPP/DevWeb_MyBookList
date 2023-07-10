using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBookList.Migrations
{
    public partial class userStatusGone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Members");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Members",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
