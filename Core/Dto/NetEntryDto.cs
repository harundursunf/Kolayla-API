using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dto
{
    public class NetEntryDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string LessonType { get; set; } // "AYT" veya "TYT"
        public string LessonName { get; set; }
        public double Correct { get; set; }
        public double Wrong { get; set; }
        public DateTime Date { get; set; }
    }
}
