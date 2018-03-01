using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yAuction.Data.BEANS
{
    public class AuctionBEANS
    {
        public AuctionBEANS() { }

        public int Id { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public float priceStart { get; set; }
        public float priceAuction { get; set; }
        public float priceBuy { get; set; }
        public string category { get; set; }
        public int categoryId { get; set; }




    }
}
