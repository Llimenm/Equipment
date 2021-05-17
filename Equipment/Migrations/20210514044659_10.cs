using Microsoft.EntityFrameworkCore.Migrations;

namespace Equipment.Migrations
{
    public partial class _10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_Komplekt_Type_equipment_Type_eq_id",
                table: "Komplekt",
                column: "Type_eq_id",
                principalTable: "Type_equipment",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Komplekt_Type_equipment_Type_eq_id",
                table: "Komplekt");

            migrationBuilder.DropIndex(
                name: "IX_Komplekt_Type_eq_id",
                table: "Komplekt");

            migrationBuilder.DropColumn(
                name: "Type_eq_id",
                table: "Komplekt");
        }
    }
}
