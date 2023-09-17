using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoRentWeb.DAL.Migrations
{
    public partial class PI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Arendator_BankCard_BankCardId",
                table: "Arendator");

            migrationBuilder.DropTable(
                name: "BankCard");

            migrationBuilder.DropIndex(
                name: "IX_Arendator_BankCardId",
                table: "Arendator");

            migrationBuilder.DropColumn(
                name: "BankCardId",
                table: "Arendator");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BankCardId",
                table: "Arendator",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BankCard",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bill = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CVV = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankCard", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Arendator_BankCardId",
                table: "Arendator",
                column: "BankCardId",
                unique: true,
                filter: "[BankCardId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Arendator_BankCard_BankCardId",
                table: "Arendator",
                column: "BankCardId",
                principalTable: "BankCard",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
