using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dto
{
    public class CompletedTopicDto
    {

        public int Id { get; set; }
        public int UserId { get; set; }
        public int TopicId { get; set; }
        public DateTime CompletedDate { get; set; }
    }
}
