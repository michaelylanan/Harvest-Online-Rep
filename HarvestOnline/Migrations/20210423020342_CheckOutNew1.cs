using Microsoft.EntityFrameworkCore.Migrations;

namespace HarvestOnline.Migrations
{
    public partial class CheckOutNew1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckOutUsers_Addresses_AddressId",
                table: "CheckOutUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckOutUsers_ShippingFees_ShippingFeeShippingId",
                table: "CheckOutUsers");

            migrationBuilder.DropTable(
                name: "ShippingFees");

            migrationBuilder.DropIndex(
                name: "IX_CheckOutUsers_AddressId",
                table: "CheckOutUsers");

            migrationBuilder.DropIndex(
                name: "IX_CheckOutUsers_ShippingFeeShippingId",
                table: "CheckOutUsers");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "CheckOutUsers");

            migrationBuilder.DropColumn(
                name: "ShippingFeeShippingId",
                table: "CheckOutUsers");

            migrationBuilder.DropColumn(
                name: "ShippingId",
                table: "CheckOutUsers");

            migrationBuilder.RenameColumn(
                name: "DateModified",
                table: "CheckOutUsers",
                newName: "DateAdded");

            migrationBuilder.AddColumn<decimal>(
                name: "ShippingFee",
                table: "CheckOutUsers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShippingFee",
                table: "CheckOutUsers");

            migrationBuilder.RenameColumn(
                name: "DateAdded",
                table: "CheckOutUsers",
                newName: "DateModified");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "CheckOutUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShippingFeeShippingId",
                table: "CheckOutUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShippingId",
                table: "CheckOutUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ShippingFees",
                columns: table => new
                {
                    ShippingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Courrier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fee = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingFees", x => x.ShippingId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CheckOutUsers_AddressId",
                table: "CheckOutUsers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckOutUsers_ShippingFeeShippingId",
                table: "CheckOutUsers",
                column: "ShippingFeeShippingId");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckOutUsers_Addresses_AddressId",
                table: "CheckOutUsers",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckOutUsers_ShippingFees_ShippingFeeShippingId",
                table: "CheckOutUsers",
                column: "ShippingFeeShippingId",
                principalTable: "ShippingFees",
                principalColumn: "ShippingId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
