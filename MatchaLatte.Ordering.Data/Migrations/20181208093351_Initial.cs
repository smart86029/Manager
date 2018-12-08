using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MatchaLatte.Ordering.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Ordering");

            migrationBuilder.CreateTable(
                name: "Group",
                schema: "Ordering",
                columns: table => new
                {
                    GroupId = table.Column<Guid>(nullable: false),
                    StoreId = table.Column<Guid>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    Remark = table.Column<string>(maxLength: 512, nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.GroupId);
                });

            migrationBuilder.CreateTable(
                name: "Store",
                schema: "Ordering",
                columns: table => new
                {
                    StoreId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 32, nullable: false),
                    Description = table.Column<string>(maxLength: 512, nullable: true),
                    LogoFileName = table.Column<string>(maxLength: 256, nullable: false),
                    PhoneType = table.Column<int>(nullable: false),
                    CountryCode = table.Column<string>(maxLength: 4, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 32, nullable: false),
                    PostalCode = table.Column<string>(maxLength: 8, nullable: false),
                    Country = table.Column<string>(maxLength: 32, nullable: false),
                    City = table.Column<string>(maxLength: 32, nullable: false),
                    District = table.Column<string>(maxLength: 32, nullable: false),
                    Street = table.Column<string>(maxLength: 128, nullable: false),
                    Remark = table.Column<string>(maxLength: 512, nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.StoreId);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                schema: "Ordering",
                columns: table => new
                {
                    ProductCategoryId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 32, nullable: false),
                    IsDefault = table.Column<bool>(nullable: false),
                    Sequence = table.Column<int>(nullable: false),
                    StoreId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => x.ProductCategoryId);
                    table.ForeignKey(
                        name: "FK_ProductCategory_Store_StoreId",
                        column: x => x.StoreId,
                        principalSchema: "Ordering",
                        principalTable: "Store",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "Ordering",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 32, nullable: false),
                    Description = table.Column<string>(maxLength: 512, nullable: true),
                    Sequence = table.Column<int>(nullable: false),
                    ProductCategoryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Product_ProductCategory_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalSchema: "Ordering",
                        principalTable: "ProductCategory",
                        principalColumn: "ProductCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductItem",
                schema: "Ordering",
                columns: table => new
                {
                    ProductItemId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 32, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(19, 4)", nullable: false),
                    ProductId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductItem", x => x.ProductItemId);
                    table.ForeignKey(
                        name: "FK_ProductItem_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Ordering",
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductCategoryId",
                schema: "Ordering",
                table: "Product",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_StoreId",
                schema: "Ordering",
                table: "ProductCategory",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductItem_ProductId",
                schema: "Ordering",
                table: "ProductItem",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Group",
                schema: "Ordering");

            migrationBuilder.DropTable(
                name: "ProductItem",
                schema: "Ordering");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "Ordering");

            migrationBuilder.DropTable(
                name: "ProductCategory",
                schema: "Ordering");

            migrationBuilder.DropTable(
                name: "Store",
                schema: "Ordering");
        }
    }
}
