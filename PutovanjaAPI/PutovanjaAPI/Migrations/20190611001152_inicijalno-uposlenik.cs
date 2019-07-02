using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PutovanjaAPI.Migrations
{
    public partial class inicijalnouposlenik : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Odrediste",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odrediste", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Uposlenik",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uposlenik", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UposlenikOdrediste",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DatumPolaska = table.Column<DateTime>(nullable: false),
                    DatumPovratka = table.Column<DateTime>(nullable: false),
                    UposlenikId = table.Column<int>(nullable: false),
                    OdredisteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UposlenikOdrediste", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UposlenikOdrediste_Odrediste_OdredisteId",
                        column: x => x.OdredisteId,
                        principalTable: "Odrediste",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UposlenikOdrediste_Uposlenik_UposlenikId",
                        column: x => x.UposlenikId,
                        principalTable: "Uposlenik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UposlenikOdrediste_OdredisteId",
                table: "UposlenikOdrediste",
                column: "OdredisteId");

            migrationBuilder.CreateIndex(
                name: "IX_UposlenikOdrediste_UposlenikId",
                table: "UposlenikOdrediste",
                column: "UposlenikId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UposlenikOdrediste");

            migrationBuilder.DropTable(
                name: "Odrediste");

            migrationBuilder.DropTable(
                name: "Uposlenik");
        }
    }
}
