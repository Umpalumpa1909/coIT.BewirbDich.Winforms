using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace coIT.BewirbDich.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "VersicherungsscheinSequence");

            migrationBuilder.CreateTable(
                name: "OutboxMessageConsumers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutboxMessageConsumers", x => new { x.Id, x.Name });
                });

            migrationBuilder.CreateTable(
                name: "OutboxMessages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OccurredOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProcessedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Error = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutboxMessages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VersicherungsVorgang",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Erstellungsdatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VorgangsStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VersicherungsVorgang", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Angebotsanfrage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Versicherungssumme = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InkludiereZusatzschutz = table.Column<bool>(type: "bit", nullable: false),
                    ZusatzschutzAufschlag = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HatWebshop = table.Column<bool>(type: "bit", nullable: false),
                    Risiko = table.Column<int>(type: "int", nullable: false),
                    Berechnungsart = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Angebotsanfrage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Angebotsanfrage_VersicherungsVorgang_Id",
                        column: x => x.Id,
                        principalTable: "VersicherungsVorgang",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VersicherungsKondidtionen",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Berechnungsbasis = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GrundBeitrag = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WebShopAufschlag = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ZusatzschutzAufschlag = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RisikoAufschlag = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GesamtBeitrag = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VersicherungsKondidtionen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VersicherungsKondidtionen_VersicherungsVorgang_Id",
                        column: x => x.Id,
                        principalTable: "VersicherungsVorgang",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Versicherungsschein",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Versicherungsnummer = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [VersicherungsscheinSequence]"),
                    ErstellungsDatum = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Versicherungsschein", x => new { x.Id, x.Versicherungsnummer });
                    table.ForeignKey(
                        name: "FK_Versicherungsschein_VersicherungsVorgang_Id",
                        column: x => x.Id,
                        principalTable: "VersicherungsVorgang",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Versicherungsschein_Id",
                table: "Versicherungsschein",
                column: "Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Angebotsanfrage");

            migrationBuilder.DropTable(
                name: "OutboxMessageConsumers");

            migrationBuilder.DropTable(
                name: "OutboxMessages");

            migrationBuilder.DropTable(
                name: "VersicherungsKondidtionen");

            migrationBuilder.DropTable(
                name: "Versicherungsschein");

            migrationBuilder.DropTable(
                name: "VersicherungsVorgang");

            migrationBuilder.DropSequence(
                name: "VersicherungsscheinSequence");
        }
    }
}
