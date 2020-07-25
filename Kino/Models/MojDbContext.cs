using Kino.Models.ManyToManyClasses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Runtime.InteropServices;

namespace Kino.Models
{
    public class MojDbContext: DbContext
    {
        public DbSet<Drzava> Drzava { get; set; }
        public DbSet<Zanr> Zanr { get; set; }
		public DbSet<VrstaDvorane> VrstaDvorane { get; set; }
        public DbSet<Grad> Grad { get; set; }
        public DbSet<Adresa> Adresa { get; set;}
        public DbSet<Glumac> Glumac { get; set; }
        public DbSet<Reziser> Reziser { get; set; }
		public DbSet<KinoObjekat> KinoObjekat { get; set; }
		public DbSet<Dvorana> Dvorana { get; set; }
        public DbSet<Kupac> Kupac { get; set; }
        public DbSet<Objava> Objava { get; set; }
        public DbSet<NagradnaIgra> NagradnaIgra { get; set; }
        public DbSet<NagradnaIgraKupac> NagradnaIgraKupac { get; set; }
		
        public DbSet<Film> Film { get; set; }
        public DbSet<FilmZanr> FilmZanr { get; set; }
        public DbSet<FilmGlumac> FilmGlumac { get; set; }
        public DbSet<FilmReziser> FilmReziser { get; set; }
        public DbSet<Sjediste> Sjedista { get; set; }
        public DbSet<Projekcija> Projekcija { get; set; }
        public DbSet<Komentar> Komentar { get; set; }
        public DbSet<Rezervacija> Rezervacija { get; set; }
        public DbSet< ProjekcijaSjedista> projekcijaSjedista { get; set; }
        public DbSet< Korisnik> Korisnici { get; set; }
        public DbSet< Uloga> Uloge { get; set; }
        public DbSet< FilmOcjena> FilmOcjena { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
     //   optionsBuilder.UseSqlServer("Server=localhost;Database=Kino;Trusted_Connection=True;MultipleActiveResultSets=true;");
           
            optionsBuilder.UseSqlServer("Server=localhost;Database=Cinema;Trusted_Connection=True;MultipleActiveResultSets=true;");

         //optionsBuilder.UseSqlServer(@"Server=DESKTOP-HB2VMU2\ADNASQLSERVER;Database=KinoSem;Trusted_Connection=True;MultipleActiveResultSets=true;");

        }

        
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);

        //    builder.Entity<Uloga>().HasData(new Uloga()
        //    {
        //        UlogaID = 1,
        //        Naziv = "Administrator"
        //    }) ;

        //    builder.Entity<Uloga>().HasData(new Uloga()
        //    {
        //        UlogaID = 2,
        //        Naziv = "Uposlenik"
        //    });

        //    builder.Entity<Uloga>().HasData(new Uloga()
        //    {
        //        UlogaID = 3,
        //        Naziv = "Kupac"
        //    });

        //    builder.Entity<Korisnik>().HasData(new Korisnik()
        //    {
        //        KorisnikID = 1,
        //        Ime = "Demo",
        //        Prezime = "Demo",
        //        UlogaID = 1,
        //        GradID = 1,
        //        DatumRodjenja = DateTime.Now.AddDays(-8000),
        //        BrojTelefona = "061111111",
        //        Email="demo.demo@hotmail.com",
        //        AutorizacijskiToken = Guid.NewGuid(),
        //        PasswordHash = "Test1234",
        //        UserName = "demo"

        //    });
        //    builder.Entity<Korisnik>().HasData(new Korisnik()
        //    {
        //        KorisnikID = 5,
        //        Ime = "Demo1",
        //        Prezime = "Demo1",
        //        UlogaID = 2,
        //        GradID = 1,
        //        Email="demo1.demo1@hotmail.com",
        //        DatumRodjenja = DateTime.Now.AddDays(-8000),
        //        BrojTelefona = "061111111",
        //        AutorizacijskiToken = Guid.NewGuid(),
        //        PasswordHash = "Test12345",
        //        UserName = "demo1"

        //    });
        //    builder.Entity<Korisnik>().HasData(new Korisnik()
        //    {
        //        KorisnikID = 6,
        //        Ime = "demo",
        //        Prezime = "demic",
        //        Email="demo.demic@hotmail.com",
        //        UlogaID = 3,
        //        GradID = 1,
        //        DatumRodjenja = DateTime.Now.AddDays(-8000),
        //        BrojTelefona = "061111111",
        //        AutorizacijskiToken = Guid.NewGuid(),
        //        PasswordHash = "Test123456",
        //        UserName = "demod"

        //    });
        //    builder.Entity<Zanr>().HasData(new Zanr()
        //    {   ZanrID=1,
        //        Naziv="Komedija",
        //        Opis="Satiričan sadržaj",
        //        Zarada=0
        //    });
        //    builder.Entity<Zanr>().HasData(new Zanr()
        //    {
        //        ZanrID = 2,
        //        Naziv = "Drama",
        //        Opis = "Užurbana i tajanstvena radnja",
        //        Zarada = 0
        //    });
        //    builder.Entity<Zanr>().HasData(new Zanr()
        //    {
        //        ZanrID = 3,
        //        Naziv = "Romantični",
        //        Opis = "Radnja temeljena na romantici",
        //        Zarada = 0
        //    });
        //    builder.Entity<Zanr>().HasData(new Zanr()
        //    {
        //        ZanrID = 4,
        //        Naziv = "Akcija",
        //        Opis = "Radnja temeljena na akciji",
        //        Zarada = 0
        //    });
        //    builder.Entity<Zanr>().HasData(new Zanr()
        //    {
        //        ZanrID = 5,
        //        Naziv = "Horor",
        //        Opis = "Strasni prizori",
        //        Zarada = 0
        //    });
        //    builder.Entity<Zanr>().HasData(new Zanr()
        //    {
        //        ZanrID = 6,
        //        Naziv = "Fantazija",
        //        Opis = "Radnja temeljena na čarobnjacima i magijama",
        //        Zarada = 0
        //    });
        //}
    }
}
