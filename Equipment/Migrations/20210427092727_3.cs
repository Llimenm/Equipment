using Microsoft.EntityFrameworkCore.Migrations;

namespace Equipment.Migrations
{
    public partial class _3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Komplekt_Status_statusId",
                table: "Komplekt");

            migrationBuilder.DropIndex(
                name: "IX_Komplekt_statusId",
                table: "Komplekt");

            migrationBuilder.DropColumn(
                name: "statusId",
                table: "Komplekt");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "statusId",
                table: "Komplekt",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Komplekt_statusId",
                table: "Komplekt",
                column: "statusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Komplekt_Status_statusId",
                table: "Komplekt",
                column: "statusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
