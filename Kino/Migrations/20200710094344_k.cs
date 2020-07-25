using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kino.Migrations
{
    public partial class k : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drzava",
                columns: table => new
                {
                    DrzavaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    Oznaka = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drzava", x => x.DrzavaID);
                });

            migrationBuilder.CreateTable(
                name: "Film",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    Trajanje = table.Column<int>(nullable: false),
                    DobnoOgraničenje = table.Column<string>(nullable: true),
                    GodinaIzdavanja = table.Column<int>(nullable: false),
                    Sinopsis = table.Column<string>(nullable: true),
                    Aktuelan = table.Column<bool>(nullable: false),
                    Slika = table.Column<string>(nullable: true),
                    Trailer = table.Column<string>(nullable: true),
                    Zarada = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Film", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sjedista",
                columns: table => new
                {
                    SjedisteID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DvoranaID = table.Column<int>(nullable: false),
                    Red = table.Column<string>(nullable: true),
                    Kolona = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sjedista", x => x.SjedisteID);
                });

            migrationBuilder.CreateTable(
                name: "Uloge",
                columns: table => new
                {
                    UlogaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uloge", x => x.UlogaID);
                });

            migrationBuilder.CreateTable(
                name: "VrstaDvorane",
                columns: table => new
                {
                    VrstaDvoraneID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VrstaDvorane", x => x.VrstaDvoraneID);
                });

            migrationBuilder.CreateTable(
                name: "Zanr",
                columns: table => new
                {
                    ZanrID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    Opis = table.Column<string>(nullable: true),
                    Zarada = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zanr", x => x.ZanrID);
                });

            migrationBuilder.CreateTable(
                name: "Grad",
                columns: table => new
                {
                    GradID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    PostanskiBroj = table.Column<int>(nullable: false),
                    DrzavaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grad", x => x.GradID);
                    table.ForeignKey(
                        name: "FK_Grad_Drzava_DrzavaID",
                        column: x => x.DrzavaID,
                        principalTable: "Drzava",
                        principalColumn: "DrzavaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FilmZanr",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilmId = table.Column<int>(nullable: false),
                    ZanrId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmZanr", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FilmZanr_Film_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Film",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmZanr_Zanr_ZanrId",
                        column: x => x.ZanrId,
                        principalTable: "Zanr",
                        principalColumn: "ZanrID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Adresa",
                columns: table => new
                {
                    AdresaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivUlice = table.Column<string>(nullable: true),
                    GradId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresa", x => x.AdresaID);
                    table.ForeignKey(
                        name: "FK_Adresa_Grad_GradId",
                        column: x => x.GradId,
                        principalTable: "Grad",
                        principalColumn: "GradID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Glumac",
                columns: table => new
                {
                    GlumacID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    DatumRodjenja = table.Column<DateTime>(nullable: false),
                    CV = table.Column<string>(nullable: true),
                    GradID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Glumac", x => x.GlumacID);
                    table.ForeignKey(
                        name: "FK_Glumac_Grad_GradID",
                        column: x => x.GradID,
                        principalTable: "Grad",
                        principalColumn: "GradID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Korisnici",
                columns: table => new
                {
                    KorisnikID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    AutorizacijskiToken = table.Column<Guid>(nullable: false),
                    BrojTelefona = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Slika = table.Column<string>(nullable: true),
                    DatumRodjenja = table.Column<DateTime>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PasswordSalt = table.Column<string>(nullable: true),
                    GradID = table.Column<int>(nullable: true),
                    UlogaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnici", x => x.KorisnikID);
                    table.ForeignKey(
                        name: "FK_Korisnici_Grad_GradID",
                        column: x => x.GradID,
                        principalTable: "Grad",
                        principalColumn: "GradID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Korisnici_Uloge_UlogaID",
                        column: x => x.UlogaID,
                        principalTable: "Uloge",
                        principalColumn: "UlogaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reziser",
                columns: table => new
                {
                    ReziserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    DatumRodjenja = table.Column<DateTime>(nullable: false),
                    CV = table.Column<string>(nullable: true),
                    GradID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reziser", x => x.ReziserID);
                    table.ForeignKey(
                        name: "FK_Reziser_Grad_GradID",
                        column: x => x.GradID,
                        principalTable: "Grad",
                        principalColumn: "GradID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KinoObjekat",
                columns: table => new
                {
                    KinoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    AdresaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KinoObjekat", x => x.KinoID);
                    table.ForeignKey(
                        name: "FK_KinoObjekat_Adresa_AdresaId",
                        column: x => x.AdresaId,
                        principalTable: "Adresa",
                        principalColumn: "AdresaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FilmGlumac",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilmId = table.Column<int>(nullable: false),
                    GlumacID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmGlumac", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FilmGlumac_Film_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Film",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmGlumac_Glumac_GlumacID",
                        column: x => x.GlumacID,
                        principalTable: "Glumac",
                        principalColumn: "GlumacID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kupac",
                columns: table => new
                {
                    KupacID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikID = table.Column<int>(nullable: false),
                    DatumUclanjenja = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kupac", x => x.KupacID);
                    table.ForeignKey(
                        name: "FK_Kupac_Korisnici_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnici",
                        principalColumn: "KorisnikID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NagradnaIgra",
                columns: table => new
                {
                    NagradnaIgraID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    Opis = table.Column<string>(nullable: true),
                    Pocetak = table.Column<DateTime>(nullable: false),
                    Kraj = table.Column<DateTime>(nullable: false),
                    KorisnikID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NagradnaIgra", x => x.NagradnaIgraID);
                    table.ForeignKey(
                        name: "FK_NagradnaIgra_Korisnici_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnici",
                        principalColumn: "KorisnikID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Objava",
                columns: table => new
                {
                    ObjavaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikID = table.Column<int>(nullable: false),
                    Naslov = table.Column<string>(nullable: true),
                    Sadrzaj = table.Column<string>(nullable: true),
                    DatumObjave = table.Column<DateTime>(nullable: false),
                    Slika = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Objava", x => x.ObjavaID);
                    table.ForeignKey(
                        name: "FK_Objava_Korisnici_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnici",
                        principalColumn: "KorisnikID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FilmReziser",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilmId = table.Column<int>(nullable: false),
                    ReziserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmReziser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FilmReziser_Film_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Film",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmReziser_Reziser_ReziserID",
                        column: x => x.ReziserID,
                        principalTable: "Reziser",
                        principalColumn: "ReziserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dvorana",
                columns: table => new
                {
                    DvoranaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    Opis = table.Column<string>(nullable: true),
                    VrstaDvoraneID = table.Column<int>(nullable: false),
                    KinoObjekatID = table.Column<int>(nullable: false),
                    Kapacitet = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dvorana", x => x.DvoranaID);
                    table.ForeignKey(
                        name: "FK_Dvorana_KinoObjekat_KinoObjekatID",
                        column: x => x.KinoObjekatID,
                        principalTable: "KinoObjekat",
                        principalColumn: "KinoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dvorana_VrstaDvorane_VrstaDvoraneID",
                        column: x => x.VrstaDvoraneID,
                        principalTable: "VrstaDvorane",
                        principalColumn: "VrstaDvoraneID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FilmOcjena",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ocjena = table.Column<float>(nullable: true),
                    FilmID = table.Column<int>(nullable: false),
                    KupacID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmOcjena", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FilmOcjena_Film_FilmID",
                        column: x => x.FilmID,
                        principalTable: "Film",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmOcjena_Kupac_KupacID",
                        column: x => x.KupacID,
                        principalTable: "Kupac",
                        principalColumn: "KupacID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NagradnaIgraKupac",
                columns: table => new
                {
                    NagradnaIgraKupacId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KupacId = table.Column<int>(nullable: false),
                    NagradnaIgraId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NagradnaIgraKupac", x => x.NagradnaIgraKupacId);
                    table.ForeignKey(
                        name: "FK_NagradnaIgraKupac_Kupac_KupacId",
                        column: x => x.KupacId,
                        principalTable: "Kupac",
                        principalColumn: "KupacID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_NagradnaIgraKupac_NagradnaIgra_NagradnaIgraId",
                        column: x => x.NagradnaIgraId,
                        principalTable: "NagradnaIgra",
                        principalColumn: "NagradnaIgraID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Komentar",
                columns: table => new
                {
                    KomentarId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ObjavaId = table.Column<int>(nullable: false),
                    KupacId = table.Column<int>(nullable: false),
                    Datum = table.Column<DateTime>(nullable: false),
                    Sadrzaj = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Komentar", x => x.KomentarId);
                    table.ForeignKey(
                        name: "FK_Komentar_Kupac_KupacId",
                        column: x => x.KupacId,
                        principalTable: "Kupac",
                        principalColumn: "KupacID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Komentar_Objava_ObjavaId",
                        column: x => x.ObjavaId,
                        principalTable: "Objava",
                        principalColumn: "ObjavaID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Projekcija",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pocetak = table.Column<DateTime>(nullable: false),
                    Kraj = table.Column<DateTime>(nullable: false),
                    Cijena = table.Column<double>(nullable: false),
                    DvoranaID = table.Column<int>(nullable: false),
                    FilmID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projekcija", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projekcija_Dvorana_DvoranaID",
                        column: x => x.DvoranaID,
                        principalTable: "Dvorana",
                        principalColumn: "DvoranaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projekcija_Film_FilmID",
                        column: x => x.FilmID,
                        principalTable: "Film",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rezervacija",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datum = table.Column<DateTime>(nullable: false),
                    UkupnaCijena = table.Column<double>(nullable: false),
                    brojSjedista = table.Column<int>(nullable: false),
                    ProjekcijaID = table.Column<int>(nullable: false),
                    KupacID = table.Column<int>(nullable: false),
                    Zakljucena = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervacija", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rezervacija_Kupac_KupacID",
                        column: x => x.KupacID,
                        principalTable: "Kupac",
                        principalColumn: "KupacID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rezervacija_Projekcija_ProjekcijaID",
                        column: x => x.ProjekcijaID,
                        principalTable: "Projekcija",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "projekcijaSjedista",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjekcijaID = table.Column<int>(nullable: false),
                    SjedisteID = table.Column<int>(nullable: false),
                    Zauzeto = table.Column<bool>(nullable: false),
                    RezervacijaID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projekcijaSjedista", x => x.Id);
                    table.ForeignKey(
                        name: "FK_projekcijaSjedista_Projekcija_ProjekcijaID",
                        column: x => x.ProjekcijaID,
                        principalTable: "Projekcija",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_projekcijaSjedista_Rezervacija_RezervacijaID",
                        column: x => x.RezervacijaID,
                        principalTable: "Rezervacija",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_projekcijaSjedista_Sjedista_SjedisteID",
                        column: x => x.SjedisteID,
                        principalTable: "Sjedista",
                        principalColumn: "SjedisteID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Drzava",
                columns: new[] { "DrzavaID", "Naziv", "Oznaka" },
                values: new object[] { 1, "Bosna i Hercegovina", "BiH" });

            migrationBuilder.InsertData(
                table: "Uloge",
                columns: new[] { "UlogaID", "Naziv" },
                values: new object[,]
                {
                    { 1, "Administrator" },
                    { 2, "Uposlenik" },
                    { 3, "Kupac" }
                });

            migrationBuilder.InsertData(
                table: "Zanr",
                columns: new[] { "ZanrID", "Naziv", "Opis", "Zarada" },
                values: new object[,]
                {
                    { 1, "Komedija", "Satiričan sadržaj", 0.0 },
                    { 2, "Drama", "Užurbana i tajanstvena radnja", 0.0 },
                    { 3, "Romantični", "Radnja temeljena na romantici", 0.0 },
                    { 4, "Akcija", "Radnja temeljena na akciji", 0.0 },
                    { 5, "Horor", "Strasni prizori", 0.0 },
                    { 6, "Fantazija", "Radnja temeljena na čarobnjacima i magijama", 0.0 }
                });

            migrationBuilder.InsertData(
                table: "Grad",
                columns: new[] { "GradID", "DrzavaID", "Naziv", "PostanskiBroj" },
                values: new object[] { 1, 1, "Mostar", 88000 });

            migrationBuilder.InsertData(
                table: "Adresa",
                columns: new[] { "AdresaID", "GradId", "NazivUlice" },
                values: new object[] { 1, 1, "Mostar" });

            migrationBuilder.InsertData(
                table: "Korisnici",
                columns: new[] { "KorisnikID", "AutorizacijskiToken", "BrojTelefona", "DatumRodjenja", "Email", "GradID", "Ime", "PasswordHash", "PasswordSalt", "Prezime", "Slika", "UlogaID", "UserName" },
                values: new object[,]
                {
                    { 1, new Guid("59fd8b11-89cc-4eae-b4dd-de534e48b753"), "061111111", new DateTime(1998, 8, 15, 11, 43, 42, 886, DateTimeKind.Local).AddTicks(8177), "demo.demo@hotmail.com", 1, "Demo", "Test1234", null, "Demo", null, 1, "demo" },
                    { 5, new Guid("712ba639-3107-4b1a-83e8-4fa271542849"), "061111111", new DateTime(1998, 8, 15, 11, 43, 42, 897, DateTimeKind.Local).AddTicks(1764), "demo1.demo1@hotmail.com", 1, "Demo1", "Test12345", null, "Demo1", null, 2, "demo1" },
                    { 6, new Guid("1137a93a-8079-4f0b-928e-a1ad64ebc099"), "061111111", new DateTime(1998, 8, 15, 11, 43, 42, 897, DateTimeKind.Local).AddTicks(2547), "demo.demic@hotmail.com", 1, "demo", "Test123456", null, "demic", null, 3, "demod" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adresa_GradId",
                table: "Adresa",
                column: "GradId");

            migrationBuilder.CreateIndex(
                name: "IX_Dvorana_KinoObjekatID",
                table: "Dvorana",
                column: "KinoObjekatID");

            migrationBuilder.CreateIndex(
                name: "IX_Dvorana_VrstaDvoraneID",
                table: "Dvorana",
                column: "VrstaDvoraneID");

            migrationBuilder.CreateIndex(
                name: "IX_FilmGlumac_FilmId",
                table: "FilmGlumac",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmGlumac_GlumacID",
                table: "FilmGlumac",
                column: "GlumacID");

            migrationBuilder.CreateIndex(
                name: "IX_FilmOcjena_FilmID",
                table: "FilmOcjena",
                column: "FilmID");

            migrationBuilder.CreateIndex(
                name: "IX_FilmOcjena_KupacID",
                table: "FilmOcjena",
                column: "KupacID");

            migrationBuilder.CreateIndex(
                name: "IX_FilmReziser_FilmId",
                table: "FilmReziser",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmReziser_ReziserID",
                table: "FilmReziser",
                column: "ReziserID");

            migrationBuilder.CreateIndex(
                name: "IX_FilmZanr_FilmId",
                table: "FilmZanr",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmZanr_ZanrId",
                table: "FilmZanr",
                column: "ZanrId");

            migrationBuilder.CreateIndex(
                name: "IX_Glumac_GradID",
                table: "Glumac",
                column: "GradID");

            migrationBuilder.CreateIndex(
                name: "IX_Grad_DrzavaID",
                table: "Grad",
                column: "DrzavaID");

            migrationBuilder.CreateIndex(
                name: "IX_KinoObjekat_AdresaId",
                table: "KinoObjekat",
                column: "AdresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Komentar_KupacId",
                table: "Komentar",
                column: "KupacId");

            migrationBuilder.CreateIndex(
                name: "IX_Komentar_ObjavaId",
                table: "Komentar",
                column: "ObjavaId");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnici_GradID",
                table: "Korisnici",
                column: "GradID");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnici_UlogaID",
                table: "Korisnici",
                column: "UlogaID");

            migrationBuilder.CreateIndex(
                name: "IX_Kupac_KorisnikID",
                table: "Kupac",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_NagradnaIgra_KorisnikID",
                table: "NagradnaIgra",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_NagradnaIgraKupac_KupacId",
                table: "NagradnaIgraKupac",
                column: "KupacId");

            migrationBuilder.CreateIndex(
                name: "IX_NagradnaIgraKupac_NagradnaIgraId",
                table: "NagradnaIgraKupac",
                column: "NagradnaIgraId");

            migrationBuilder.CreateIndex(
                name: "IX_Objava_KorisnikID",
                table: "Objava",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Projekcija_DvoranaID",
                table: "Projekcija",
                column: "DvoranaID");

            migrationBuilder.CreateIndex(
                name: "IX_Projekcija_FilmID",
                table: "Projekcija",
                column: "FilmID");

            migrationBuilder.CreateIndex(
                name: "IX_projekcijaSjedista_ProjekcijaID",
                table: "projekcijaSjedista",
                column: "ProjekcijaID");

            migrationBuilder.CreateIndex(
                name: "IX_projekcijaSjedista_RezervacijaID",
                table: "projekcijaSjedista",
                column: "RezervacijaID");

            migrationBuilder.CreateIndex(
                name: "IX_projekcijaSjedista_SjedisteID",
                table: "projekcijaSjedista",
                column: "SjedisteID");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_KupacID",
                table: "Rezervacija",
                column: "KupacID");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_ProjekcijaID",
                table: "Rezervacija",
                column: "ProjekcijaID");

            migrationBuilder.CreateIndex(
                name: "IX_Reziser_GradID",
                table: "Reziser",
                column: "GradID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmGlumac");

            migrationBuilder.DropTable(
                name: "FilmOcjena");

            migrationBuilder.DropTable(
                name: "FilmReziser");

            migrationBuilder.DropTable(
                name: "FilmZanr");

            migrationBuilder.DropTable(
                name: "Komentar");

            migrationBuilder.DropTable(
                name: "NagradnaIgraKupac");

            migrationBuilder.DropTable(
                name: "projekcijaSjedista");

            migrationBuilder.DropTable(
                name: "Glumac");

            migrationBuilder.DropTable(
                name: "Reziser");

            migrationBuilder.DropTable(
                name: "Zanr");

            migrationBuilder.DropTable(
                name: "Objava");

            migrationBuilder.DropTable(
                name: "NagradnaIgra");

            migrationBuilder.DropTable(
                name: "Rezervacija");

            migrationBuilder.DropTable(
                name: "Sjedista");

            migrationBuilder.DropTable(
                name: "Kupac");

            migrationBuilder.DropTable(
                name: "Projekcija");

            migrationBuilder.DropTable(
                name: "Korisnici");

            migrationBuilder.DropTable(
                name: "Dvorana");

            migrationBuilder.DropTable(
                name: "Film");

            migrationBuilder.DropTable(
                name: "Uloge");

            migrationBuilder.DropTable(
                name: "KinoObjekat");

            migrationBuilder.DropTable(
                name: "VrstaDvorane");

            migrationBuilder.DropTable(
                name: "Adresa");

            migrationBuilder.DropTable(
                name: "Grad");

            migrationBuilder.DropTable(
                name: "Drzava");
        }
    }
}
