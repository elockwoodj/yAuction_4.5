using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yAuction.Data.IDAO;
using yAuction.Data.DAO;

namespace yAuction.Data.IDAO
{
    public interface AuctionIDAO
    {
        IList<listing_Category> GetListingCategory(int category);

        //yAuction.Data.Listings GetListings(int id);


        //testestsetsetsetstd
    }
}
