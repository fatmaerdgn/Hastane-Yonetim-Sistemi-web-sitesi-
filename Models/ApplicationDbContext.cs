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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personel>().ToTable("personel");
        }
    }
}
