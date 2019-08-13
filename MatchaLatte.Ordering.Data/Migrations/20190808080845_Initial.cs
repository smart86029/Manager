using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MatchaLatte.Ordering.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Common");

            migrationBuilder.EnsureSchema(
                name: "Ordering");

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
                name: "Buyer",
                schema: "Ordering",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 32, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buyer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                schema: "Ordering",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    OrderStatus = table.Column<int>(nullable: false),
                    AmountPaid = table.Column<decimal>(type: "decimal(19, 4)", nullable: false),
                    GroupId = table.Column<Guid>(nullable: false),
                    BuyerId = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    PaidOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                schema: "Ordering",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    ProductName = table.Column<string>(maxLength: 32, nullable: false),
                    ProductItemId = table.Column<Guid>(nullable: false),
                    ProductItemName = table.Column<string>(maxLength: 32, nullable: false),
                    ProductItemPrice = table.Column<decimal>(type: "decimal(19, 4)", nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    OrderId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItem_Order_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "Ordering",
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItemProductAccessory",
                schema: "Ordering",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    OrderItemId = table.Column<Guid>(nullable: false),
                    ProductAccessoryId = table.Column<Guid>(nullable: false),
                    ProductAccessoryName = table.Column<string>(maxLength: 32, nullable: false),
                    ProductAccessoryPrice = table.Column<decimal>(type: "decimal(19, 4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItemProductAccessory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItemProductAccessory_OrderItem_OrderItemId",
                        column: x => x.OrderItemId,
                        principalSchema: "Ordering",
                        principalTable: "OrderItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_BuyerId",
                schema: "Ordering",
                table: "Order",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_GroupId",
                schema: "Ordering",
                table: "Order",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId",
                schema: "Ordering",
                table: "OrderItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ProductId",
                schema: "Ordering",
                table: "OrderItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ProductItemId",
                schema: "Ordering",
                table: "OrderItem",
                column: "ProductItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemProductAccessory_OrderItemId",
                schema: "Ordering",
                table: "OrderItemProductAccessory",
                column: "OrderItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemProductAccessory_ProductAccessoryId",
                schema: "Ordering",
                table: "OrderItemProductAccessory",
                column: "ProductAccessoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventLog",
                schema: "Common");

            migrationBuilder.DropTable(
                name: "Buyer",
                schema: "Ordering");

            migrationBuilder.DropTable(
                name: "OrderItemProductAccessory",
                schema: "Ordering");

            migrationBuilder.DropTable(
                name: "OrderItem",
                schema: "Ordering");

            migrationBuilder.DropTable(
                name: "Order",
                schema: "Ordering");
        }
    }
}
