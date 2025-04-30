using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class FavoriteQuote
    {

        public int Id { get; set; }
        public int UserId { get; set; }
        public int QuoteId { get; set; }

        public User User { get; set; }
        public Quote Quote { get; set; }
    }
}
