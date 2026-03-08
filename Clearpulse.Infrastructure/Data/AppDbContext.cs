using Clearpulse.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clearpulse.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Pulse> Pulses => Set<Pulse>();
        public DbSet<Feedback> Feedbacks => Set<Feedback>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pulse>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.PublicId).IsUnique();
                entity.HasIndex(e => e.SecretToken).IsUnique();
                entity.Property(e => e.Title).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Content).IsRequired().HasMaxLength(2000);
                entity.HasOne(d => d.Pulse)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.PulseId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
