using Microsoft.EntityFrameworkCore.Migrations;

namespace HarvestOnline.Migrations
{
    public partial class CheckOutCartNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OverallTotal",
                table: "CheckOutUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OverallTotal",
                table: "CheckOutUsers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
