using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Manager.Data.Migrations
{
    public partial class AddOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Order",
                schema: "GroupBuying",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AmountPayable = table.Column<decimal>(type: "decimal(19, 4)", nullable: false),
                    AmountPaid = table.Column<decimal>(type: "decimal(19, 4)", nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Order_BusinessEntity_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "Generic",
                        principalTable: "BusinessEntity",
                        principalColumn: "BusinessEntityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                schema: "GroupBuying",
                columns: table => new
                {
                    OrderDetailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductItemName = table.Column<string>(maxLength: 64, nullable: true),
                    ProductItemPrice = table.Column<decimal>(type: "decimal(19, 4)", nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    OrderId = table.Column<int>(nullable: false),
                    ProductItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.OrderDetailId);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Order_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "GroupBuying",
                        principalTable: "Order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetail_ProductItem_ProductItemId",
                        column: x => x.ProductItemId,
                        principalSchema: "GroupBuying",
                        principalTable: "ProductItem",
                        principalColumn: "ProductItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetailProductAccessory",
                schema: "GroupBuying",
                columns: table => new
                {
                    OrderDetailId = table.Column<int>(nullable: false),
                    ProductAccessoryId = table.Column<int>(nullable: false),
                    ProductAccessoryName = table.Column<string>(maxLength: 32, nullable: false),
                    ProductAccessoryPrice = table.Column<decimal>(type: "decimal(19, 4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetailProductAccessory", x => new { x.OrderDetailId, x.ProductAccessoryId });
                    table.ForeignKey(
                        name: "FK_OrderDetailProductAccessory_OrderDetail_OrderDetailId",
                        column: x => x.OrderDetailId,
                        principalSchema: "GroupBuying",
                        principalTable: "OrderDetail",
                        principalColumn: "OrderDetailId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetailProductAccessory_ProductAccessory_ProductAccessoryId",
                        column: x => x.ProductAccessoryId,
                        principalSchema: "GroupBuying",
                        principalTable: "ProductAccessory",
                        principalColumn: "ProductAccessoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                schema: "GroupBuying",
                table: "ProductItem",
                keyColumn: "ProductItemId",
                keyValue: 2,
                column: "ProductId",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "GroupBuying",
                table: "ProductItem",
                keyColumn: "ProductItemId",
                keyValue: 3,
                column: "ProductId",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "GroupBuying",
                table: "ProductItem",
                keyColumn: "ProductItemId",
                keyValue: 4,
                column: "ProductId",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "GroupBuying",
                table: "ProductItem",
                keyColumn: "ProductItemId",
                keyValue: 5,
                column: "ProductId",
                value: 5);

            migrationBuilder.UpdateData(
                schema: "GroupBuying",
                table: "ProductItem",
                keyColumn: "ProductItemId",
                keyValue: 6,
                column: "ProductId",
                value: 6);

            migrationBuilder.UpdateData(
                schema: "GroupBuying",
                table: "ProductItem",
                keyColumn: "ProductItemId",
                keyValue: 7,
                column: "ProductId",
                value: 7);

            migrationBuilder.UpdateData(
                schema: "GroupBuying",
                table: "ProductItem",
                keyColumn: "ProductItemId",
                keyValue: 8,
                column: "ProductId",
                value: 8);

            migrationBuilder.UpdateData(
                schema: "GroupBuying",
                table: "ProductItem",
                keyColumn: "ProductItemId",
                keyValue: 9,
                column: "ProductId",
                value: 9);

            migrationBuilder.UpdateData(
                schema: "GroupBuying",
                table: "ProductItem",
                keyColumn: "ProductItemId",
                keyValue: 10,
                column: "ProductId",
                value: 10);

            migrationBuilder.UpdateData(
                schema: "GroupBuying",
                table: "ProductItem",
                keyColumn: "ProductItemId",
                keyValue: 11,
                column: "ProductId",
                value: 11);

            migrationBuilder.UpdateData(
                schema: "GroupBuying",
                table: "ProductItem",
                keyColumn: "ProductItemId",
                keyValue: 12,
                column: "ProductId",
                value: 12);

            migrationBuilder.UpdateData(
                schema: "GroupBuying",
                table: "ProductItem",
                keyColumn: "ProductItemId",
                keyValue: 13,
                column: "ProductId",
                value: 13);

            migrationBuilder.UpdateData(
                schema: "GroupBuying",
                table: "ProductItem",
                keyColumn: "ProductItemId",
                keyValue: 14,
                column: "ProductId",
                value: 14);

            migrationBuilder.UpdateData(
                schema: "GroupBuying",
                table: "ProductItem",
                keyColumn: "ProductItemId",
                keyValue: 15,
                column: "ProductId",
                value: 15);

            migrationBuilder.UpdateData(
                schema: "GroupBuying",
                table: "ProductItem",
                keyColumn: "ProductItemId",
                keyValue: 16,
                column: "ProductId",
                value: 16);

            migrationBuilder.CreateIndex(
                name: "IX_Order_CreatedBy",
                schema: "GroupBuying",
                table: "Order",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderId",
                schema: "GroupBuying",
                table: "OrderDetail",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_ProductItemId",
                schema: "GroupBuying",
                table: "OrderDetail",
                column: "ProductItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetailProductAccessory_ProductAccessoryId",
                schema: "GroupBuying",
                table: "OrderDetailProductAccessory",
                column: "ProductAccessoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetailProductAccessory",
                schema: "GroupBuying");

            migrationBuilder.DropTable(
                name: "OrderDetail",
                schema: "GroupBuying");

            migrationBuilder.DropTable(
                name: "Order",
                schema: "GroupBuying");

            migrationBuilder.UpdateData(
                schema: "GroupBuying",
                table: "ProductItem",
                keyColumn: "ProductItemId",
                keyValue: 2,
                column: "ProductId",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "GroupBuying",
                table: "ProductItem",
                keyColumn: "ProductItemId",
                keyValue: 3,
                column: "ProductId",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "GroupBuying",
                table: "ProductItem",
                keyColumn: "ProductItemId",
                keyValue: 4,
                column: "ProductId",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "GroupBuying",
                table: "ProductItem",
                keyColumn: "ProductItemId",
                keyValue: 5,
                column: "ProductId",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "GroupBuying",
                table: "ProductItem",
                keyColumn: "ProductItemId",
                keyValue: 6,
                column: "ProductId",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "GroupBuying",
                table: "ProductItem",
                keyColumn: "ProductItemId",
                keyValue: 7,
                column: "ProductId",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "GroupBuying",
                table: "ProductItem",
                keyColumn: "ProductItemId",
                keyValue: 8,
                column: "ProductId",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "GroupBuying",
                table: "ProductItem",
                keyColumn: "ProductItemId",
                keyValue: 9,
                column: "ProductId",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "GroupBuying",
                table: "ProductItem",
                keyColumn: "ProductItemId",
                keyValue: 10,
                column: "ProductId",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "GroupBuying",
                table: "ProductItem",
                keyColumn: "ProductItemId",
                keyValue: 11,
                column: "ProductId",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "GroupBuying",
                table: "ProductItem",
                keyColumn: "ProductItemId",
                keyValue: 12,
                column: "ProductId",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "GroupBuying",
                table: "ProductItem",
                keyColumn: "ProductItemId",
                keyValue: 13,
                column: "ProductId",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "GroupBuying",
                table: "ProductItem",
                keyColumn: "ProductItemId",
                keyValue: 14,
                column: "ProductId",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "GroupBuying",
                table: "ProductItem",
                keyColumn: "ProductItemId",
                keyValue: 15,
                column: "ProductId",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "GroupBuying",
                table: "ProductItem",
                keyColumn: "ProductItemId",
                keyValue: 16,
                column: "ProductId",
                value: 1);
        }
    }
}
