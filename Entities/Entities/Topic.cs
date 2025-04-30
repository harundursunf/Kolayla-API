using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Topic
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string LessonType { get; set; } // "TYT" veya "AYT"
        public string Category { get; set; } // örn: "Fen", "Matematik"
    }
}
