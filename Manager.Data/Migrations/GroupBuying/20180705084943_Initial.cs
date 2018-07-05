using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Manager.Data.migrations.groupbuying
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "GroupBuying");

            migrationBuilder.CreateTable(
                name: "Store",
                schema: "GroupBuying",
                columns: table => new
                {
                    StoreId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 32, nullable: false),
                    Description = table.Column<string>(maxLength: 512, nullable: true),
                    PhoneType = table.Column<int>(nullable: false),
                    CountryCode = table.Column<string>(maxLength: 4, nullable: false),
                    AreaCode = table.Column<string>(maxLength: 4, nullable: false),
                    BaseNumber = table.Column<string>(maxLength: 16, nullable: false),
                    Extension = table.Column<string>(maxLength: 8, nullable: false),
                    PostalCode = table.Column<string>(maxLength: 8, nullable: false),
                    Country = table.Column<string>(maxLength: 32, nullable: false),
                    City = table.Column<string>(maxLength: 32, nullable: false),
                    District = table.Column<string>(maxLength: 32, nullable: false),
                    Street = table.Column<string>(maxLength: 128, nullable: false),
                    Remark = table.Column<string>(maxLength: 512, nullable: true),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.StoreId);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                schema: "GroupBuying",
                columns: table => new
                {
                    ProductCategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 32, nullable: false),
                    StoreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => x.ProductCategoryId);
                    table.ForeignKey(
                        name: "FK_ProductCategory_Store_StoreId",
                        column: x => x.StoreId,
                        principalSchema: "GroupBuying",
                        principalTable: "Store",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "GroupBuying",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 32, nullable: false),
                    Description = table.Column<string>(maxLength: 512, nullable: true),
                    ProductCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Product_ProductCategory_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalSchema: "GroupBuying",
                        principalTable: "ProductCategory",
                        principalColumn: "ProductCategoryId",
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
                    Price = table.Column<decimal>(type: "decimal(19, 4)", nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductCategoryId",
                schema: "GroupBuying",
                table: "Product",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_StoreId",
                schema: "GroupBuying",
                table: "ProductCategory",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductItem_ProductId",
                schema: "GroupBuying",
                table: "ProductItem",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductItem",
                schema: "GroupBuying");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "GroupBuying");

            migrationBuilder.DropTable(
                name: "ProductCategory",
                schema: "GroupBuying");

            migrationBuilder.DropTable(
                name: "Store",
                schema: "GroupBuying");
        }
    }
}
