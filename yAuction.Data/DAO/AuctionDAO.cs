using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yAuction.Data.IDAO;
using yAuction.Data.BEANS;

namespace yAuction.Data.DAO
{
    public class AuctionDAO : AuctionIDAO
    {
        private a9027410Entities _context;
        public AuctionDAO()
        {
            _context = new a9027410Entities();
        }
        public IList<listing_Category> GetListingCategory(int category)
        {
            IQueryable<AuctionBEANS> _listingBEANs = from list in _context.listing_Category
                                                     from categ in _context.Listings
                                                     where list.category == categ.Id
                                                     where categ.Id == category
                                                     select new AuctionBEANS
                                                     {

                                                     };

        }

        //public Listings GetListings(int id)
        //{
        //    return ;
        //}

        //change
    }
}
