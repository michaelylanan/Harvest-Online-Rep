using Microsoft.EntityFrameworkCore.Migrations;

namespace HarvestOnline.Migrations
{
    public partial class LastCheckOut : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "CheckOutUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "CheckOutUsers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
