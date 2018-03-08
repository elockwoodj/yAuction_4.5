using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace yAuction.Data.BEANS
{
    public class bidBEANS
    {
        public bidBEANS() { }

        public int Id { get; set; }
        public double bid { get; set; }
        public int itemId { get; set; }
        public int accountId { get; set; }

    }
}
