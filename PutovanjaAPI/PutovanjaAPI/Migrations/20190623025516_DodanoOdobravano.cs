using Microsoft.EntityFrameworkCore.Migrations;

namespace PutovanjaAPI.Migrations
{
    public partial class DodanoOdobravano : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Odobravano",
                table: "UposlenikOdrediste",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Odobravano",
                table: "UposlenikOdrediste");
        }
    }
}
