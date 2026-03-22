using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleCRUD.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "ApplicationRoles",
            //    columns: table => new
            //    {
            //        ApplicationRoleID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        ApplicationRoleName = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ApplicationRoleID", x => x.ApplicationRoleID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Applications",
            //    columns: table => new
            //    {
            //        ApplicationID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        ApplicationName = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
            //        ApplicationDescription = table.Column<string>(type: "varchar(8000)", unicode: false, maxLength: 8000, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ApplicationID", x => x.ApplicationID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "UserRoles",
            //    columns: table => new
            //    {
            //        RoleID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        RoleName = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
            //        Description = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__Roles__8AFACE3A8C985CAD", x => x.RoleID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Users",
            //    columns: table => new
            //    {
            //        UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        FirstName = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
            //        LastName = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__Users__3214EC27BB834F9E", x => x.UserID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ApplicationUser",
            //    columns: table => new
            //    {
            //        ApplicationUserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ApplicationUserID", x => x.ApplicationUserID);
            //        table.ForeignKey(
            //            name: "FK_UserID",
            //            column: x => x.UserID,
            //            principalTable: "Users",
            //            principalColumn: "UserID");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ApplicationUserRoles",
            //    columns: table => new
            //    {
            //        ApplicationUserRolesID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        ApplicationID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        ApplicationUserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        ApplicationRoleID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ApplicationUserRolesID", x => x.ApplicationUserRolesID);
            //        table.ForeignKey(
            //            name: "FK_ApplicationID",
            //            column: x => x.ApplicationID,
            //            principalTable: "Applications",
            //            principalColumn: "ApplicationID");
            //        table.ForeignKey(
            //            name: "FK_ApplicationRoleID",
            //            column: x => x.ApplicationRoleID,
            //            principalTable: "ApplicationRoles",
            //            principalColumn: "ApplicationRoleID");
            //        table.ForeignKey(
            //            name: "FK_ApplicationUserID",
            //            column: x => x.ApplicationUserID,
            //            principalTable: "ApplicationUser",
            //            principalColumn: "ApplicationUserID");
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_ApplicationUser_UserID",
            //    table: "ApplicationUser",
            //    column: "UserID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ApplicationUserRoles_ApplicationID",
            //    table: "ApplicationUserRoles",
            //    column: "ApplicationID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ApplicationUserRoles_ApplicationRoleID",
            //    table: "ApplicationUserRoles",
            //    column: "ApplicationRoleID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ApplicationUserRoles_ApplicationUserID",
            //    table: "ApplicationUserRoles",
            //    column: "ApplicationUserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserRoles");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "ApplicationRoles");

            migrationBuilder.DropTable(
                name: "ApplicationUser");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
