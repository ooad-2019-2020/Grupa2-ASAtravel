using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ASA.Migrations
{
    public partial class Prva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cijena",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PunaCijena = table.Column<double>(nullable: false),
                    Akontacija = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cijena", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Racun",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrojRacuna = table.Column<string>(nullable: true),
                    IznosNovca = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Racun", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Agencija",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Info = table.Column<string>(nullable: true),
                    Naziv = table.Column<string>(nullable: true),
                    UsloviPutovanja = table.Column<string>(nullable: true),
                    RacunId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agencija", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agencija_Racun_RacunId",
                        column: x => x.RacunId,
                        principalTable: "Racun",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kod",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sifra = table.Column<string>(nullable: true),
                    Popust = table.Column<int>(nullable: false),
                    AgencijaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kod", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kod_Agencija_AgencijaId",
                        column: x => x.AgencijaId,
                        principalTable: "Agencija",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    AgencijaId = table.Column<int>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    PutovanjeId = table.Column<int>(nullable: true),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    DatumRodjenja = table.Column<DateTime>(nullable: true),
                    MjestoStanovanja = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    RacunId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Korisnik_Racun_RacunId",
                        column: x => x.RacunId,
                        principalTable: "Racun",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Korisnik_Agencija_AgencijaId",
                        column: x => x.AgencijaId,
                        principalTable: "Agencija",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Putovanje",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Slika = table.Column<string>(nullable: true),
                    Destinacija = table.Column<string>(nullable: true),
                    Info = table.Column<string>(nullable: true),
                    Aktuelno = table.Column<bool>(nullable: false),
                    DatumPolaska = table.Column<DateTime>(nullable: false),
                    DatumPovratka = table.Column<DateTime>(nullable: false),
                    MinBrojLjudi = table.Column<int>(nullable: false),
                    MaxBrojLjudi = table.Column<int>(nullable: false),
                    CijenaId = table.Column<int>(nullable: false),
                    AgencijaId = table.Column<int>(nullable: true),
                    KlijentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Putovanje", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Putovanje_Agencija_AgencijaId",
                        column: x => x.AgencijaId,
                        principalTable: "Agencija",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Putovanje_Cijena_CijenaId",
                        column: x => x.CijenaId,
                        principalTable: "Cijena",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Putovanje_Korisnik_KlijentId",
                        column: x => x.KlijentId,
                        principalTable: "Korisnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ocjena",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrojOcjena = table.Column<int>(nullable: false),
                    Prosjek = table.Column<double>(nullable: false),
                    KorisnikId = table.Column<int>(nullable: false),
                    PutovanjeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocjena", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ocjena_Korisnik_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ocjena_Putovanje_PutovanjeId",
                        column: x => x.PutovanjeId,
                        principalTable: "Putovanje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rezervacija",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KlijentId = table.Column<int>(nullable: false),
                    PutovanjeId = table.Column<int>(nullable: false),
                    KodId = table.Column<int>(nullable: true),
                    Cijena = table.Column<double>(nullable: false),
                    AgencijaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervacija", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rezervacija_Agencija_AgencijaId",
                        column: x => x.AgencijaId,
                        principalTable: "Agencija",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rezervacija_Korisnik_KlijentId",
                        column: x => x.KlijentId,
                        principalTable: "Korisnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rezervacija_Kod_KodId",
                        column: x => x.KodId,
                        principalTable: "Kod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rezervacija_Putovanje_PutovanjeId",
                        column: x => x.PutovanjeId,
                        principalTable: "Putovanje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agencija_RacunId",
                table: "Agencija",
                column: "RacunId");

            migrationBuilder.CreateIndex(
                name: "IX_Kod_AgencijaId",
                table: "Kod",
                column: "AgencijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_RacunId",
                table: "Korisnik",
                column: "RacunId");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_AgencijaId",
                table: "Korisnik",
                column: "AgencijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_PutovanjeId",
                table: "Korisnik",
                column: "PutovanjeId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocjena_KorisnikId",
                table: "Ocjena",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocjena_PutovanjeId",
                table: "Ocjena",
                column: "PutovanjeId");

            migrationBuilder.CreateIndex(
                name: "IX_Putovanje_AgencijaId",
                table: "Putovanje",
                column: "AgencijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Putovanje_CijenaId",
                table: "Putovanje",
                column: "CijenaId");

            migrationBuilder.CreateIndex(
                name: "IX_Putovanje_KlijentId",
                table: "Putovanje",
                column: "KlijentId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_AgencijaId",
                table: "Rezervacija",
                column: "AgencijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_KlijentId",
                table: "Rezervacija",
                column: "KlijentId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_KodId",
                table: "Rezervacija",
                column: "KodId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_PutovanjeId",
                table: "Rezervacija",
                column: "PutovanjeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Korisnik_Putovanje_PutovanjeId",
                table: "Korisnik",
                column: "PutovanjeId",
                principalTable: "Putovanje",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agencija_Racun_RacunId",
                table: "Agencija");

            migrationBuilder.DropForeignKey(
                name: "FK_Korisnik_Racun_RacunId",
                table: "Korisnik");

            migrationBuilder.DropForeignKey(
                name: "FK_Korisnik_Agencija_AgencijaId",
                table: "Korisnik");

            migrationBuilder.DropForeignKey(
                name: "FK_Putovanje_Agencija_AgencijaId",
                table: "Putovanje");

            migrationBuilder.DropForeignKey(
                name: "FK_Korisnik_Putovanje_PutovanjeId",
                table: "Korisnik");

            migrationBuilder.DropTable(
                name: "Ocjena");

            migrationBuilder.DropTable(
                name: "Rezervacija");

            migrationBuilder.DropTable(
                name: "Kod");

            migrationBuilder.DropTable(
                name: "Racun");

            migrationBuilder.DropTable(
                name: "Agencija");

            migrationBuilder.DropTable(
                name: "Putovanje");

            migrationBuilder.DropTable(
                name: "Cijena");

            migrationBuilder.DropTable(
                name: "Korisnik");
        }
    }
}
