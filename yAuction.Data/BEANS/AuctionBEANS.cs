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
        public byte[] image { get; set; }
        public double priceStart { get; set; }
        public Nullable<double> priceAuction { get; set; }
        public Nullable<double> priceBuy { get; set; }
        public string category { get; set; }
        public int categoryId { get; set; }
        public int accountId { get; set; }

    }
}
