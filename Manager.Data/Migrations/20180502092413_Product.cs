using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Manager.Data.Migrations
{
    public partial class Product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                schema: "GroupBuying",
                table: "Product");

            migrationBuilder.CreateTable(
                name: "ProductItem",
                schema: "GroupBuying",
                columns: table => new
                {
                    ProductItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 32, nullable: true),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductItem", x => x.ProductItemId);
                    table.ForeignKey(
                        name: "FK_ProductItem_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "GroupBuying",
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductOption",
                schema: "GroupBuying",
                columns: table => new
                {
                    ProductOptionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductOptionType = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOption", x => x.ProductOptionId);
                });

            migrationBuilder.CreateTable(
                name: "ProductProductOption",
                schema: "GroupBuying",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false),
                    ProductOptionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductProductOption", x => new { x.ProductId, x.ProductOptionId });
                    table.ForeignKey(
                        name: "FK_ProductProductOption_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "GroupBuying",
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductProductOption_ProductOption_ProductOptionId",
                        column: x => x.ProductOptionId,
                        principalSchema: "GroupBuying",
                        principalTable: "ProductOption",
                        principalColumn: "ProductOptionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductItem_ProductId",
                schema: "GroupBuying",
                table: "ProductItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOption_ProductOptionType",
                schema: "GroupBuying",
                table: "ProductOption",
                column: "ProductOptionType");

            migrationBuilder.CreateIndex(
                name: "IX_ProductProductOption_ProductOptionId",
                schema: "GroupBuying",
                table: "ProductProductOption",
                column: "ProductOptionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductItem",
                schema: "GroupBuying");

            migrationBuilder.DropTable(
                name: "ProductProductOption",
                schema: "GroupBuying");

            migrationBuilder.DropTable(
                name: "ProductOption",
                schema: "GroupBuying");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                schema: "GroupBuying",
                table: "Product",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
