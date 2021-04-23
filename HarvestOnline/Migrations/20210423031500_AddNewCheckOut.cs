using Microsoft.EntityFrameworkCore.Migrations;

namespace HarvestOnline.Migrations
{
    public partial class AddNewCheckOut : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddToCartCartId",
                table: "CheckOutUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CheckOutUsers_AddToCartCartId",
                table: "CheckOutUsers",
                column: "AddToCartCartId");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckOutUsers_AddToCarts_AddToCartCartId",
                table: "CheckOutUsers",
                column: "AddToCartCartId",
                principalTable: "AddToCarts",
                principalColumn: "CartId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckOutUsers_AddToCarts_AddToCartCartId",
                table: "CheckOutUsers");

            migrationBuilder.DropIndex(
                name: "IX_CheckOutUsers_AddToCartCartId",
                table: "CheckOutUsers");

            migrationBuilder.DropColumn(
                name: "AddToCartCartId",
                table: "CheckOutUsers");
        }
    }
}
