using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MatchaLatte.Catalog.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Catalog");

            migrationBuilder.EnsureSchema(
                name: "Common");

            migrationBuilder.CreateTable(
                name: "Store",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
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
                    table.PrimaryKey("PK_Store", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventLog",
                schema: "Common",
                columns: table => new
                {
                    EventId = table.Column<Guid>(nullable: false),
                    EventTypeNamespace = table.Column<string>(maxLength: 256, nullable: false),
                    EventTypeName = table.Column<string>(maxLength: 256, nullable: false),
                    EventContent = table.Column<string>(nullable: false),
                    PublishState = table.Column<int>(nullable: false),
                    PublishCount = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventLog", x => x.EventId);
                });

            migrationBuilder.CreateTable(
                name: "Group",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    StoreId = table.Column<Guid>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    Remark = table.Column<string>(maxLength: 512, nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Group_Store_StoreId",
                        column: x => x.StoreId,
                        principalSchema: "Catalog",
                        principalTable: "Store",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 32, nullable: false),
                    IsDefault = table.Column<bool>(nullable: false),
                    Sequence = table.Column<int>(nullable: false),
                    StoreId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCategory_Store_StoreId",
                        column: x => x.StoreId,
                        principalSchema: "Catalog",
                        principalTable: "Store",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 32, nullable: false),
                    Description = table.Column<string>(maxLength: 512, nullable: true),
                    Sequence = table.Column<int>(nullable: false),
                    ProductCategoryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_ProductCategory_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalSchema: "Catalog",
                        principalTable: "ProductCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductItem",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 32, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(19, 4)", nullable: false),
                    ProductId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductItem_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Catalog",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Group_StoreId",
                schema: "Catalog",
                table: "Group",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductCategoryId",
                schema: "Catalog",
                table: "Product",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_StoreId",
                schema: "Catalog",
                table: "ProductCategory",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductItem_ProductId",
                schema: "Catalog",
                table: "ProductItem",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Group",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "ProductItem",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "EventLog",
                schema: "Common");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "ProductCategory",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Store",
                schema: "Catalog");
        }
    }
}
