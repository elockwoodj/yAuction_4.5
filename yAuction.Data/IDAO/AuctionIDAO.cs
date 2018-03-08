﻿using System;
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
        IList<listingBid> GetBidHistory(int accountId);
        IList<Listings> GetListingHistory(int accountId);

        bool ListingCheck(int id);
        bool AddListing(AuctionBEANS _newListing);
        bool DeleteListing(Listings _listing);
    }
}
