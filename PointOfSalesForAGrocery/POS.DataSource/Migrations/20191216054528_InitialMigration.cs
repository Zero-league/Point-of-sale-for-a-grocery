using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace POS.DataSource.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bill",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTime = table.Column<DateTime>(nullable: false),
                    Discount = table.Column<int>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    SalesPerson = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bill", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    ExpId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    expenseType = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Payment = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.ExpId);
                });

            migrationBuilder.CreateTable(
                name: "ItemCatogaries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CatogaryName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCatogaries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemLocations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationName = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemLocations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Unitmesurements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mesurementName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unitmesurements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemsName = table.Column<string>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    RetailPrice = table.Column<int>(nullable: false),
                    SalesPerson = table.Column<string>(nullable: true),
                    BillId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sale", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sale_Bill_BillId",
                        column: x => x.BillId,
                        principalTable: "Bill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(nullable: false),
                    ExpireDate = table.Column<string>(nullable: true),
                    QTY = table.Column<int>(nullable: false),
                    Brand = table.Column<string>(nullable: true),
                    ItemCost = table.Column<int>(nullable: false),
                    RetailPrice = table.Column<int>(nullable: false),
                    ItemCatogaryId = table.Column<int>(nullable: false),
                    ItemLocationId = table.Column<int>(nullable: false),
                    UnitmesurementId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventories_ItemCatogaries_ItemCatogaryId",
                        column: x => x.ItemCatogaryId,
                        principalTable: "ItemCatogaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventories_ItemLocations_ItemLocationId",
                        column: x => x.ItemLocationId,
                        principalTable: "ItemLocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventories_Unitmesurements_UnitmesurementId",
                        column: x => x.UnitmesurementId,
                        principalTable: "Unitmesurements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_ItemCatogaryId",
                table: "Inventories",
                column: "ItemCatogaryId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_ItemLocationId",
                table: "Inventories",
                column: "ItemLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_UnitmesurementId",
                table: "Inventories",
                column: "UnitmesurementId");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_BillId",
                table: "Sale",
                column: "BillId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "Sale");

            migrationBuilder.DropTable(
                name: "ItemCatogaries");

            migrationBuilder.DropTable(
                name: "ItemLocations");

            migrationBuilder.DropTable(
                name: "Unitmesurements");

            migrationBuilder.DropTable(
                name: "Bill");
        }
    }
}
