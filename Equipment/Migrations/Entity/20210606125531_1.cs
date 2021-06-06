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
                name: "Cartridge_Statuses",
                columns: table => new
                {
                    StatusCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(95)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cartridge_Statuses", x => x.StatusCode);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DostupData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserGID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Dostup = table.Column<byte[]>(type: "longblob", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DostupData", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ER_Raport_Shablons",
                columns: table => new
                {
                    GID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    NameShablon = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    InWork = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    MainText = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    JsonNavigation = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Data = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ER_Raport_Shablons", x => x.GID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ER_Raports",
                columns: table => new
                {
                    GID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    File = table.Column<byte[]>(type: "longblob", nullable: true),
                    FileName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FileExtention = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ErRaportId_base = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ServiceUserGID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    SotrudnikGID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    OtdelenieGID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PositionNumber = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    PositionGIDOtdelenie = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    JsonNavigation = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IspolnitelSotrudnikGID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    JsonComentList = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ERRaportShablon = table.Column<int>(type: "int", nullable: false),
                    MainText = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SubText = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    JsonTextTable = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EndText = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddData = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateData = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ER_Raports", x => x.GID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Changes = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ChangeDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ItemId = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LogCategoryEnum = table.Column<int>(type: "int", nullable: false),
                    LogTypeEnum = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DeleteMark = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.Guid);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Podrazdelenies",
                columns: table => new
                {
                    GID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    MainName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Psevdonim = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Podrazdelenies", x => x.GID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Printer_Statuses",
                columns: table => new
                {
                    StatusCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Printer_Statuses", x => x.StatusCode);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TelefonDop",
                columns: table => new
                {
                    GID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TNumber_d = table.Column<int>(type: "int", nullable: false),
                    ContactGID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelefonDop", x => x.GID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TelefonMain",
                columns: table => new
                {
                    GID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TNumber_m = table.Column<int>(type: "int", nullable: false),
                    SubNumber_m = table.Column<int>(type: "int", nullable: false),
                    ContactGID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelefonMain", x => x.GID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Telefons",
                columns: table => new
                {
                    GID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    OtdelenieGID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ContactGID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    TelefonMainGID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    TelefonDopGID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Etag = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Blok = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Kabinet = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TelefonLineNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Magistral = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Kabel = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Raspredelenie = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OborudovanieName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MacAdress = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ServerAddress = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefons", x => x.GID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    GID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    SotridnikGID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Login = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Pass = table.Column<byte[]>(type: "longblob", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.GID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "VersionControlls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ApplicationName = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CurVersion = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Enable = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Index = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VersionControlls", x => x.Id);
                    table.UniqueConstraint("AK_VersionControlls_ApplicationName", x => x.ApplicationName);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cartridge_Models",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(95)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Group = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ManufacturerGuid = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    DeleteMark = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cartridge_Models", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Cartridge_Models_Manufacturers_ManufacturerGuid",
                        column: x => x.ManufacturerGuid,
                        principalTable: "Manufacturers",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Printer_Models",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ManufacturerGuid = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    DeleteMark = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Printer_Models", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Printer_Models_Manufacturers_ManufacturerGuid",
                        column: x => x.ManufacturerGuid,
                        principalTable: "Manufacturers",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Korpus",
                columns: table => new
                {
                    GID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PodrazdelenieGID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korpus", x => x.GID);
                    table.ForeignKey(
                        name: "FK_Korpus_Podrazdelenies_PodrazdelenieGID",
                        column: x => x.PodrazdelenieGID,
                        principalTable: "Podrazdelenies",
                        principalColumn: "GID",
                        onDelete: ReferentialAction.SetNull);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Printers",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    AsuId = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ModelGuid = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    InventoryNumber = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsNetwork = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    MAC = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HardwareName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StatusCode = table.Column<int>(type: "int", nullable: false),
                    DeleteMark = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Printers", x => x.Guid);
                    table.UniqueConstraint("AK_Printers_InventoryNumber", x => x.InventoryNumber);
                    table.ForeignKey(
                        name: "FK_Printers_Printer_Models_ModelGuid",
                        column: x => x.ModelGuid,
                        principalTable: "Printer_Models",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Printers_Printer_Statuses_StatusCode",
                        column: x => x.StatusCode,
                        principalTable: "Printer_Statuses",
                        principalColumn: "StatusCode",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Otdelenie",
                columns: table => new
                {
                    GID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Number = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Etag = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Blok = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Coment = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KorpusGID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Otdelenie", x => x.GID);
                    table.UniqueConstraint("AK_Otdelenie_Number", x => x.Number);
                    table.ForeignKey(
                        name: "FK_Otdelenie_Korpus_KorpusGID",
                        column: x => x.KorpusGID,
                        principalTable: "Korpus",
                        principalColumn: "GID",
                        onDelete: ReferentialAction.SetNull);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Printer_StatusLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PrinterGuid = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    OldStatusCode = table.Column<int>(type: "int", nullable: false),
                    NewStatusCode = table.Column<int>(type: "int", nullable: false),
                    Commentary = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateTime = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Printer_StatusLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Printer_StatusLogs_Printer_Statuses_NewStatusCode",
                        column: x => x.NewStatusCode,
                        principalTable: "Printer_Statuses",
                        principalColumn: "StatusCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Printer_StatusLogs_Printer_Statuses_OldStatusCode",
                        column: x => x.OldStatusCode,
                        principalTable: "Printer_Statuses",
                        principalColumn: "StatusCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Printer_StatusLogs_Printers_PrinterGuid",
                        column: x => x.PrinterGuid,
                        principalTable: "Printers",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cartridges",
                columns: table => new
                {
                    GuId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    AsuId = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ModelGuid = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    OtdelGID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    StatusCode = table.Column<int>(type: "int", nullable: false),
                    DeleteMark = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cartridges", x => x.GuId);
                    table.UniqueConstraint("AK_Cartridges_AsuId", x => x.AsuId);
                    table.ForeignKey(
                        name: "FK_Cartridges_Cartridge_Models_ModelGuid",
                        column: x => x.ModelGuid,
                        principalTable: "Cartridge_Models",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cartridges_Cartridge_Statuses_StatusCode",
                        column: x => x.StatusCode,
                        principalTable: "Cartridge_Statuses",
                        principalColumn: "StatusCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cartridges_Otdelenie_OtdelGID",
                        column: x => x.OtdelGID,
                        principalTable: "Otdelenie",
                        principalColumn: "GID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "InventoryNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Inventory = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OtdelenieGID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryNumbers", x => x.Id);
                    table.UniqueConstraint("AK_InventoryNumbers_Inventory", x => x.Inventory);
                    table.ForeignKey(
                        name: "FK_InventoryNumbers_Otdelenie_OtdelenieGID",
                        column: x => x.OtdelenieGID,
                        principalTable: "Otdelenie",
                        principalColumn: "GID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_InventoryNumbers_Printers_Inventory",
                        column: x => x.Inventory,
                        principalTable: "Printers",
                        principalColumn: "InventoryNumber",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Sotrudniks",
                columns: table => new
                {
                    GID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Sur = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Patron = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Snils = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MainTabelNumber = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContactPersonPostGID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    UserGID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    OtdelenieGID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sotrudniks", x => x.GID);
                    table.ForeignKey(
                        name: "FK_Sotrudniks_Otdelenie_OtdelenieGID",
                        column: x => x.OtdelenieGID,
                        principalTable: "Otdelenie",
                        principalColumn: "GID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sotrudniks_Users_UserGID",
                        column: x => x.UserGID,
                        principalTable: "Users",
                        principalColumn: "GID",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cartridge_StatusLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CartridgeGuid = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    NewStatusCode = table.Column<int>(type: "int", nullable: false),
                    OldStatusCode = table.Column<int>(type: "int", nullable: false),
                    OldOtdelenieGuid = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    NewOtdelenieGuid = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Commentary = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cartridge_StatusLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cartridge_StatusLogs_Cartridge_Statuses_NewStatusCode",
                        column: x => x.NewStatusCode,
                        principalTable: "Cartridge_Statuses",
                        principalColumn: "StatusCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cartridge_StatusLogs_Cartridge_Statuses_OldStatusCode",
                        column: x => x.OldStatusCode,
                        principalTable: "Cartridge_Statuses",
                        principalColumn: "StatusCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cartridge_StatusLogs_Cartridges_CartridgeGuid",
                        column: x => x.CartridgeGuid,
                        principalTable: "Cartridges",
                        principalColumn: "GuId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cartridge_StatusLogs_Otdelenie_NewOtdelenieGuid",
                        column: x => x.NewOtdelenieGuid,
                        principalTable: "Otdelenie",
                        principalColumn: "GID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cartridge_StatusLogs_Otdelenie_OldOtdelenieGuid",
                        column: x => x.OldOtdelenieGuid,
                        principalTable: "Otdelenie",
                        principalColumn: "GID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Cartridge_Statuses",
                columns: new[] { "StatusCode", "Name" },
                values: new object[,]
                {
                    { 1, "Нет" },
                    { 2, "Готов к отправке" },
                    { 3, "Готов к заправке" },
                    { 4, "Заправка" },
                    { 5, "На складе" },
                    { 6, "В эксплуатации" },
                    { 7, "Списан" }
                });

            migrationBuilder.InsertData(
                table: "DostupData",
                columns: new[] { "Id", "Dostup", "UserGID" },
                values: new object[] { 1, new byte[] { 97, 100, 109, 105, 110, 58, 97, 95, 115, 116, 114, 117, 107, 116, 117, 114, 97, 58, 97, 95, 115, 116, 97, 102, 58, 97, 95, 117, 115, 101, 114, 101, 100, 105, 116, 111, 114, 58, 97, 95, 97, 116, 115, 58, 97, 95, 110, 101, 119, 115, 58, 97, 95, 114, 101, 113, 117, 101, 115, 116 }, new Guid("add4a22a-aaa1-4d36-90ed-77102df1e5b8") });

            migrationBuilder.InsertData(
                table: "Otdelenie",
                columns: new[] { "GID", "Blok", "Coment", "Etag", "KorpusGID", "Name", "Number" },
                values: new object[] { new Guid("a92f0cb6-bbc2-4001-9894-c7c7099580c7"), null, null, null, null, "Отделение", "01" });

            migrationBuilder.InsertData(
                table: "Printer_Statuses",
                columns: new[] { "StatusCode", "Name" },
                values: new object[,]
                {
                    { 9, "Списан" },
                    { 8, "Обслуживание в АСУ" },
                    { 7, "После ремонта" },
                    { 6, "Подготовлен к ремонту" },
                    { 5, "На замене" },
                    { 4, "В эксплуатации" },
                    { 3, "В ремонте" },
                    { 2, "На складе" },
                    { 1, "Нет" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "GID", "Login", "Pass", "SotridnikGID" },
                values: new object[] { new Guid("add4a22a-aaa1-4d36-90ed-77102df1e5b8"), "sa", new byte[] { 49 }, new Guid("a3b5899d-36b3-4f2d-aa96-dd3174a6a6a4") });

            migrationBuilder.InsertData(
                table: "VersionControlls",
                columns: new[] { "Id", "ApplicationName", "CurVersion", "Enable", "Index" },
                values: new object[,]
                {
                    { 1, "OKBAdmin", "21.05.2021", true, "admin" },
                    { 2, "OKBStruktura", "21.05.2021", true, "a_struktura" },
                    { 3, "OKBStaf", "21.05.2021", true, "a_staf" },
                    { 4, "OKBUserEditor", "21.05.2021", true, "a_usereditor" },
                    { 5, "OKBATS", "21.05.2021", true, "a_ats" },
                    { 6, "OKBNews", "21.05.2021", true, "a_news" },
                    { 7, "OKBRequestServis", "21.05.2021", true, "a_request" }
                });

            migrationBuilder.InsertData(
                table: "Sotrudniks",
                columns: new[] { "GID", "ContactPersonPostGID", "MainTabelNumber", "Name", "OtdelenieGID", "Patron", "Snils", "Sur", "UserGID" },
                values: new object[] { new Guid("a3b5899d-36b3-4f2d-aa96-dd3174a6a6a4"), null, "01", "G", new Guid("a92f0cb6-bbc2-4001-9894-c7c7099580c7"), "R", "1234567890", "E", new Guid("add4a22a-aaa1-4d36-90ed-77102df1e5b8") });

            migrationBuilder.CreateIndex(
                name: "IX_Cartridge_Models_ManufacturerGuid",
                table: "Cartridge_Models",
                column: "ManufacturerGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Cartridge_Models_Name",
                table: "Cartridge_Models",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cartridge_Statuses_StatusCode_Name",
                table: "Cartridge_Statuses",
                columns: new[] { "StatusCode", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cartridge_StatusLogs_CartridgeGuid",
                table: "Cartridge_StatusLogs",
                column: "CartridgeGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Cartridge_StatusLogs_NewOtdelenieGuid",
                table: "Cartridge_StatusLogs",
                column: "NewOtdelenieGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Cartridge_StatusLogs_NewStatusCode",
                table: "Cartridge_StatusLogs",
                column: "NewStatusCode");

            migrationBuilder.CreateIndex(
                name: "IX_Cartridge_StatusLogs_OldOtdelenieGuid",
                table: "Cartridge_StatusLogs",
                column: "OldOtdelenieGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Cartridge_StatusLogs_OldStatusCode",
                table: "Cartridge_StatusLogs",
                column: "OldStatusCode");

            migrationBuilder.CreateIndex(
                name: "IX_Cartridges_AsuId",
                table: "Cartridges",
                column: "AsuId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cartridges_ModelGuid",
                table: "Cartridges",
                column: "ModelGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Cartridges_OtdelGID",
                table: "Cartridges",
                column: "OtdelGID");

            migrationBuilder.CreateIndex(
                name: "IX_Cartridges_StatusCode",
                table: "Cartridges",
                column: "StatusCode");

            migrationBuilder.CreateIndex(
                name: "IX_DostupData_UserGID",
                table: "DostupData",
                column: "UserGID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ER_Raport_Shablons_GID",
                table: "ER_Raport_Shablons",
                column: "GID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ER_Raports_GID",
                table: "ER_Raports",
                column: "GID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InventoryNumbers_Id",
                table: "InventoryNumbers",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InventoryNumbers_Inventory",
                table: "InventoryNumbers",
                column: "Inventory",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InventoryNumbers_OtdelenieGID",
                table: "InventoryNumbers",
                column: "OtdelenieGID");

            migrationBuilder.CreateIndex(
                name: "IX_Korpus_GID",
                table: "Korpus",
                column: "GID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Korpus_Name",
                table: "Korpus",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Korpus_PodrazdelenieGID",
                table: "Korpus",
                column: "PodrazdelenieGID");

            migrationBuilder.CreateIndex(
                name: "IX_Manufacturers_Name",
                table: "Manufacturers",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Otdelenie_GID",
                table: "Otdelenie",
                column: "GID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Otdelenie_KorpusGID",
                table: "Otdelenie",
                column: "KorpusGID");

            migrationBuilder.CreateIndex(
                name: "IX_Otdelenie_Number",
                table: "Otdelenie",
                column: "Number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Podrazdelenies_GID",
                table: "Podrazdelenies",
                column: "GID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Podrazdelenies_Psevdonim",
                table: "Podrazdelenies",
                column: "Psevdonim",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Printer_Models_ManufacturerGuid",
                table: "Printer_Models",
                column: "ManufacturerGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Printer_Models_Name",
                table: "Printer_Models",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Printer_Statuses_StatusCode",
                table: "Printer_Statuses",
                column: "StatusCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Printer_StatusLogs_NewStatusCode",
                table: "Printer_StatusLogs",
                column: "NewStatusCode");

            migrationBuilder.CreateIndex(
                name: "IX_Printer_StatusLogs_OldStatusCode",
                table: "Printer_StatusLogs",
                column: "OldStatusCode");

            migrationBuilder.CreateIndex(
                name: "IX_Printer_StatusLogs_PrinterGuid",
                table: "Printer_StatusLogs",
                column: "PrinterGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Printers_AsuId_InventoryNumber",
                table: "Printers",
                columns: new[] { "AsuId", "InventoryNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Printers_ModelGuid",
                table: "Printers",
                column: "ModelGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Printers_StatusCode",
                table: "Printers",
                column: "StatusCode");

            migrationBuilder.CreateIndex(
                name: "IX_Sotrudniks_MainTabelNumber",
                table: "Sotrudniks",
                column: "MainTabelNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sotrudniks_OtdelenieGID",
                table: "Sotrudniks",
                column: "OtdelenieGID");

            migrationBuilder.CreateIndex(
                name: "IX_Sotrudniks_Snils",
                table: "Sotrudniks",
                column: "Snils",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sotrudniks_UserGID",
                table: "Sotrudniks",
                column: "UserGID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TelefonDop_GID",
                table: "TelefonDop",
                column: "GID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TelefonDop_TNumber_d",
                table: "TelefonDop",
                column: "TNumber_d",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TelefonMain_GID",
                table: "TelefonMain",
                column: "GID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TelefonMain_TNumber_m",
                table: "TelefonMain",
                column: "TNumber_m",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Telefons_GID",
                table: "Telefons",
                column: "GID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_GID",
                table: "Users",
                column: "GID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Login",
                table: "Users",
                column: "Login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_SotridnikGID",
                table: "Users",
                column: "SotridnikGID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VersionControlls_ApplicationName",
                table: "VersionControlls",
                column: "ApplicationName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VersionControlls_Index",
                table: "VersionControlls",
                column: "Index",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cartridge_StatusLogs");

            migrationBuilder.DropTable(
                name: "DostupData");

            migrationBuilder.DropTable(
                name: "ER_Raport_Shablons");

            migrationBuilder.DropTable(
                name: "ER_Raports");

            migrationBuilder.DropTable(
                name: "InventoryNumbers");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "Printer_StatusLogs");

            migrationBuilder.DropTable(
                name: "Sotrudniks");

            migrationBuilder.DropTable(
                name: "TelefonDop");

            migrationBuilder.DropTable(
                name: "TelefonMain");

            migrationBuilder.DropTable(
                name: "Telefons");

            migrationBuilder.DropTable(
                name: "VersionControlls");

            migrationBuilder.DropTable(
                name: "Cartridges");

            migrationBuilder.DropTable(
                name: "Printers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Cartridge_Models");

            migrationBuilder.DropTable(
                name: "Cartridge_Statuses");

            migrationBuilder.DropTable(
                name: "Otdelenie");

            migrationBuilder.DropTable(
                name: "Printer_Models");

            migrationBuilder.DropTable(
                name: "Printer_Statuses");

            migrationBuilder.DropTable(
                name: "Korpus");

            migrationBuilder.DropTable(
                name: "Manufacturers");

            migrationBuilder.DropTable(
                name: "Podrazdelenies");
        }
    }
}
