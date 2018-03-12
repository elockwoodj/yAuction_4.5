using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Validation;
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
            //Place variables from the tables into the beans
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

       

        //Listing check

        public bool ListingCheck(int Id)
        {
            IQueryable<int> idList = from lists
                                     in _context.Listings
                                     select lists.Id;
            if(idList.ToList<int>().Contains(Id))
            { return true; } else { return false; }          
        }

        //Add new listing funcionality
        public bool AddListing (AuctionBEANS _listingBEAN)
        {
            try
            {
                Listings _newListing = new Listings();
                _newListing.description = _listingBEAN.description;
                _newListing.image = _listingBEAN.image;
                _newListing.priceStart = _listingBEAN.priceStart;
                _newListing.priceAuction = _listingBEAN.priceAuction;
                _newListing.priceBuy = _listingBEAN.priceBuy;
                _newListing.category = _listingBEAN.categoryId;
                _newListing.accountId = _listingBEAN.accountId;
                _context.Listings.Add(_newListing);
                _context.SaveChanges();
                return true;
            }

            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine
                        ("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
                            ve.PropertyName,
                            eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                            ve.ErrorMessage);
                    }
                }
                return false;
                throw;
            }
        }

        //Delete Listing Functionality
        public bool DeleteListing(AuctionBEANS _listingBEAN)
        {
            bool check = ListingCheck(_listingBEAN.Id);
            if (check == false)
            {
                return false;
            }
            else
            {
                Listings _doomedList = new Listings();
                _doomedList.description = _listingBEAN.description;
                _doomedList.image = _listingBEAN.image;
                _doomedList.priceStart = _listingBEAN.priceStart;
                _doomedList.priceAuction = _listingBEAN.priceAuction;
                _doomedList.priceBuy = _listingBEAN.priceBuy;
                _doomedList.category = _listingBEAN.categoryId;
                _doomedList.accountId = _listingBEAN.accountId;
                _context.Listings.Remove(_doomedList);
                _context.SaveChanges();
                return true;
            }
        }


       //Get list of listing categories method

        public IList<listing_Category>GetCategories()
        {
            IQueryable<listing_Category> _categories;
            _categories = from category
                          in _context.listing_Category
                          select category;

            return _categories.ToList<listing_Category>();
        }

        // Get Bid History 

        public IList<bidBEANS> GetBidHistory(int accountId)
        {
            IQueryable<bidBEANS> __bidHistory;
            __bidHistory = from History
                           in _context.listingBid
                           where History.accountId == accountId
                           select new bidBEANS
                           {
                               Id = History.Id,
                               bid = History.bid,
                               itemId = History.itemId,
                               accountId = History.accountId
                           };
            return __bidHistory.ToList<bidBEANS>();
        }

        // Get Listing History
       public IList<AuctionBEANS> GetListingHistory(int accountId)
        {
            IQueryable<AuctionBEANS> _listingHistory;
            _listingHistory = from LHistory
                              in _context.Listings
                              where LHistory.accountId == accountId
                              select new AuctionBEANS
                              {
                                  Id = LHistory.Id,
                                  description = LHistory.description,
                                  image = LHistory.image,
                                  priceStart = LHistory.priceStart,
                                  priceAuction = LHistory.priceAuction,
                                  priceBuy = LHistory.priceBuy,
                                  category = LHistory.category,
                                  categoryId = LHistory.categoryId,
                                  accountId = LHistory.accountId

                              };
                              
            return _listingHistory.ToList<AuctionBEANS>();

            //TEST
           
        }

    }
}
