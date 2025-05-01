using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dto
{
    public  class StudyRecordDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int WorkMinutes { get; set; }
        public int BreakMinutes { get; set; }
        public DateTime RecordDate { get; set; }
    }
}
