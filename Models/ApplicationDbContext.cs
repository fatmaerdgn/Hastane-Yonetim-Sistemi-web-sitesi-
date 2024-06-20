using bitirmeMVC5.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace bitirmeMVC5.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Poliklinik> Poliklinikler { get; set; }
        public DbSet<Personel> Personeller { get; set; }
        public DbSet<Doktor> Doktorlar { get; set; }
        public DbSet<Hasta> Hasta { get; set; }
        public DbSet<Ameliyat> Ameliyatlar { get; set; } 
        public DbSet<Randevular> Randevular { get; set; }
        public DbSet<Aboneler> Aboneler { get; set; }
        


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personel>().ToTable("personel");
            modelBuilder.Entity<Doktor>().ToTable("doktor");
            modelBuilder.Entity<Ameliyat>().ToTable("Ameliyatlar");


           modelBuilder.Entity<Ameliyat>().HasIndex(a => a.TcKimlikNo).IsUnique(); // TcKimlikNo alanının benzersiz olmasını sağlar
            
           modelBuilder.Entity<Hasta>()
            .HasIndex(h => h.TcKimlikNo)
            .IsUnique();

            modelBuilder.Entity<Hasta>()
                .HasIndex(h => h.Eposta)
                .IsUnique();


        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-0M417A5;Initial Catalog=bitirme_projesi;Integrated Security=True");
        }
    }

}
