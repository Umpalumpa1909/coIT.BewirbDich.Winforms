using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace coIT.BewirbDich.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnzahlMitarbeiter",
                table: "Angebotsanfrage");
        }

        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnzahlMitarbeiter",
                table: "Angebotsanfrage",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}