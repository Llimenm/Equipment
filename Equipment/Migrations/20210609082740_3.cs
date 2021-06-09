using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Equipment.Migrations
{
    public partial class _3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Monitor_komplekt");

            migrationBuilder.RenameColumn(
                name: "Count",
                table: "Monitor",
                newName: "Inventory_id");

            migrationBuilder.AddColumn<Guid>(
                name: "Komplekt_guid",
                table: "Monitor",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "Otdelenie_guid",
                table: "Monitor",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "Status_guid",
                table: "Monitor",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "TypeEq_guid",
                table: "Monitor",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Monitor_Inventory_id",
                table: "Monitor",
                column: "Inventory_id");

            migrationBuilder.CreateIndex(
                name: "IX_Monitor_Komplekt_guid",
                table: "Monitor",
                column: "Komplekt_guid");

            migrationBuilder.CreateIndex(
                name: "IX_Monitor_Status_guid",
                table: "Monitor",
                column: "Status_guid");

            migrationBuilder.CreateIndex(
                name: "IX_Monitor_TypeEq_guid",
                table: "Monitor",
                column: "TypeEq_guid");

            migrationBuilder.AddForeignKey(
                name: "FK_Monitor_Inventory_Inventory_id",
                table: "Monitor",
                column: "Inventory_id",
                principalTable: "Inventory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Monitor_Komplekt_Komplekt_guid",
                table: "Monitor",
                column: "Komplekt_guid",
                principalTable: "Komplekt",
                principalColumn: "GID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Monitor_Status_Status_guid",
                table: "Monitor",
                column: "Status_guid",
                principalTable: "Status",
                principalColumn: "GID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Monitor_Type_equipment_TypeEq_guid",
                table: "Monitor",
                column: "TypeEq_guid",
                principalTable: "Type_equipment",
                principalColumn: "GID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Monitor_Inventory_Inventory_id",
                table: "Monitor");

            migrationBuilder.DropForeignKey(
                name: "FK_Monitor_Komplekt_Komplekt_guid",
                table: "Monitor");

            migrationBuilder.DropForeignKey(
                name: "FK_Monitor_Status_Status_guid",
                table: "Monitor");

            migrationBuilder.DropForeignKey(
                name: "FK_Monitor_Type_equipment_TypeEq_guid",
                table: "Monitor");

            migrationBuilder.DropIndex(
                name: "IX_Monitor_Inventory_id",
                table: "Monitor");

            migrationBuilder.DropIndex(
                name: "IX_Monitor_Komplekt_guid",
                table: "Monitor");

            migrationBuilder.DropIndex(
                name: "IX_Monitor_Status_guid",
                table: "Monitor");

            migrationBuilder.DropIndex(
                name: "IX_Monitor_TypeEq_guid",
                table: "Monitor");

            migrationBuilder.DropColumn(
                name: "Komplekt_guid",
                table: "Monitor");

            migrationBuilder.DropColumn(
                name: "Otdelenie_guid",
                table: "Monitor");

            migrationBuilder.DropColumn(
                name: "Status_guid",
                table: "Monitor");

            migrationBuilder.DropColumn(
                name: "TypeEq_guid",
                table: "Monitor");

            migrationBuilder.RenameColumn(
                name: "Inventory_id",
                table: "Monitor",
                newName: "Count");

            migrationBuilder.CreateTable(
                name: "Monitor_komplekt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Inventory_id = table.Column<int>(type: "int", nullable: false),
                    Komplekt_guid = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Monitor_guid = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Otdelenie_guid = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Ports_id = table.Column<int>(type: "int", nullable: false),
                    Status_guid = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monitor_komplekt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Monitor_komplekt_Komplekt_Komplekt_guid",
                        column: x => x.Komplekt_guid,
                        principalTable: "Komplekt",
                        principalColumn: "GID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Monitor_komplekt_Monitor_Monitor_guid",
                        column: x => x.Monitor_guid,
                        principalTable: "Monitor",
                        principalColumn: "GID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Monitor_komplekt_Status_Status_guid",
                        column: x => x.Status_guid,
                        principalTable: "Status",
                        principalColumn: "GID",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Monitor_komplekt_Komplekt_guid",
                table: "Monitor_komplekt",
                column: "Komplekt_guid");

            migrationBuilder.CreateIndex(
                name: "IX_Monitor_komplekt_Monitor_guid",
                table: "Monitor_komplekt",
                column: "Monitor_guid");

            migrationBuilder.CreateIndex(
                name: "IX_Monitor_komplekt_Status_guid",
                table: "Monitor_komplekt",
                column: "Status_guid");
        }
    }
}
