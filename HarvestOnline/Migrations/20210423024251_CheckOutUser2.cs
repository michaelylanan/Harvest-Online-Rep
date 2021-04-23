using Microsoft.EntityFrameworkCore.Migrations;

namespace HarvestOnline.Migrations
{
    public partial class CheckOutUser2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "CheckOutUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "CheckOutUsers");
        }
    }
}
