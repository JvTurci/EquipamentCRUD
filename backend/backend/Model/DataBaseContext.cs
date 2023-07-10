using backend.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace backend.Model
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options)
                : base(options)
        {
        }

        public DbSet<Equipament> Equipament { get; set; }
        public DbSet<ReadDirection> ReadDirection { get; set; }
        public DbSet<Situation> Situation { get; set; }
        public DbSet<UF> UF { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Equipament>()
                .HasOne(e => e.UfSource)
                .WithMany()
                .HasForeignKey(e => e.UfSourceId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Equipament>()
                .HasOne(e => e.UfDestination)
                .WithMany()
                .HasForeignKey(e => e.UfDestinationId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Equipament>()
                .HasOne(e => e.Situation)
                .WithMany()
                .HasForeignKey(e => e.SituationId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Equipament>()
                .HasOne(e => e.ReadDirection)
                .WithMany()
                .HasForeignKey(e => e.ReadDirectionId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
