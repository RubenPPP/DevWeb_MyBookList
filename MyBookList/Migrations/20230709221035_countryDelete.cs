using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBookList.Migrations
{
    public partial class countryDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "Members");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Members",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
