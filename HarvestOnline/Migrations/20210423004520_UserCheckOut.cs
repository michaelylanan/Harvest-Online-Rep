using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HarvestOnline.Migrations
{
    public partial class UserCheckOut : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "ShippingFee",
                columns: table => new
                {
                    ShippingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Courrier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fee = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingFee", x => x.ShippingId);
                });

            migrationBuilder.CreateTable(
                name: "CheckOutUsers",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalPrice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShippingFeeShippingId = table.Column<int>(type: "int", nullable: true),
                    ShippingId = table.Column<int>(type: "int", nullable: true),
                    TotalPayment = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OverallTotal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckOutUsers", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_CheckOutUsers_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CheckOutUsers_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CheckOutUsers_ShippingFee_ShippingFeeShippingId",
                        column: x => x.ShippingFeeShippingId,
                        principalTable: "ShippingFee",
                        principalColumn: "ShippingId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CheckOutUsers_AddressId",
                table: "CheckOutUsers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckOutUsers_CustomerId",
                table: "CheckOutUsers",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckOutUsers_ShippingFeeShippingId",
                table: "CheckOutUsers",
                column: "ShippingFeeShippingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheckOutUsers");

            migrationBuilder.DropTable(
                name: "ShippingFee");

            migrationBuilder.CreateTable(
                name: "CheckOut",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfItem = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    ShippingFee = table.Column<float>(type: "real", nullable: false),
                    Total = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalPayment = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckOut", x => x.OrderId);
                });
        }
    }
}
