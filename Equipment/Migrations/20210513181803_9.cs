using Microsoft.EntityFrameworkCore.Migrations;

namespace Equipment.Migrations
{
    public partial class _9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MB_K_Num",
                table: "Komplekt");

            migrationBuilder.RenameColumn(
                name: "MB_K_Num",
                table: "Motherboards_K",
                newName: "Komplekt_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Motherboards_K_Komplekt_Id",
                table: "Motherboards_K",
                column: "Komplekt_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Motherboards_K_Komplekt_Komplekt_Id",
                table: "Motherboards_K",
                column: "Komplekt_Id",
                principalTable: "Komplekt",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Motherboards_K_Komplekt_Komplekt_Id",
                table: "Motherboards_K");

            migrationBuilder.DropIndex(
                name: "IX_Motherboards_K_Komplekt_Id",
                table: "Motherboards_K");

            migrationBuilder.RenameColumn(
                name: "Komplekt_Id",
                table: "Motherboards_K",
                newName: "MB_K_Num");

            migrationBuilder.AddColumn<int>(
                name: "MB_K_Num",
                table: "Komplekt",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
