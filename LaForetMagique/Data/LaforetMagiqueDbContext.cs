using LaForetMagique.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LaForetMagique.Models;

namespace LaForetMagique.Data
{
    internal class LaforetMagiqueDbContext : DbContext
    {
        public DbSet<Entity> Entities { get; set; } = null!;
        public DbSet<Creature> Creatures { get; set; } = null!;
        public DbSet<Schtroumpf> Schtroumpfs { get; set; } = null!;
        public DbSet<Bug> Bugs { get; set; } = null!;
        public DbSet<Spider> Spiders { get; set; } = null!;
        public DbSet<Bzzfly> BzzFlies { get; set; } = null!;
        public DbSet<Item> Items { get; set; } = null!;
        public DbSet<RedPotion> RedPotions { get; set; } = null!;
        public DbSet<BluePotion> BluePotions { get; set; } = null!;
        public DbSet<Berry> Berries { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=ForetMagiqueDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuration de l'héritage TPH (Table Per Hierarchy)
            // Toutes les entités dans une seule table
            modelBuilder.Entity<Entity>()
                .HasDiscriminator<string>("EntityType")
                .HasValue<Schtroumpf>("Schtroumpf")
                .HasValue<Spider>("Spider")
                .HasValue<Bzzfly>("BzzFly")
                .HasValue<RedPotion>("RedPotion")
                .HasValue<BluePotion>("BluePotion")
                .HasValue<Berry>("Berry");

            // Index pour améliorer les performances de recherche par coordonnées
            modelBuilder.Entity<Entity>()
                .HasIndex(e => new { e.x, e.y });
        }
    }
}
