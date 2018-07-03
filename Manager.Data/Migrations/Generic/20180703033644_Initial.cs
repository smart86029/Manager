using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Manager.Data.migrations.generic
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Generic");

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

            migrationBuilder.InsertData(
                schema: "Generic",
                table: "BusinessEntity",
                columns: new[] { "BusinessEntityId", "Discriminator", "BirthDate", "FirstName", "Gender", "LastName" },
                values: new object[] { 1, "Person", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "管理員", 9, "超級" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessEntity",
                schema: "Generic");
        }
    }
}
