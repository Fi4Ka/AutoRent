using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoRentWeb.DAL.Migrations
{
    public partial class url : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CompanyDelegate_UserId",
                table: "CompanyDelegate");

            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "Auto");

            migrationBuilder.AddColumn<string>(
                name: "AvatarUrl",
                table: "Auto",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CompanyDelegate_UserId",
                table: "CompanyDelegate",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CompanyDelegate_UserId",
                table: "CompanyDelegate");

            migrationBuilder.DropColumn(
                name: "AvatarUrl",
                table: "Auto");

            migrationBuilder.AddColumn<byte[]>(
                name: "Avatar",
                table: "Auto",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CompanyDelegate_UserId",
                table: "CompanyDelegate",
                column: "UserId");
        }
    }
}
