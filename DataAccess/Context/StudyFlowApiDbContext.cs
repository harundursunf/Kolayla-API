using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
   public  class StudyFlowApiDbContext: DbContext
    {
        public StudyFlowApiDbContext(DbContextOptions<StudyFlowApiDbContext> options) : base(options) { }

        public DbSet<CompletedTopic> completedTopics { get; set; }
        public DbSet<DailyGoal> dailyGoals { get; set; }
        public DbSet<Fact> facts { get; set; }
        public DbSet<FavoriteFact> favoriteFacts { get; set; }
        public DbSet<FavoriteQuote> favoriteQuotes {  get; set; } 

        public DbSet<NetEntry> netEntries { get; set; }

        public DbSet<Note> notes { get; set; }

        public DbSet<Quote> quotes { get; set; }

        public DbSet<StudyRecord> studyRecords { get; set; }

        public DbSet<Topic> topics { get; set; }

        public DbSet<User> users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DailyGoal>()
           .HasOne(dg => dg.User)              // Her DailyGoal bir User'a ait
           .WithMany(u => u.DailyGoals)        // Her User birçok DailyGoal'e sahip olabilir
           .HasForeignKey(dg => dg.UserId)     // DailyGoal UserId ile ilişkilendirilir
           .OnDelete(DeleteBehavior.Cascade);  // Kullanıcı silindiğinde hedefler de silinir

            // User - FavoriteFact (Bir kullanıcı birçok favori faktöre sahip olabilir)
            modelBuilder.Entity<FavoriteFact>()
                .HasOne(ff => ff.User)              // Her FavoriteFact bir User'a ait
                .WithMany(u => u.FavoriteFacts)     // Her User birçok FavoriteFact'e sahip olabilir
                .HasForeignKey(ff => ff.UserId)     // FavoriteFact UserId ile ilişkilendirilir
                .OnDelete(DeleteBehavior.Cascade);  // Kullanıcı silindiğinde favori faktörler de silinir

            // User - CompletedTopic (Bir kullanıcı birçok tamamlanmış konuya sahip olabilir)
            modelBuilder.Entity<CompletedTopic>()
                .HasOne(ct => ct.User)              // Her CompletedTopic bir User'a ait
                .WithMany(u => u.CompletedTopics)   // Her User birçok CompletedTopic'e sahip olabilir
                .HasForeignKey(ct => ct.UserId)     // CompletedTopic UserId ile ilişkilendirilir
                .OnDelete(DeleteBehavior.Cascade);  // Kullanıcı silindiğinde tamamlanmış konular da silinir

            // User - NetEntry (Bir kullanıcı birçok net girişine sahip olabilir)
            modelBuilder.Entity<NetEntry>()
                .HasOne(ne => ne.User)              // Her NetEntry bir User'a ait
                .WithMany(u => u.NetEntries)        // Her User birçok NetEntry'e sahip olabilir
                .HasForeignKey(ne => ne.UserId)     // NetEntry UserId ile ilişkilendirilir
                .OnDelete(DeleteBehavior.Cascade);  // Kullanıcı silindiğinde net girişler de silinir

            // User - StudyRecord (Bir kullanıcı birçok çalışma kaydına sahip olabilir)
            modelBuilder.Entity<StudyRecord>()
                .HasOne(sr => sr.User)              // Her StudyRecord bir User'a ait
                .WithMany(u => u.StudyRecords)      // Her User birçok StudyRecord'a sahip olabilir
                .HasForeignKey(sr => sr.UserId)     // StudyRecord UserId ile ilişkilendirilir
                .OnDelete(DeleteBehavior.Cascade);  // Kullanıcı silindiğinde çalışma kayıtları da silinir

            // User - FavoriteQuote (Bir kullanıcı birçok favori alıntıya sahip olabilir)
            modelBuilder.Entity<FavoriteQuote>()
                .HasOne(fq => fq.User)              // Her FavoriteQuote bir User'a ait
                .WithMany(u => u.FavoriteQuotes)    // Her User birçok FavoriteQuote'a sahip olabilir
                .HasForeignKey(fq => fq.UserId)     // FavoriteQuote UserId ile ilişkilendirilir
                .OnDelete(DeleteBehavior.Cascade);  // Kullanıcı silindiğinde favori alıntılar da silinir
        }
    }
}
