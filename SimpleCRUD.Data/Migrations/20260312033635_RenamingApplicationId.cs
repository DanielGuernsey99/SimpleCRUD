using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleCRUD.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenamingApplicationId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUser_Applications_ApplicationID",
                table: "ApplicationUser");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationUser_ApplicationID",
                table: "ApplicationUser");

            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationID1",
                table: "ApplicationUser",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUser_ApplicationID1",
                table: "ApplicationUser",
                column: "ApplicationID1");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUser_Applications_ApplicationID1",
                table: "ApplicationUser",
                column: "ApplicationID1",
                principalTable: "Applications",
                principalColumn: "ApplicationID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUser_Applications_ApplicationID1",
                table: "ApplicationUser");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationUser_ApplicationID1",
                table: "ApplicationUser");

            migrationBuilder.DropColumn(
                name: "ApplicationID1",
                table: "ApplicationUser");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUser_ApplicationID",
                table: "ApplicationUser",
                column: "ApplicationID");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUser_Applications_ApplicationID",
                table: "ApplicationUser",
                column: "ApplicationID",
                principalTable: "Applications",
                principalColumn: "ApplicationID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
