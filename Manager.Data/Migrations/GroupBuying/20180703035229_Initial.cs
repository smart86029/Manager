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
                    BaseNumber = table.Column<string>(maxLength: 8, nullable: false),
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Store",
                schema: "GroupBuying");
        }
    }
}
