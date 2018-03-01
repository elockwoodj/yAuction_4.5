using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yAuction.Data.IDAO;

namespace yAuction.Data.DAO
{
    public class AuctionDAO : AuctionIDAO
    {
        private a9027410Entities _context;
        public AuctionDAO()
        {
            _context = new a9027410Entities();
        }
        public IList<listing_Category> GetListingCategory()
        {
            IQueryable<listing_Category> _listing;
            _listing = from listing
                       in _context.listing_Category
                       select listing;
            return _listing.ToList<listing_Category>();
        }

        //public Listings GetListings(int id)
        //{
        //    return ;
        //}

        //change
    }
}
