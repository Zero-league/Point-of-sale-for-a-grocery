using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace POS.DataSource.Migrations
{
    public partial class ExpensesMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_ExpenseType_ExpeId",
                table: "Expenses");

            migrationBuilder.DropTable(
                name: "ExpenseType");

            migrationBuilder.DropColumn(
                name: "ExpeId",
                table: "Expenses");

            migrationBuilder.AddColumn<int>(
                name: "ExpId",
                table: "Expenses",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Expenses",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "Payment",
                table: "Expenses",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "expenseType",
                table: "Expenses",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Expenses",
                table: "Expenses",
                column: "ExpId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Expenses",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "ExpId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "Payment",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "expenseType",
                table: "Expenses");

            migrationBuilder.AddColumn<int>(
                name: "ExpeId",
                table: "Expenses",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ExpenseType",
                columns: table => new
                {
                    TempId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.UniqueConstraint("AK_ExpenseType_TempId", x => x.TempId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_ExpenseType_ExpeId",
                table: "Expenses",
                column: "ExpeId",
                principalTable: "ExpenseType",
                principalColumn: "TempId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
