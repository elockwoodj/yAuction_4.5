using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yAuction.Data.IDAO;
using yAuction.Data.DAO;
using yAuction.Data.BEANS;

namespace yAuction.Data.IDAO
{
    public interface AuctionIDAO
    {
        IList<AuctionBEANS> GetListings(int category);
        IList<listing_Category> GetCategories();

        bool AddListing(Listings _newListing);

    }
}
