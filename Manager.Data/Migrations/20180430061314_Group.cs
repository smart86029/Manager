using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Manager.Data.Migrations
{
    public partial class Group : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Store_User_CreatedBy",
                schema: "GroupBuying",
                table: "Store");

            migrationBuilder.CreateTable(
                name: "Group",
                schema: "GroupBuying",
                columns: table => new
                {
                    GroupId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    Remark = table.Column<string>(maxLength: 512, nullable: true),
                    StartTime = table.Column<DateTime>(nullable: false)
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

            migrationBuilder.AddForeignKey(
                name: "FK_Store_User_CreatedBy",
                schema: "GroupBuying",
                table: "Store",
                column: "CreatedBy",
                principalSchema: "System",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Store_User_CreatedBy",
                schema: "GroupBuying",
                table: "Store");

            migrationBuilder.DropTable(
                name: "GroupStore",
                schema: "GroupBuying");

            migrationBuilder.DropTable(
                name: "Group",
                schema: "GroupBuying");

            migrationBuilder.AddForeignKey(
                name: "FK_Store_User_CreatedBy",
                schema: "GroupBuying",
                table: "Store",
                column: "CreatedBy",
                principalSchema: "System",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
