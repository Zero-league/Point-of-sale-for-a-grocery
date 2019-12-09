using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace POS.DataSource.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bill",
                columns: table => new
                {
                    BillId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTime = table.Column<DateTime>(nullable: false),
                    Discount = table.Column<int>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    SalesPerson = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bill", x => x.BillId);
                });

            migrationBuilder.CreateTable(
                name: "Sale",
                columns: table => new
                {
                    ItemsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemsName = table.Column<string>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    RetailPrice = table.Column<int>(nullable: false),
                    SalesPerson = table.Column<string>(nullable: true),
                    BillId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sale", x => x.ItemsId);
                    table.ForeignKey(
                        name: "FK_Sale_Bill_BillId",
                        column: x => x.BillId,
                        principalTable: "Bill",
                        principalColumn: "BillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sale_BillId",
                table: "Sale",
                column: "BillId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sale");

            migrationBuilder.DropTable(
                name: "Bill");
        }
    }
}
