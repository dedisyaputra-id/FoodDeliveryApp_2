using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapifirst.Migrations
{
    /// <inheritdoc />
    public partial class CreatingFoodDeliveryDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductPrice = table.Column<float>(type: "real", nullable: false),
                    ProductCount = table.Column<int>(type: "int", nullable: false),
                    opAdd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pcAdd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateAdd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    opEdit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pcEdit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateEdit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dlt = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
