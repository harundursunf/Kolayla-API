using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public  class User
    {
        public int Id { get; set; }
         
        public string Name { get; set; }

        public string Email { get; set; }

        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }

        public ICollection<FavoriteQuote> FavoriteQuotes { get; set; }
        public ICollection<FavoriteFact> FavoriteFacts { get; set; }
        public ICollection<DailyGoal> DailyGoals { get; set; }
        public ICollection<Note> Notes { get; set; }
        public ICollection<StudyRecord> StudyRecords { get; set; }
        public ICollection<NetEntry> NetEntries { get; set; }
        public ICollection<CompletedTopic> CompletedTopics { get; set; }

    }
}
