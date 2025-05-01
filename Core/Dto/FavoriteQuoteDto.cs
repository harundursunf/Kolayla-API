using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dto
{
    public class FavoriteQuoteDto
    {

        public int Id { get; set; }
        public int UserId { get; set; }
        public int QuoteId { get; set; }
    }
}
