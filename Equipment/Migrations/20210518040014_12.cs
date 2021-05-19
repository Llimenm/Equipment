using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Equipment.Migrations
{
    public partial class _12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Monitor_komplekt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Komplekt_id = table.Column<int>(type: "int", nullable: false),
                    Monitor_id = table.Column<int>(type: "int", nullable: false),
                    Inventory = table.Column<string>(type: "longtext", nullable: true),
                    Ports_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monitor_komplekt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Monitor_komplekt_Komplekt_Komplekt_id",
                        column: x => x.Komplekt_id,
                        principalTable: "Komplekt",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Monitor_komplekt_Monitor_Monitor_id",
                        column: x => x.Monitor_id,
                        principalTable: "Monitor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Monitor_komplekt_Komplekt_id",
                table: "Monitor_komplekt",
                column: "Komplekt_id");

            migrationBuilder.CreateIndex(
                name: "IX_Monitor_komplekt_Monitor_id",
                table: "Monitor_komplekt",
                column: "Monitor_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Monitor_komplekt");
        }
    }
}
