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
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
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
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Area = table.Column<string>(maxLength: 50, nullable: true),
                    Controller = table.Column<string>(maxLength: 50, nullable: true),
                    Action = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 100, nullable: true),
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
                name: "User",
                schema: "System",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(maxLength: 32, nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    IsEnabled = table.Column<bool>(nullable: false),
                    BusinessEntityId = table.Column<int>(nullable: true)
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
                        onDelete: ReferentialAction.Restrict);
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
                        name: "FK_Group_User_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "System",
                        principalTable: "User",
                        principalColumn: "UserId",
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
                        name: "FK_Store_User_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "System",
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
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
                name: "Product",
                schema: "GroupBuying",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 32, nullable: false),
                    Price = table.Column<decimal>(nullable: false),
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
                name: "IX_ProductCategory_StoreId",
                schema: "GroupBuying",
                table: "ProductCategory",
                column: "StoreId");

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
                name: "Product",
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
                name: "ProductCategory",
                schema: "GroupBuying");

            migrationBuilder.DropTable(
                name: "Menu",
                schema: "System");

            migrationBuilder.DropTable(
                name: "Role",
                schema: "System");

            migrationBuilder.DropTable(
                name: "Store",
                schema: "GroupBuying");

            migrationBuilder.DropTable(
                name: "User",
                schema: "System");

            migrationBuilder.DropTable(
                name: "BusinessEntity",
                schema: "Generic");
        }
    }
}
