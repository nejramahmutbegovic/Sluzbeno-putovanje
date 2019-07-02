using Microsoft.EntityFrameworkCore.Migrations;

namespace PutovanjaAPI.Migrations
{
    public partial class DodanoPoljeOdobreno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Odobreno",
                table: "UposlenikOdrediste",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Odobreno",
                table: "UposlenikOdrediste");
        }
    }
}
