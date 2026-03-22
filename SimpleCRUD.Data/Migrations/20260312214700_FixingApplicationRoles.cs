using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleCRUD.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixingApplicationRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationRoleName",
                table: "ApplicationRoles");

            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationId",
                table: "ApplicationRoles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RoleId",
                table: "ApplicationRoles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationId",
                table: "ApplicationRoles");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "ApplicationRoles");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationRoleName",
                table: "ApplicationRoles",
                type: "varchar(250)",
                unicode: false,
                maxLength: 250,
                nullable: false,
                defaultValue: "");
        }
    }
}
