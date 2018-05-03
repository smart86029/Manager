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

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "GroupBuying",
                table: "Product",
                maxLength: 64,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProductAccessory",
                schema: "GroupBuying",
                columns: table => new
                {
                    ProductAccessoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 32, nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAccessory", x => x.ProductAccessoryId);
                    table.ForeignKey(
                        name: "FK_ProductAccessory_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "GroupBuying",
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductItem",
                schema: "GroupBuying",
                columns: table => new
                {
                    ProductItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 32, nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
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
                    Name = table.Column<string>(maxLength: 32, nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOption", x => x.ProductOptionId);
                    table.ForeignKey(
                        name: "FK_ProductOption_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "GroupBuying",
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductAccessory_ProductId",
                schema: "GroupBuying",
                table: "ProductAccessory",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductItem_ProductId",
                schema: "GroupBuying",
                table: "ProductItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOption_ProductId",
                schema: "GroupBuying",
                table: "ProductOption",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOption_ProductOptionType",
                schema: "GroupBuying",
                table: "ProductOption",
                column: "ProductOptionType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductAccessory",
                schema: "GroupBuying");

            migrationBuilder.DropTable(
                name: "ProductItem",
                schema: "GroupBuying");

            migrationBuilder.DropTable(
                name: "ProductOption",
                schema: "GroupBuying");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "GroupBuying",
                table: "Product");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                schema: "GroupBuying",
                table: "Product",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
