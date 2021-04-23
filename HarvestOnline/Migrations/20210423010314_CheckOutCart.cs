using Microsoft.EntityFrameworkCore.Migrations;

namespace HarvestOnline.Migrations
{
    public partial class CheckOutCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckOutUsers_ShippingFee_ShippingFeeShippingId",
                table: "CheckOutUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShippingFee",
                table: "ShippingFee");

            migrationBuilder.RenameTable(
                name: "ShippingFee",
                newName: "ShippingFees");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalPrice",
                table: "CheckOutUsers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShippingFees",
                table: "ShippingFees",
                column: "ShippingId");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckOutUsers_ShippingFees_ShippingFeeShippingId",
                table: "CheckOutUsers",
                column: "ShippingFeeShippingId",
                principalTable: "ShippingFees",
                principalColumn: "ShippingId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckOutUsers_ShippingFees_ShippingFeeShippingId",
                table: "CheckOutUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShippingFees",
                table: "ShippingFees");

            migrationBuilder.RenameTable(
                name: "ShippingFees",
                newName: "ShippingFee");

            migrationBuilder.AlterColumn<string>(
                name: "TotalPrice",
                table: "CheckOutUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShippingFee",
                table: "ShippingFee",
                column: "ShippingId");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckOutUsers_ShippingFee_ShippingFeeShippingId",
                table: "CheckOutUsers",
                column: "ShippingFeeShippingId",
                principalTable: "ShippingFee",
                principalColumn: "ShippingId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
