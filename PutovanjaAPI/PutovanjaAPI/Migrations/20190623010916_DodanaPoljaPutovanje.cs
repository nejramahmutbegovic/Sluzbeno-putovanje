using Microsoft.EntityFrameworkCore.Migrations;

namespace PutovanjaAPI.Migrations
{
    public partial class DodanaPoljaPutovanje : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Dokumentacija",
                table: "UposlenikOdrediste",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Hotel",
                table: "UposlenikOdrediste",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Osiguranje",
                table: "UposlenikOdrediste",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Prevoz",
                table: "UposlenikOdrediste",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Uplate",
                table: "UposlenikOdrediste",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "UposlenikPlaca",
                table: "UposlenikOdrediste",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dokumentacija",
                table: "UposlenikOdrediste");

            migrationBuilder.DropColumn(
                name: "Hotel",
                table: "UposlenikOdrediste");

            migrationBuilder.DropColumn(
                name: "Osiguranje",
                table: "UposlenikOdrediste");

            migrationBuilder.DropColumn(
                name: "Prevoz",
                table: "UposlenikOdrediste");

            migrationBuilder.DropColumn(
                name: "Uplate",
                table: "UposlenikOdrediste");

            migrationBuilder.DropColumn(
                name: "UposlenikPlaca",
                table: "UposlenikOdrediste");
        }
    }
}
