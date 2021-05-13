using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Equipment.Migrations.Entity
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Podrazdelenies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true),
                    Psevdonim = table.Column<string>(type: "longtext", nullable: true),
                    Gorod = table.Column<string>(type: "longtext", nullable: true),
                    Ulica = table.Column<string>(type: "longtext", nullable: true),
                    Dom = table.Column<string>(type: "longtext", nullable: true),
                    PostIndex = table.Column<string>(type: "longtext", nullable: true),
                    Coment = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Podrazdelenies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Server_M",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NetName = table.Column<string>(type: "longtext", nullable: true),
                    IpAddress = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Server_M", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Korpus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true),
                    PodrazdelenieId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korpus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Korpus_Podrazdelenies_PodrazdelenieId",
                        column: x => x.PodrazdelenieId,
                        principalTable: "Podrazdelenies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Otdelenie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nuber = table.Column<string>(type: "longtext", nullable: true),
                    Name = table.Column<string>(type: "longtext", nullable: true),
                    Etag = table.Column<string>(type: "longtext", nullable: true),
                    Blok = table.Column<string>(type: "longtext", nullable: true),
                    Coment = table.Column<string>(type: "longtext", nullable: true),
                    KorpusId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Otdelenie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Otdelenie_Korpus_KorpusId",
                        column: x => x.KorpusId,
                        principalTable: "Korpus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Telefon_M",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Place = table.Column<string>(type: "longtext", nullable: true),
                    Etag = table.Column<string>(type: "longtext", nullable: true),
                    Blok = table.Column<string>(type: "longtext", nullable: true),
                    Kabinet = table.Column<string>(type: "longtext", nullable: true),
                    KontaktName = table.Column<string>(type: "longtext", nullable: true),
                    SotrudnikId = table.Column<int>(type: "int", nullable: true),
                    TelefonMain = table.Column<string>(type: "longtext", nullable: true),
                    TelefonLineNumber = table.Column<string>(type: "longtext", nullable: true),
                    TelefonVnut = table.Column<string>(type: "longtext", nullable: true),
                    TelefonDop = table.Column<string>(type: "longtext", nullable: true),
                    Magistral = table.Column<string>(type: "longtext", nullable: true),
                    Kabel = table.Column<string>(type: "longtext", nullable: true),
                    Raspredelenie = table.Column<string>(type: "longtext", nullable: true),
                    OborudovanieName = table.Column<string>(type: "longtext", nullable: true),
                    MacAdress = table.Column<string>(type: "longtext", nullable: true),
                    ServerId = table.Column<int>(type: "int", nullable: true),
                    Coment = table.Column<string>(type: "longtext", nullable: true),
                    OtdelenieId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefon_M", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Telefon_M_Otdelenie_OtdelenieId",
                        column: x => x.OtdelenieId,
                        principalTable: "Otdelenie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Telefon_M_Server_M_ServerId",
                        column: x => x.ServerId,
                        principalTable: "Server_M",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users_M",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SotridnikId = table.Column<int>(type: "int", nullable: false),
                    Login = table.Column<string>(type: "longtext", nullable: false),
                    Pass = table.Column<byte[]>(type: "longblob", nullable: true),
                    Email = table.Column<string>(type: "longtext", nullable: true),
                    Telefon = table.Column<string>(type: "longtext", nullable: true),
                    Dostup = table.Column<byte[]>(type: "longblob", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users_M", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sotrudnik_M",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Sur = table.Column<string>(type: "longtext", nullable: true),
                    Name = table.Column<string>(type: "longtext", nullable: true),
                    Patron = table.Column<string>(type: "longtext", nullable: true),
                    Snils = table.Column<string>(type: "longtext", nullable: false),
                    MainTabelNumber = table.Column<string>(type: "longtext", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sotrudnik_M", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sotrudnik_M_Users_M_UserId",
                        column: x => x.UserId,
                        principalTable: "Users_M",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Korpus_PodrazdelenieId",
                table: "Korpus",
                column: "PodrazdelenieId");

            migrationBuilder.CreateIndex(
                name: "IX_Otdelenie_KorpusId",
                table: "Otdelenie",
                column: "KorpusId");

            migrationBuilder.CreateIndex(
                name: "IX_Sotrudnik_M_UserId",
                table: "Sotrudnik_M",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Telefon_M_OtdelenieId",
                table: "Telefon_M",
                column: "OtdelenieId");

            migrationBuilder.CreateIndex(
                name: "IX_Telefon_M_ServerId",
                table: "Telefon_M",
                column: "ServerId");

            migrationBuilder.CreateIndex(
                name: "IX_Telefon_M_SotrudnikId",
                table: "Telefon_M",
                column: "SotrudnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_M_SotridnikId",
                table: "Users_M",
                column: "SotridnikId");

            migrationBuilder.AddForeignKey(
                name: "FK_Telefon_M_Sotrudnik_M_SotrudnikId",
                table: "Telefon_M",
                column: "SotrudnikId",
                principalTable: "Sotrudnik_M",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_M_Sotrudnik_M_SotridnikId",
                table: "Users_M",
                column: "SotridnikId",
                principalTable: "Sotrudnik_M",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sotrudnik_M_Users_M_UserId",
                table: "Sotrudnik_M");

            migrationBuilder.DropTable(
                name: "Telefon_M");

            migrationBuilder.DropTable(
                name: "Otdelenie");

            migrationBuilder.DropTable(
                name: "Server_M");

            migrationBuilder.DropTable(
                name: "Korpus");

            migrationBuilder.DropTable(
                name: "Podrazdelenies");

            migrationBuilder.DropTable(
                name: "Users_M");

            migrationBuilder.DropTable(
                name: "Sotrudnik_M");
        }
    }
}
