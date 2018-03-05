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
        public IList<AuctionBEANS> GetListings(int category)
        {
            IQueryable<AuctionBEANS> _listingBEANs = from list in _context.Listings
                                                     from categ in _context.listing_Category
                                                     where list.category == categ.Id
                                                     where categ.Id == category
                                                     select new AuctionBEANS
                                                     {
                                                         Id = list.Id,
                                                         description = list.description,
                                                         image = list.image,
                                                         category = categ.category,
                                                         priceStart = list.priceStart,
                                                         priceAuction = list.priceAuction,
                                                         priceBuy = list.priceBuy
                                                     };
            return _listingBEANs.ToList<AuctionBEANS>();

        }

        //public Listings GetListings(int id)
        //{
        //    return ;
        //}

        //change
    }
}
