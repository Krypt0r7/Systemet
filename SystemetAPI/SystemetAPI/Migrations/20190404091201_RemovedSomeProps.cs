using Microsoft.EntityFrameworkCore.Migrations;

namespace SystemetAPI.Migrations
{
    public partial class RemovedSomeProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Argang",
                table: "SysSortTable");

            migrationBuilder.DropColumn(
                name: "Ekolokisk",
                table: "SysSortTable");

            migrationBuilder.DropColumn(
                name: "Etiskt",
                table: "SysSortTable");

            migrationBuilder.DropColumn(
                name: "Forslutning",
                table: "SysSortTable");

            migrationBuilder.DropColumn(
                name: "Koscher",
                table: "SysSortTable");

            migrationBuilder.DropColumn(
                name: "Provadarargang",
                table: "SysSortTable");

            migrationBuilder.DropColumn(
                name: "Sortiment",
                table: "SysSortTable");

            migrationBuilder.DropColumn(
                name: "SortimentText",
                table: "SysSortTable");

            migrationBuilder.DropColumn(
                name: "Utgatt",
                table: "SysSortTable");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Argang",
                table: "SysSortTable",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Ekolokisk",
                table: "SysSortTable",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Etiskt",
                table: "SysSortTable",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Forslutning",
                table: "SysSortTable",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Koscher",
                table: "SysSortTable",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Provadarargang",
                table: "SysSortTable",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sortiment",
                table: "SysSortTable",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SortimentText",
                table: "SysSortTable",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Utgatt",
                table: "SysSortTable",
                nullable: false,
                defaultValue: false);
        }
    }
}
