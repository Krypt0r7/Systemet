using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SystemetAPI.Migrations
{
    public partial class Inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SysSortTable",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nr = table.Column<int>(nullable: false),
                    ArtikelId = table.Column<int>(nullable: false),
                    Varunummer = table.Column<int>(nullable: false),
                    Namn = table.Column<string>(nullable: true),
                    Namn2 = table.Column<string>(nullable: true),
                    PrisInkMoms = table.Column<decimal>(nullable: false),
                    Pant = table.Column<int>(nullable: false),
                    VolymIml = table.Column<decimal>(nullable: false),
                    PrisPerLiter = table.Column<decimal>(nullable: false),
                    Saljstart = table.Column<DateTime>(nullable: true),
                    Utgatt = table.Column<bool>(nullable: false),
                    Varugrupp = table.Column<string>(nullable: true),
                    Typ = table.Column<string>(nullable: true),
                    Stil = table.Column<string>(nullable: true),
                    Forpackning = table.Column<string>(nullable: true),
                    Forslutning = table.Column<string>(nullable: true),
                    Ursprung = table.Column<string>(nullable: true),
                    Land = table.Column<string>(nullable: true),
                    Producent = table.Column<string>(nullable: true),
                    Leverantör = table.Column<string>(nullable: true),
                    Argang = table.Column<int>(nullable: true),
                    Provadarargang = table.Column<int>(nullable: true),
                    Alkoholhalt = table.Column<decimal>(nullable: false),
                    Sortiment = table.Column<string>(nullable: true),
                    SortimentText = table.Column<string>(nullable: true),
                    Ekolokisk = table.Column<bool>(nullable: false),
                    Etiskt = table.Column<bool>(nullable: false),
                    Koscher = table.Column<bool>(nullable: false),
                    RavarorDesc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysSortTable", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SysSortTable");
        }
    }
}
