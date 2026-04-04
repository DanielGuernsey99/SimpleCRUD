using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleCRUD.Data.Migrations
{
    /// <inheritdoc />
    public partial class UserRoleToRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "UserRoles",
                newName: "Roles");

            migrationBuilder.RenameColumn(
                name: "ApplicationID",
                table: "ApplicationUserRoles",
                newName: "ApplicationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "UserRoles");

            migrationBuilder.RenameColumn(
                name: "ApplicationId",
                table: "ApplicationUserRoles",
                newName: "ApplicationID");
        }
    }
}
