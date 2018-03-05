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

        public bool AddListing (Listings _newListing)
        {
            try
            {
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

        //public Listings GetListings(int id)
        //{
        //    return ;
        //}

        //change

        public IList<listing_Category>GetCategories()
        {
            IQueryable<listing_Category> _categories;
            _categories = from category
                          in _context.listing_Category
                          select category;

            return _categories.ToList<listing_Category>();
        }
    }
}
