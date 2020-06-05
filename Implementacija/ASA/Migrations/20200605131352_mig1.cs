using Microsoft.EntityFrameworkCore.Migrations;

namespace ASA.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Korisnik_Racun_RacunId",
                table: "Korisnik");

            migrationBuilder.AddForeignKey(
                name: "FK_Korisnik_Racun_RacunId",
                table: "Korisnik",
                column: "RacunId",
                principalTable: "Racun",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Korisnik_Racun_RacunId",
                table: "Korisnik");

            migrationBuilder.AddForeignKey(
                name: "FK_Korisnik_Racun_RacunId",
                table: "Korisnik",
                column: "RacunId",
                principalTable: "Racun",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
