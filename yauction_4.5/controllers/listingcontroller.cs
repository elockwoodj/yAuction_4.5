using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using yAuction.Data.DAO;
using yAuction.Data.IDAO;
using yAuction.Data.BEANS;

namespace yAuction_4._5.Controllers
{
    public class ListingController : ApiController
    {
        private yAuction.Data.DAO.AuctionDAO _listingService;

        public ListingController()
        {
            _listingService = new yAuction.Data.DAO.AuctionDAO();
        }

        public System.Net.Http.HttpResponseMessage GetListings(int id)
        {
            IList<yAuction.Data.BEANS.AuctionBEANS> listing =  _listingService.GetListings(id);

            if (listing == null)
            {
                HttpResponseMessage response =
                    Request.CreateResponse(HttpStatusCode.NotFound);
                return response;
            }
            else
            {
                HttpResponseMessage response =
                    Request.CreateResponse(HttpStatusCode.OK, listing);
                return response;
            }
        }


        public System.Net.Http.HttpResponseMessage GetBidHistory(int accountId)
        {
            IEnumerable<yAuction.Data.listingBid> _bids =
                _listingService.GetBidHistory(accountId);
            if (_bids == null)
            {
                HttpResponseMessage response =
                    Request.CreateResponse(HttpStatusCode.NotFound);
                return response;
            }
            else
            {
                HttpResponseMessage response =
                    Request.CreateResponse(HttpStatusCode.OK, _bids);
                return response;
            }
        }

        public System.Net.Http.HttpResponseMessage GetListingHistory(int accountId)
        {
            IEnumerable<yAuction.Data.Listings> _listHistory =
                _listingService.GetListingHistory(accountId);
            if (_listHistory == null)
            {
                HttpResponseMessage response =
                    Request.CreateResponse(HttpStatusCode.NotFound);
                return response;
            }
            else
            {
                HttpResponseMessage response =
                    Request.CreateResponse(HttpStatusCode.OK, _listHistory);
                return response;
            }
        }

        public System.Net.Http.HttpResponseMessage GetListingCategories()
        {
            IEnumerable<yAuction.Data.listing_Category> _Category =
                _listingService.GetCategories();
            if (_Category == null)
            {
                HttpResponseMessage response =
                    Request.CreateResponse(HttpStatusCode.NotFound);
                return response;
            }
            else
            {
                HttpResponseMessage response =
                    Request.CreateResponse(HttpStatusCode.OK, _Category);
                return response;
            }
        }

        public System.Net.Http.HttpResponseMessage postListing(yAuction.Data.BEANS.AuctionBEANS newListing)
        {
            if (_listingService.AddListing(newListing) == true)
            {
                HttpResponseMessage response =
                    Request.CreateResponse(HttpStatusCode.Created, newListing);
                response.Headers.Location =
                    new Uri(Request.RequestUri, "/api/Listing/" + newListing.Id.ToString());
                return response;
            }
            else
            {
                HttpResponseMessage response =
                    Request.CreateResponse(HttpStatusCode.NotAcceptable, newListing);
                return response;
            }
        }



        // GET: api/Listing
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Listing/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Listing
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Listing/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Listing/5
        public void Delete(int id)
        {
        }
    }
}
