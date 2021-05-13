using Microsoft.EntityFrameworkCore.Migrations;

namespace Equipment.Migrations
{
    public partial class _7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Komplekt_Acc_id",
                table: "Komplekt",
                column: "Acc_id");

            migrationBuilder.CreateIndex(
                name: "IX_Komplekt_Status_id",
                table: "Komplekt",
                column: "Status_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Komplekt_Account_Acc_id",
                table: "Komplekt",
                column: "Acc_id",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Komplekt_Status_Status_id",
                table: "Komplekt",
                column: "Status_id",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Komplekt_Account_Acc_id",
                table: "Komplekt");

            migrationBuilder.DropForeignKey(
                name: "FK_Komplekt_Status_Status_id",
                table: "Komplekt");

            migrationBuilder.DropIndex(
                name: "IX_Komplekt_Acc_id",
                table: "Komplekt");

            migrationBuilder.DropIndex(
                name: "IX_Komplekt_Status_id",
                table: "Komplekt");
        }
    }
}
