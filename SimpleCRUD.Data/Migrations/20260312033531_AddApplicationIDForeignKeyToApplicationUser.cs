using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleCRUD.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddApplicationIDForeignKeyToApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
