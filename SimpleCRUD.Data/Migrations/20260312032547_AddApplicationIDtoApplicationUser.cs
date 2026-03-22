using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleCRUD.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddApplicationIDtoApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationID",
                table: "ApplicationUser",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationID",
                table: "ApplicationUser");
        }
    }
}
