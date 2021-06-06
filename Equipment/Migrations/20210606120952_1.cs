using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Equipment.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Acc_user = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Comment = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Monitor",
                columns: table => new
                {
                    GID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Manufacturer = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Model = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ports_id = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monitor", x => x.GID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    VGA = table.Column<int>(type: "int", nullable: false),
                    HDMI = table.Column<int>(type: "int", nullable: false),
                    DP = table.Column<int>(type: "int", nullable: false),
                    DVI_D = table.Column<int>(type: "int", nullable: false),
                    DVI_I = table.Column<int>(type: "int", nullable: false),
                    LTP = table.Column<int>(type: "int", nullable: false),
                    COM = table.Column<int>(type: "int", nullable: false),
                    PS2 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ports", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ram_type",
                columns: table => new
                {
                    GID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ram_type", x => x.GID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Socket",
                columns: table => new
                {
                    GID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Socket", x => x.GID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    GID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.GID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Type_equipment",
                columns: table => new
                {
                    GID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Type_name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type_equipment", x => x.GID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Chipset",
                columns: table => new
                {
                    GID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Socket_guid = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chipset", x => x.GID);
                    table.ForeignKey(
                        name: "FK_Chipset_Socket_Socket_guid",
                        column: x => x.Socket_guid,
                        principalTable: "Socket",
                        principalColumn: "GID",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Komplekt",
                columns: table => new
                {
                    GID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Type_eq_guid = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Status_guid = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Inventory = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Otdelenie_gid = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Account_id = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Komplekt", x => x.GID);
                    table.ForeignKey(
                        name: "FK_Komplekt_Account_Account_id",
                        column: x => x.Account_id,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Komplekt_Status_Status_guid",
                        column: x => x.Status_guid,
                        principalTable: "Status",
                        principalColumn: "GID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Komplekt_Type_equipment_Type_eq_guid",
                        column: x => x.Type_eq_guid,
                        principalTable: "Type_equipment",
                        principalColumn: "GID",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Motherboards",
                columns: table => new
                {
                    GID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Manufacturer = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Model = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Type_eq_guid = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Socket_guid = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Socket_count = table.Column<int>(type: "int", nullable: false),
                    Chipset_guid = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Ram_type_guid = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Ram_count = table.Column<int>(type: "int", nullable: false),
                    M2_count = table.Column<int>(type: "int", nullable: false),
                    Ports_id = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    OnKomplekt = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motherboards", x => x.GID);
                    table.ForeignKey(
                        name: "FK_Motherboards_Chipset_Chipset_guid",
                        column: x => x.Chipset_guid,
                        principalTable: "Chipset",
                        principalColumn: "GID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Motherboards_Ram_type_Ram_type_guid",
                        column: x => x.Ram_type_guid,
                        principalTable: "Ram_type",
                        principalColumn: "GID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Motherboards_Socket_Socket_guid",
                        column: x => x.Socket_guid,
                        principalTable: "Socket",
                        principalColumn: "GID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Motherboards_Type_equipment_Type_eq_guid",
                        column: x => x.Type_eq_guid,
                        principalTable: "Type_equipment",
                        principalColumn: "GID",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Monitor_komplekt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Komplekt_guid = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Monitor_guid = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Otdelenie_guid = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Inventory = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ports_id = table.Column<int>(type: "int", nullable: false)
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Motherboards_K",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Komplekt_guid = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Motherboard_guid = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Ports_id = table.Column<int>(type: "int", nullable: false),
                    Inventory = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motherboards_K", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Motherboards_K_Komplekt_Komplekt_guid",
                        column: x => x.Komplekt_guid,
                        principalTable: "Komplekt",
                        principalColumn: "GID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Motherboards_K_Motherboards_Motherboard_guid",
                        column: x => x.Motherboard_guid,
                        principalTable: "Motherboards",
                        principalColumn: "GID",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Chipset_Socket_guid",
                table: "Chipset",
                column: "Socket_guid");

            migrationBuilder.CreateIndex(
                name: "IX_Komplekt_Account_id",
                table: "Komplekt",
                column: "Account_id");

            migrationBuilder.CreateIndex(
                name: "IX_Komplekt_Status_guid",
                table: "Komplekt",
                column: "Status_guid");

            migrationBuilder.CreateIndex(
                name: "IX_Komplekt_Type_eq_guid",
                table: "Komplekt",
                column: "Type_eq_guid");

            migrationBuilder.CreateIndex(
                name: "IX_Monitor_komplekt_Komplekt_guid",
                table: "Monitor_komplekt",
                column: "Komplekt_guid");

            migrationBuilder.CreateIndex(
                name: "IX_Monitor_komplekt_Monitor_guid",
                table: "Monitor_komplekt",
                column: "Monitor_guid");

            migrationBuilder.CreateIndex(
                name: "IX_Motherboards_Chipset_guid",
                table: "Motherboards",
                column: "Chipset_guid");

            migrationBuilder.CreateIndex(
                name: "IX_Motherboards_Ram_type_guid",
                table: "Motherboards",
                column: "Ram_type_guid");

            migrationBuilder.CreateIndex(
                name: "IX_Motherboards_Socket_guid",
                table: "Motherboards",
                column: "Socket_guid");

            migrationBuilder.CreateIndex(
                name: "IX_Motherboards_Type_eq_guid",
                table: "Motherboards",
                column: "Type_eq_guid");

            migrationBuilder.CreateIndex(
                name: "IX_Motherboards_K_Komplekt_guid",
                table: "Motherboards_K",
                column: "Komplekt_guid");

            migrationBuilder.CreateIndex(
                name: "IX_Motherboards_K_Motherboard_guid",
                table: "Motherboards_K",
                column: "Motherboard_guid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Monitor_komplekt");

            migrationBuilder.DropTable(
                name: "Motherboards_K");

            migrationBuilder.DropTable(
                name: "Ports");

            migrationBuilder.DropTable(
                name: "Monitor");

            migrationBuilder.DropTable(
                name: "Komplekt");

            migrationBuilder.DropTable(
                name: "Motherboards");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Chipset");

            migrationBuilder.DropTable(
                name: "Ram_type");

            migrationBuilder.DropTable(
                name: "Type_equipment");

            migrationBuilder.DropTable(
                name: "Socket");
        }
    }
}
