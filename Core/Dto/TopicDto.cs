using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dto
{
    public  class TopicDto
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string LessonType { get; set; } // "TYT" veya "AYT"
        public string Category { get; set; } // örn: "Fen", "Matematik"
    }
}
