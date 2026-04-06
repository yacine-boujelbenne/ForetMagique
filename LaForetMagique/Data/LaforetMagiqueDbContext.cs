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
    public class LaforetMagiqueDbContext : DbContext
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

            // TPT mapping strategy (Table Per Type)
            modelBuilder.Entity<Entity>().UseTptMappingStrategy();

            // Index pour améliorer les performances de recherche par coordonnées
            modelBuilder.Entity<Entity>()
                .HasIndex(e => new { e.x, e.y });

            // Configurations via Fluent API
            modelBuilder.Entity<Schtroumpf>()
                .Property(s => s.Role)
                .IsRequired()
                .HasMaxLength(50);

            // Configure Relationships
            modelBuilder.Entity<Schtroumpf>()
                .HasMany(s => s.Bugs)
                .WithOne(b => b.Schtroumpf)
                .HasForeignKey(b => b.SchtroumpfId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Schtroumpf>()
                .HasMany(s => s.Items)
                .WithOne(i => i.Schtroumpf)
                .HasForeignKey(i => i.SchtroumpfId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Creature>()
                .Property(c => c.Health)
                .HasDefaultValue(100);

            // -- NEW FLUENT API CONFS TO REINFORCE THE MODEL --
            
            // Ignore Computed Properties
            modelBuilder.Entity<Creature>()
                .Ignore(c => c.IsAlive);

            // Default values and column configurations via Fluent API
            modelBuilder.Entity<Entity>()
                .Property(e => e.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Item>()
                .Property(i => i.IsCollected)
                .HasDefaultValue(false);

            modelBuilder.Entity<Bug>()
                .Property(b => b.AttackPower)
                .HasDefaultValue(5);

            modelBuilder.Entity<Bug>()
                .Property(b => b.IsHostile)
                .HasDefaultValue(true);
        }
    }
}
