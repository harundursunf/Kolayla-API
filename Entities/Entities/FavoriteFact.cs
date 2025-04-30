using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class FavoriteFact
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int FactId { get; set; }

        public User User { get; set; }
        public Fact Fact { get; set; }
    }
}
