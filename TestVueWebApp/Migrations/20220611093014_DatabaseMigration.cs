using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestVueWebApp.Migrations
{
    public partial class DatabaseMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Disrepair",
                columns: table => new
                {
                    FailureCD = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FailureName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disrepair", x => x.FailureCD);
                });

            migrationBuilder.CreateTable(
                name: "Executor",
                columns: table => new
                {
                    ExecutorCD = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FIO = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Executor", x => x.ExecutorCD);
                });

            migrationBuilder.CreateTable(
                name: "ReceptionPoint",
                columns: table => new
                {
                    ReceptionPointCD = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceptionName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceptionPoint", x => x.ReceptionPointCD);
                });

            migrationBuilder.CreateTable(
                name: "Street",
                columns: table => new
                {
                    StreetCD = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreetName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Street", x => x.StreetCD);
                });

            migrationBuilder.CreateTable(
                name: "Unit",
                columns: table => new
                {
                    UnitCD = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitsName = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unit", x => x.UnitCD);
                });

            migrationBuilder.CreateTable(
                name: "Abonent",
                columns: table => new
                {
                    AccountCD = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: false),
                    FIO = table.Column<string>(type: "varchar(70)", unicode: false, maxLength: 70, nullable: false),
                    StreetCD = table.Column<int>(type: "int", nullable: false),
                    HouseNo = table.Column<short>(type: "smallint", nullable: false),
                    FlatNo = table.Column<short>(type: "smallint", nullable: true),
                    Phone = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: true),
                    Сorpus = table.Column<int>(type: "int", nullable: true),
                    District = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    CountPerson = table.Column<int>(type: "int", nullable: true),
                    SizeFlat = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abonent", x => x.AccountCD);
                    table.ForeignKey(
                        name: "FK_Abonent_Street",
                        column: x => x.StreetCD,
                        principalTable: "Street",
                        principalColumn: "StreetCD",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    ServiceCD = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    UnitsCD = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.ServiceCD);
                    table.ForeignKey(
                        name: "FK_Services_Unit",
                        column: x => x.UnitsCD,
                        principalTable: "Unit",
                        principalColumn: "UnitCD",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Request",
                columns: table => new
                {
                    RequestCD = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountCD = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: false),
                    FailureCD = table.Column<int>(type: "int", nullable: false),
                    ExecutorCD = table.Column<int>(type: "int", nullable: false),
                    IncomingDate = table.Column<DateTime>(type: "date", nullable: false),
                    ExecutionDate = table.Column<DateTime>(type: "date", nullable: false),
                    Executed = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Request", x => x.RequestCD);
                    table.ForeignKey(
                        name: "FK_Request_Abonent",
                        column: x => x.AccountCD,
                        principalTable: "Abonent",
                        principalColumn: "AccountCD",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Request_Disrepair",
                        column: x => x.FailureCD,
                        principalTable: "Disrepair",
                        principalColumn: "FailureCD",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Request_Executor",
                        column: x => x.ExecutorCD,
                        principalTable: "Executor",
                        principalColumn: "ExecutorCD",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Mode",
                columns: table => new
                {
                    ModeCD = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModeName = table.Column<string>(type: "varchar(230)", unicode: false, maxLength: 230, nullable: false),
                    Norma = table.Column<decimal>(type: "numeric(15,4)", nullable: false),
                    ServiceCD = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mode", x => x.ModeCD);
                    table.ForeignKey(
                        name: "FK_Mode_Services",
                        column: x => x.ServiceCD,
                        principalTable: "Services",
                        principalColumn: "ServiceCD",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Remains",
                columns: table => new
                {
                    RemainCD = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountCD = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: false),
                    ServiceCD = table.Column<int>(type: "int", nullable: false),
                    Remmonth = table.Column<short>(type: "smallint", nullable: false),
                    Remyear = table.Column<short>(type: "smallint", nullable: false),
                    Remainsum = table.Column<decimal>(type: "numeric(15,2)", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Remains", x => x.RemainCD);
                    table.ForeignKey(
                        name: "FK_Remains_Abonent",
                        column: x => x.AccountCD,
                        principalTable: "Abonent",
                        principalColumn: "AccountCD",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Remains_Servicess",
                        column: x => x.ServiceCD,
                        principalTable: "Services",
                        principalColumn: "ServiceCD",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AbonentMode",
                columns: table => new
                {
                    AbonentModeСD = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountCD = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: false),
                    ModeCD = table.Column<int>(type: "int", nullable: false),
                    Counterr = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbonentMode", x => x.AbonentModeСD);
                    table.ForeignKey(
                        name: "FK_AbonentMode_Abonent",
                        column: x => x.AccountCD,
                        principalTable: "Abonent",
                        principalColumn: "AccountCD",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AbonentMode_Mode",
                        column: x => x.ModeCD,
                        principalTable: "Mode",
                        principalColumn: "ModeCD",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Price",
                columns: table => new
                {
                    PriceCD = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PriceValue = table.Column<decimal>(type: "numeric(15,2)", nullable: false),
                    ModeCD = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Price", x => x.PriceCD);
                    table.ForeignKey(
                        name: "FK_Price_Servicess",
                        column: x => x.ModeCD,
                        principalTable: "Mode",
                        principalColumn: "ModeCD",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NachislSumma",
                columns: table => new
                {
                    NachislFactCD = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NachislSum = table.Column<decimal>(type: "numeric(15,2)", nullable: false),
                    NachislYear = table.Column<short>(type: "smallint", nullable: false),
                    NachislMonth = table.Column<short>(type: "smallint", nullable: false),
                    NachType = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    AbonentModeСD = table.Column<int>(type: "int", nullable: false),
                    CountResources = table.Column<decimal>(type: "numeric(15,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NachislSumma", x => x.NachislFactCD);
                    table.ForeignKey(
                        name: "FK_NachislSumma_AbonMode",
                        column: x => x.AbonentModeСD,
                        principalTable: "AbonentMode",
                        principalColumn: "AbonentModeСD",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PaySumma",
                columns: table => new
                {
                    PayFactCD = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaySum = table.Column<decimal>(type: "numeric(15,2)", nullable: false),
                    PayDate = table.Column<DateTime>(type: "date", nullable: false),
                    PayMonth = table.Column<short>(type: "smallint", nullable: false),
                    PayYear = table.Column<short>(type: "smallint", nullable: false),
                    AbonentModeСD = table.Column<int>(type: "int", nullable: false),
                    PayType = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    ReceptionPointCD = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaySumma", x => x.PayFactCD);
                    table.ForeignKey(
                        name: "FK_PaySumma_AbonMode",
                        column: x => x.AbonentModeСD,
                        principalTable: "AbonentMode",
                        principalColumn: "AbonentModeСD",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PaySumma_ReceptionPoint",
                        column: x => x.ReceptionPointCD,
                        principalTable: "ReceptionPoint",
                        principalColumn: "ReceptionPointCD",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Abonent_StreetCD",
                table: "Abonent",
                column: "StreetCD");

            migrationBuilder.CreateIndex(
                name: "IX_AbonentMode_AccountCD",
                table: "AbonentMode",
                column: "AccountCD");

            migrationBuilder.CreateIndex(
                name: "IX_AbonentMode_ModeCD",
                table: "AbonentMode",
                column: "ModeCD");

            migrationBuilder.CreateIndex(
                name: "IX_Mode_ServiceCD",
                table: "Mode",
                column: "ServiceCD");

            migrationBuilder.CreateIndex(
                name: "IX_NachislSumma_AbonentModeСD",
                table: "NachislSumma",
                column: "AbonentModeСD");

            migrationBuilder.CreateIndex(
                name: "IX_PaySumma_AbonentModeСD",
                table: "PaySumma",
                column: "AbonentModeСD");

            migrationBuilder.CreateIndex(
                name: "IX_PaySumma_ReceptionPointCD",
                table: "PaySumma",
                column: "ReceptionPointCD");

            migrationBuilder.CreateIndex(
                name: "IX_Price_ModeCD",
                table: "Price",
                column: "ModeCD");

            migrationBuilder.CreateIndex(
                name: "IX_Remains_AccountCD",
                table: "Remains",
                column: "AccountCD");

            migrationBuilder.CreateIndex(
                name: "IX_Remains_ServiceCD",
                table: "Remains",
                column: "ServiceCD");

            migrationBuilder.CreateIndex(
                name: "IX_Request_AccountCD",
                table: "Request",
                column: "AccountCD");

            migrationBuilder.CreateIndex(
                name: "IX_Request_ExecutorCD",
                table: "Request",
                column: "ExecutorCD");

            migrationBuilder.CreateIndex(
                name: "IX_Request_FailureCD",
                table: "Request",
                column: "FailureCD");

            migrationBuilder.CreateIndex(
                name: "IX_Services_UnitsCD",
                table: "Services",
                column: "UnitsCD");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NachislSumma");

            migrationBuilder.DropTable(
                name: "PaySumma");

            migrationBuilder.DropTable(
                name: "Price");

            migrationBuilder.DropTable(
                name: "Remains");

            migrationBuilder.DropTable(
                name: "Request");

            migrationBuilder.DropTable(
                name: "AbonentMode");

            migrationBuilder.DropTable(
                name: "ReceptionPoint");

            migrationBuilder.DropTable(
                name: "Disrepair");

            migrationBuilder.DropTable(
                name: "Executor");

            migrationBuilder.DropTable(
                name: "Abonent");

            migrationBuilder.DropTable(
                name: "Mode");

            migrationBuilder.DropTable(
                name: "Street");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Unit");
        }
    }
}
