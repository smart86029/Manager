using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Manager.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Generic");

            migrationBuilder.EnsureSchema(
                name: "GroupBuying");

            migrationBuilder.EnsureSchema(
                name: "System");

            migrationBuilder.CreateTable(
                name: "BusinessEntity",
                schema: "Generic",
                columns: table => new
                {
                    BusinessEntityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Discriminator = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 32, nullable: true),
                    LastName = table.Column<string>(maxLength: 32, nullable: true),
                    Gender = table.Column<int>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessEntity", x => x.BusinessEntityId);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                schema: "System",
                columns: table => new
                {
                    MenuId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Area = table.Column<string>(nullable: true),
                    Controller = table.Column<string>(nullable: true),
                    Action = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    IsEnabled = table.Column<bool>(nullable: false),
                    ParentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.MenuId);
                    table.ForeignKey(
                        name: "FK_Menu_Menu_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "System",
                        principalTable: "Menu",
                        principalColumn: "MenuId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                schema: "System",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 32, nullable: false),
                    IsEnabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Group",
                schema: "GroupBuying",
                columns: table => new
                {
                    GroupId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    Remark = table.Column<string>(maxLength: 512, nullable: true),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.GroupId);
                    table.ForeignKey(
                        name: "FK_Group_BusinessEntity_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "Generic",
                        principalTable: "BusinessEntity",
                        principalColumn: "BusinessEntityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Store",
                schema: "GroupBuying",
                columns: table => new
                {
                    StoreId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 32, nullable: false),
                    Description = table.Column<string>(maxLength: 512, nullable: true),
                    Phone = table.Column<string>(maxLength: 32, nullable: true),
                    Address = table.Column<string>(maxLength: 128, nullable: true),
                    Remark = table.Column<string>(maxLength: 512, nullable: true),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.StoreId);
                    table.ForeignKey(
                        name: "FK_Store_BusinessEntity_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "Generic",
                        principalTable: "BusinessEntity",
                        principalColumn: "BusinessEntityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "System",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(maxLength: 32, nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    IsEnabled = table.Column<bool>(nullable: false),
                    BusinessEntityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_User_BusinessEntity_BusinessEntityId",
                        column: x => x.BusinessEntityId,
                        principalSchema: "Generic",
                        principalTable: "BusinessEntity",
                        principalColumn: "BusinessEntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleMenu",
                schema: "System",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false),
                    MenuId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleMenu", x => new { x.RoleId, x.MenuId });
                    table.ForeignKey(
                        name: "FK_RoleMenu_Menu_MenuId",
                        column: x => x.MenuId,
                        principalSchema: "System",
                        principalTable: "Menu",
                        principalColumn: "MenuId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleMenu_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "System",
                        principalTable: "Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupStore",
                schema: "GroupBuying",
                columns: table => new
                {
                    GroupId = table.Column<int>(nullable: false),
                    StoreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupStore", x => new { x.GroupId, x.StoreId });
                    table.ForeignKey(
                        name: "FK_GroupStore_Group_GroupId",
                        column: x => x.GroupId,
                        principalSchema: "GroupBuying",
                        principalTable: "Group",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupStore_Store_StoreId",
                        column: x => x.StoreId,
                        principalSchema: "GroupBuying",
                        principalTable: "Store",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
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
                name: "UserRole",
                schema: "System",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "System",
                        principalTable: "Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "System",
                        principalTable: "User",
                        principalColumn: "UserId",
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
                    Description = table.Column<string>(maxLength: 64, nullable: true),
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
                name: "ProductAccessory",
                schema: "GroupBuying",
                columns: table => new
                {
                    ProductAccessoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 32, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(19, 4)", nullable: false),
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

            migrationBuilder.InsertData(
                schema: "Generic",
                table: "BusinessEntity",
                columns: new[] { "BusinessEntityId", "Discriminator", "BirthDate", "FirstName", "Gender", "LastName" },
                values: new object[] { 1, "Person", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "管理員", 9, "超級" });

            migrationBuilder.InsertData(
                schema: "System",
                table: "Role",
                columns: new[] { "RoleId", "IsEnabled", "Name" },
                values: new object[] { 1, true, "Administrator" });

            migrationBuilder.InsertData(
                schema: "System",
                table: "Role",
                columns: new[] { "RoleId", "IsEnabled", "Name" },
                values: new object[] { 2, true, "HumanResources" });

            migrationBuilder.InsertData(
                schema: "GroupBuying",
                table: "Store",
                columns: new[] { "StoreId", "Address", "CreatedBy", "CreatedOn", "Description", "Name", "Phone", "Remark" },
                values: new object[] { 1, "台北市內湖區江南街117號", 1, new DateTime(2018, 5, 4, 14, 30, 48, 392, DateTimeKind.Local), "測試der", "韓膳宮", "2658-2882", null });

            migrationBuilder.InsertData(
                schema: "System",
                table: "User",
                columns: new[] { "UserId", "BusinessEntityId", "IsEnabled", "PasswordHash", "UserName" },
                values: new object[] { 1, 1, true, "rlS0uO5WqqdUOtJbKHz87yQ/ZumG1eRhjol3zl/oJeU=", "Admin" });

            migrationBuilder.InsertData(
                schema: "GroupBuying",
                table: "ProductCategory",
                columns: new[] { "ProductCategoryId", "Name", "StoreId" },
                values: new object[,]
                {
                    { 1, "飯類", 1 },
                    { 2, "鍋類", 1 },
                    { 3, "特色餐點", 1 }
                });

            migrationBuilder.InsertData(
                schema: "System",
                table: "UserRole",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 }
                });

            migrationBuilder.InsertData(
                schema: "GroupBuying",
                table: "Product",
                columns: new[] { "ProductId", "Description", "Name", "ProductCategoryId" },
                values: new object[,]
                {
                    { 1, null, "韓式牛肉烤肉飯", 1 },
                    { 2, null, "韓式豬肉烤肉飯", 1 },
                    { 3, null, "韓式牛肉拌飯", 1 },
                    { 4, null, "韓式豬肉拌飯", 1 },
                    { 5, null, "韓式辣雞拌飯", 1 },
                    { 6, null, "香腸泡菜炒飯", 1 },
                    { 7, null, "鮪魚泡菜炒飯", 1 },
                    { 8, null, "海鮮豆腐鍋", 2 },
                    { 9, null, "海鮮泡菜鍋", 2 },
                    { 10, null, "大醬湯飯鍋", 2 },
                    { 11, null, "豆腐辣湯鍋", 2 },
                    { 12, null, "部隊鍋", 2 },
                    { 13, null, "辣炒泡麵", 3 },
                    { 14, null, "海鮮炒麵", 3 },
                    { 15, null, "辣炒年糕", 3 },
                    { 16, null, "海鮮煎餅", 3 }
                });

            migrationBuilder.InsertData(
                schema: "GroupBuying",
                table: "ProductItem",
                columns: new[] { "ProductItemId", "Name", "Price", "ProductId" },
                values: new object[,]
                {
                    { 1, null, 90m, 1 },
                    { 2, null, 90m, 1 },
                    { 3, null, 90m, 1 },
                    { 4, null, 90m, 1 },
                    { 5, null, 90m, 1 },
                    { 6, null, 130m, 1 },
                    { 7, null, 130m, 1 },
                    { 8, null, 130m, 1 },
                    { 9, null, 130m, 1 },
                    { 10, null, 130m, 1 },
                    { 11, null, 130m, 1 },
                    { 12, null, 150m, 1 },
                    { 13, null, 100m, 1 },
                    { 14, null, 140m, 1 },
                    { 15, null, 130m, 1 },
                    { 16, null, 150m, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Group_CreatedBy",
                schema: "GroupBuying",
                table: "Group",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_GroupStore_StoreId",
                schema: "GroupBuying",
                table: "GroupStore",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductCategoryId",
                schema: "GroupBuying",
                table: "Product",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAccessory_ProductId",
                schema: "GroupBuying",
                table: "ProductAccessory",
                column: "ProductId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Store_CreatedBy",
                schema: "GroupBuying",
                table: "Store",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_ParentId",
                schema: "System",
                table: "Menu",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleMenu_MenuId",
                schema: "System",
                table: "RoleMenu",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_User_BusinessEntityId",
                schema: "System",
                table: "User",
                column: "BusinessEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                schema: "System",
                table: "UserRole",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupStore",
                schema: "GroupBuying");

            migrationBuilder.DropTable(
                name: "ProductAccessory",
                schema: "GroupBuying");

            migrationBuilder.DropTable(
                name: "ProductItem",
                schema: "GroupBuying");

            migrationBuilder.DropTable(
                name: "ProductOption",
                schema: "GroupBuying");

            migrationBuilder.DropTable(
                name: "RoleMenu",
                schema: "System");

            migrationBuilder.DropTable(
                name: "UserRole",
                schema: "System");

            migrationBuilder.DropTable(
                name: "Group",
                schema: "GroupBuying");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "GroupBuying");

            migrationBuilder.DropTable(
                name: "Menu",
                schema: "System");

            migrationBuilder.DropTable(
                name: "Role",
                schema: "System");

            migrationBuilder.DropTable(
                name: "User",
                schema: "System");

            migrationBuilder.DropTable(
                name: "ProductCategory",
                schema: "GroupBuying");

            migrationBuilder.DropTable(
                name: "Store",
                schema: "GroupBuying");

            migrationBuilder.DropTable(
                name: "BusinessEntity",
                schema: "Generic");
        }
    }
}
