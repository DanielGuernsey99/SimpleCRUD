using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleCRUD.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixingEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldUnicode: false,
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldUnicode: false,
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationName",
                table: "Applications",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldUnicode: false,
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationDescription",
                table: "Applications",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(8000)",
                oldUnicode: false,
                oldMaxLength: 8000);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUser_Applications_ApplicationID",
                table: "ApplicationUser");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationUser_ApplicationID",
                table: "ApplicationUser");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                type: "varchar(250)",
                unicode: false,
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "varchar(250)",
                unicode: false,
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationID1",
                table: "ApplicationUser",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationName",
                table: "Applications",
                type: "varchar(250)",
                unicode: false,
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationDescription",
                table: "Applications",
                type: "varchar(8000)",
                unicode: false,
                maxLength: 8000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
    }
}
