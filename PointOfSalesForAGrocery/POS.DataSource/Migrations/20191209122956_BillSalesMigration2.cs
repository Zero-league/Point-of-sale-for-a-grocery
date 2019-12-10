using Microsoft.EntityFrameworkCore.Migrations;

namespace POS.DataSource.Migrations
{
    public partial class BillSalesMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sale_Bill_BillId",
                table: "Sale");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sale",
                table: "Sale");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bill",
                table: "Bill");

            migrationBuilder.DropColumn(
                name: "ItemsId",
                table: "Sale");

            migrationBuilder.DropColumn(
                name: "BillId",
                table: "Bill");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Sale",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Bill",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sale",
                table: "Sale",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bill",
                table: "Bill",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_Bill_BillId",
                table: "Sale",
                column: "BillId",
                principalTable: "Bill",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sale_Bill_BillId",
                table: "Sale");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sale",
                table: "Sale");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bill",
                table: "Bill");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Sale");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Bill");

            migrationBuilder.AddColumn<int>(
                name: "ItemsId",
                table: "Sale",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "BillId",
                table: "Bill",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sale",
                table: "Sale",
                column: "ItemsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bill",
                table: "Bill",
                column: "BillId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_Bill_BillId",
                table: "Sale",
                column: "BillId",
                principalTable: "Bill",
                principalColumn: "BillId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
