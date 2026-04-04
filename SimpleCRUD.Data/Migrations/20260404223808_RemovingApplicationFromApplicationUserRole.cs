using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleCRUD.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovingApplicationFromApplicationUserRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationID",
                table: "ApplicationUserRoles");

            migrationBuilder.DropColumn(
                name: "ApplicationId",
                table: "ApplicationUserRoles");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationId",
                table: "ApplicationUserRoles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationID",
                table: "ApplicationUserRoles",
                column: "ApplicationId",
                principalTable: "Applications",
                principalColumn: "ApplicationID");
        }
    }
}
