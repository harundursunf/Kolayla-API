using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class StudyRecord
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int WorkMinutes { get; set; }
        public int BreakMinutes { get; set; }
        public DateTime RecordDate { get; set; }

        public User User { get; set; }
    }
}
