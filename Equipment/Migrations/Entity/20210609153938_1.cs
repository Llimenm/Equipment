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
                name: "Addresses",
                columns: table => new
                {
                    GID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Gorod = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ulica = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Dom = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PostIndex = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.GID);
                })
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
                name: "Mesto",
                columns: table => new
                {
                    GID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    NameMesto = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Open = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    OtdelenieGID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Etag = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Blok = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Kabinet = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mesto", x => x.GID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "NewsPosts",
                columns: table => new
                {
                    GID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Img = table.Column<byte[]>(type: "longblob", nullable: true),
                    Title = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ShortText = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MainText = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HaveMainText = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    File = table.Column<byte[]>(type: "longblob", nullable: true),
                    FileName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Data = table.Column<DateTime>(type: "date", nullable: false),
                    CanPost = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsPosts", x => x.GID);
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
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    mestoGID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
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
                name: "RequestCategories",
                columns: table => new
                {
                    GID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    NameCategory = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Index = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Enable = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestCategories", x => x.GID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    GID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    curIniciativeType = table.Column<int>(type: "int", nullable: false),
                    RequestCategoryGID = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RequestCategoryName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RequestSubCategoryGID = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RequestSubCategoryName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ModuleName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ServisUserGID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    OtdelenieGID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ContactNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    curStatus = table.Column<int>(type: "int", nullable: false),
                    StatusComent = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ChangeStatusTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    AddTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    InfoZayavka = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    file = table.Column<byte[]>(type: "longblob", nullable: true),
                    file_name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.GID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RequestSubCategories",
                columns: table => new
                {
                    GID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CategoryGID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    NameSubCategory = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SubIndex = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ModuleName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Enable = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestSubCategories", x => x.GID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StafPosts",
                columns: table => new
                {
                    GID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    NamePost = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StafPosts", x => x.GID);
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
                    MestoGID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
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
                    PodrazdelenieGID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    mestoGID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
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
                name: "Otdelenie",
                columns: table => new
                {
                    GID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Number = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsOpen = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    KorpusGID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Otdelenie", x => x.GID);
                    table.ForeignKey(
                        name: "FK_Otdelenie_Korpus_KorpusGID",
                        column: x => x.KorpusGID,
                        principalTable: "Korpus",
                        principalColumn: "GID",
                        onDelete: ReferentialAction.SetNull);
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
                    table.ForeignKey(
                        name: "FK_InventoryNumbers_Otdelenie_OtdelenieGID",
                        column: x => x.OtdelenieGID,
                        principalTable: "Otdelenie",
                        principalColumn: "GID",
                        onDelete: ReferentialAction.SetNull);
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
                    UserGID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    UserWebGID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    OtdelenieGID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PostStafGID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
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
                    InventoryDataId = table.Column<int>(type: "int", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_Printers_InventoryNumbers_InventoryDataId",
                        column: x => x.InventoryDataId,
                        principalTable: "InventoryNumbers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    table.ForeignKey(
                        name: "FK_Users_Sotrudniks_SotridnikGID",
                        column: x => x.SotridnikGID,
                        principalTable: "Sotrudniks",
                        principalColumn: "GID",
                        onDelete: ReferentialAction.Cascade);
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
                columns: new[] { "GID", "IsOpen", "KorpusGID", "Name", "Number" },
                values: new object[] { new Guid("a92f0cb6-bbc2-4001-9894-c7c7099580c7"), false, null, "Отделение", "01" });

            migrationBuilder.InsertData(
                table: "Printer_Statuses",
                columns: new[] { "StatusCode", "Name" },
                values: new object[,]
                {
                    { 9, "Списан" },
                    { 8, "Обслуживание в АСУ" },
                    { 6, "Подготовлен к ремонту" },
                    { 7, "После ремонта" },
                    { 4, "В эксплуатации" },
                    { 3, "В ремонте" },
                    { 2, "На складе" },
                    { 1, "Нет" },
                    { 5, "На замене" }
                });

            migrationBuilder.InsertData(
                table: "VersionControlls",
                columns: new[] { "Id", "ApplicationName", "CurVersion", "Enable", "Index" },
                values: new object[,]
                {
                    { 8, "OKBPrinters", "21.05.2021", true, "a_printers" },
                    { 1, "OKBAdmin", "21.05.2021", true, "admin" },
                    { 2, "OKBStruktura", "21.05.2021", true, "a_struktura" },
                    { 3, "OKBStaf", "21.05.2021", true, "a_staf" },
                    { 4, "OKBUserEditor", "21.05.2021", true, "a_usereditor" },
                    { 5, "OKBATS", "21.05.2021", true, "a_ats" },
                    { 6, "OKBNews", "21.05.2021", true, "a_news" },
                    { 7, "OKBRequestServis", "21.05.2021", true, "a_request" },
                    { 9, "OKB_Web_News", "21.05.2021", true, "w_news" }
                });

            migrationBuilder.InsertData(
                table: "Sotrudniks",
                columns: new[] { "GID", "MainTabelNumber", "Name", "OtdelenieGID", "Patron", "PostStafGID", "Snils", "Sur", "UserGID", "UserWebGID" },
                values: new object[] { new Guid("a3b5899d-36b3-4f2d-aa96-dd3174a6a6a4"), "01", "G", new Guid("a92f0cb6-bbc2-4001-9894-c7c7099580c7"), "R", null, "1234567890", "E", new Guid("add4a22a-aaa1-4d36-90ed-77102df1e5b8"), null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "GID", "Login", "Pass", "SotridnikGID" },
                values: new object[] { new Guid("add4a22a-aaa1-4d36-90ed-77102df1e5b8"), "sa", new byte[] { 49 }, new Guid("a3b5899d-36b3-4f2d-aa96-dd3174a6a6a4") });

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
                name: "IX_NewsPosts_GID",
                table: "NewsPosts",
                column: "GID",
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
                name: "IX_Printers_InventoryDataId",
                table: "Printers",
                column: "InventoryDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Printers_ModelGuid",
                table: "Printers",
                column: "ModelGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Printers_StatusCode",
                table: "Printers",
                column: "StatusCode");

            migrationBuilder.CreateIndex(
                name: "IX_RequestCategories_GID",
                table: "RequestCategories",
                column: "GID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RequestCategories_Index",
                table: "RequestCategories",
                column: "Index",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RequestCategories_NameCategory",
                table: "RequestCategories",
                column: "NameCategory",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Requests_GID",
                table: "Requests",
                column: "GID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RequestSubCategories_GID",
                table: "RequestSubCategories",
                column: "GID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RequestSubCategories_NameSubCategory",
                table: "RequestSubCategories",
                column: "NameSubCategory",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RequestSubCategories_SubIndex",
                table: "RequestSubCategories",
                column: "SubIndex",
                unique: true);

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
                name: "IX_StafPosts_NamePost",
                table: "StafPosts",
                column: "NamePost",
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
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Cartridge_StatusLogs");

            migrationBuilder.DropTable(
                name: "DostupData");

            migrationBuilder.DropTable(
                name: "ER_Raport_Shablons");

            migrationBuilder.DropTable(
                name: "ER_Raports");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "Mesto");

            migrationBuilder.DropTable(
                name: "NewsPosts");

            migrationBuilder.DropTable(
                name: "Printer_StatusLogs");

            migrationBuilder.DropTable(
                name: "RequestCategories");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "RequestSubCategories");

            migrationBuilder.DropTable(
                name: "StafPosts");

            migrationBuilder.DropTable(
                name: "TelefonDop");

            migrationBuilder.DropTable(
                name: "TelefonMain");

            migrationBuilder.DropTable(
                name: "Telefons");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "VersionControlls");

            migrationBuilder.DropTable(
                name: "Cartridges");

            migrationBuilder.DropTable(
                name: "Printers");

            migrationBuilder.DropTable(
                name: "Sotrudniks");

            migrationBuilder.DropTable(
                name: "Cartridge_Models");

            migrationBuilder.DropTable(
                name: "Cartridge_Statuses");

            migrationBuilder.DropTable(
                name: "InventoryNumbers");

            migrationBuilder.DropTable(
                name: "Printer_Models");

            migrationBuilder.DropTable(
                name: "Printer_Statuses");

            migrationBuilder.DropTable(
                name: "Otdelenie");

            migrationBuilder.DropTable(
                name: "Manufacturers");

            migrationBuilder.DropTable(
                name: "Korpus");

            migrationBuilder.DropTable(
                name: "Podrazdelenies");
        }
    }
}
