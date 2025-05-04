using Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context
{
    public class StudyFlowApiDbContext : DbContext
    {
        public StudyFlowApiDbContext(DbContextOptions<StudyFlowApiDbContext> options) : base(options) { }

        public DbSet<CompletedTopic> CompletedTopics { get; set; }
        public DbSet<DailyGoal> DailyGoals { get; set; }
        public DbSet<Fact> Facts { get; set; }
        public DbSet<FavoriteFact> FavoriteFacts { get; set; }
        public DbSet<FavoriteQuote> FavoriteQuotes { get; set; }
        public DbSet<NetEntry> NetEntries { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<StudyRecord> StudyRecords { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DailyGoal>()
                .HasOne(dg => dg.User)
                .WithMany(u => u.DailyGoals)
                .HasForeignKey(dg => dg.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<FavoriteFact>()
                .HasOne(ff => ff.User)
                .WithMany(u => u.FavoriteFacts)
                .HasForeignKey(ff => ff.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CompletedTopic>()
                .HasOne(ct => ct.User)
                .WithMany(u => u.CompletedTopics)
                .HasForeignKey(ct => ct.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<NetEntry>()
                .HasOne(ne => ne.User)
                .WithMany(u => u.NetEntries)
                .HasForeignKey(ne => ne.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<StudyRecord>()
                .HasOne(sr => sr.User)
                .WithMany(u => u.StudyRecords)
                .HasForeignKey(sr => sr.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<FavoriteQuote>()
                .HasOne(fq => fq.User)
                .WithMany(u => u.FavoriteQuotes)
                .HasForeignKey(fq => fq.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
