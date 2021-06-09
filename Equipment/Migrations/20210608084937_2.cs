using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Equipment.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Inventory",
                table: "Monitor_komplekt");

            migrationBuilder.DropColumn(
                name: "Inventory",
                table: "Komplekt");

            migrationBuilder.RenameColumn(
                name: "Inventory",
                table: "Motherboards_K",
                newName: "SerialNumber");

            migrationBuilder.AddColumn<int>(
                name: "Inventory_id",
                table: "Monitor_komplekt",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "Status_guid",
                table: "Monitor_komplekt",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<int>(
                name: "Inventory_id",
                table: "Komplekt",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Inventory = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Otdelenie_guid = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Monitor_komplekt_Status_guid",
                table: "Monitor_komplekt",
                column: "Status_guid");

            migrationBuilder.CreateIndex(
                name: "IX_Komplekt_Inventory_id",
                table: "Komplekt",
                column: "Inventory_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Komplekt_Inventory_Inventory_id",
                table: "Komplekt",
                column: "Inventory_id",
                principalTable: "Inventory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Monitor_komplekt_Status_Status_guid",
                table: "Monitor_komplekt",
                column: "Status_guid",
                principalTable: "Status",
                principalColumn: "GID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Komplekt_Inventory_Inventory_id",
                table: "Komplekt");

            migrationBuilder.DropForeignKey(
                name: "FK_Monitor_komplekt_Status_Status_guid",
                table: "Monitor_komplekt");

            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropIndex(
                name: "IX_Monitor_komplekt_Status_guid",
                table: "Monitor_komplekt");

            migrationBuilder.DropIndex(
                name: "IX_Komplekt_Inventory_id",
                table: "Komplekt");

            migrationBuilder.DropColumn(
                name: "Inventory_id",
                table: "Monitor_komplekt");

            migrationBuilder.DropColumn(
                name: "Status_guid",
                table: "Monitor_komplekt");

            migrationBuilder.DropColumn(
                name: "Inventory_id",
                table: "Komplekt");

            migrationBuilder.RenameColumn(
                name: "SerialNumber",
                table: "Motherboards_K",
                newName: "Inventory");

            migrationBuilder.AddColumn<string>(
                name: "Inventory",
                table: "Monitor_komplekt",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Inventory",
                table: "Komplekt",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
