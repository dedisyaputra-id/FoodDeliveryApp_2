using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapifirst.Migrations
{
    /// <inheritdoc />
    public partial class addColumnDlt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpAdd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PcAdd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateAdd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OpEdit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PcEdit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateEdit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dlt = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalAmount = table.Column<float>(type: "real", nullable: true),
                    OpAdd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PcAdd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateAdd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OpEdit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PcEdit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateEdit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dlt = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductPrice = table.Column<float>(type: "real", nullable: false),
                    ProductCount = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    opAdd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pcAdd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dateAdd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    opEdit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pcEdit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dateEdit = table.Column<DateTime>(type: "datetime2", nullable: true),
                    dlt = table.Column<byte>(type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    OpAdd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PcAdd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateAdd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OpEdit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PcEdit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateEdit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dlt = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailId);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
