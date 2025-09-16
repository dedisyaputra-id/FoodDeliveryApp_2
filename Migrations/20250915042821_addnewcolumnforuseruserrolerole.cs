using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapifirst.Migrations
{
    /// <inheritdoc />
    public partial class addnewcolumnforuseruserrolerole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "dateAdd",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "dateEdit",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "dlt",
                table: "Users",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<string>(
                name: "opAdd",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "opEdit",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "pcAdd",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "pcEdit",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "dateAdd",
                table: "UserRoles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "dateEdit",
                table: "UserRoles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "dlt",
                table: "UserRoles",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<string>(
                name: "opAdd",
                table: "UserRoles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "opEdit",
                table: "UserRoles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "pcAdd",
                table: "UserRoles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "pcEdit",
                table: "UserRoles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "dateAdd",
                table: "Roles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "dateEdit",
                table: "Roles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "dlt",
                table: "Roles",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<string>(
                name: "opAdd",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "opEdit",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "pcAdd",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "pcEdit",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "dateAdd", "dateEdit", "dlt", "opAdd", "opEdit", "pcAdd", "pcEdit" },
                values: new object[] { null, null, (byte)0, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "dateAdd", "dateEdit", "dlt", "opAdd", "opEdit", "pcAdd", "pcEdit" },
                values: new object[] { null, null, (byte)0, null, null, null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dateAdd",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "dateEdit",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "dlt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "opAdd",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "opEdit",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "pcAdd",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "pcEdit",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "dateAdd",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "dateEdit",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "dlt",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "opAdd",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "opEdit",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "pcAdd",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "pcEdit",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "dateAdd",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "dateEdit",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "dlt",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "opAdd",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "opEdit",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "pcAdd",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "pcEdit",
                table: "Roles");
        }
    }
}
