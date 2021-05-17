using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Equipment.Migrations
{
    public partial class _11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Monitor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Manufacturer = table.Column<string>(type: "longtext", nullable: true),
                    Model = table.Column<string>(type: "longtext", nullable: true),
                    Ports_id = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monitor", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Motherboards_K_MB_id",
                table: "Motherboards_K",
                column: "MB_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Motherboards_K_Motherboards_MB_id",
                table: "Motherboards_K",
                column: "MB_id",
                principalTable: "Motherboards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Motherboards_K_Motherboards_MB_id",
                table: "Motherboards_K");

            migrationBuilder.DropTable(
                name: "Monitor");

            migrationBuilder.DropIndex(
                name: "IX_Motherboards_K_MB_id",
                table: "Motherboards_K");
        }
    }
}
