using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using yAuction.Data.DAO;
using yAuction.Data.IDAO;
using yAuction.Data.BEANS;
using yAuction.Data;

namespace yAuction_4._5.Controllers
{
    public class ListingController : ApiController
    {
        private AuctionDAO _listingService;

        public ListingController()
        {
            _listingService = new yAuction.Data.DAO.AuctionDAO();
        }

        public HttpResponseMessage GetListings(int id)
        {
            IList<AuctionBEANS> listing =  _listingService.GetListings(id);

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


        public HttpResponseMessage GetBidHistory(int accountId)
        {
            IEnumerable<listingBid> _bids =
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

        public HttpResponseMessage GetListingHistory(int accountId)
        {
            IEnumerable<Listings> _listHistory =
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

        public HttpResponseMessage GetListingCategories()
        {
            IEnumerable<listing_Category> _Category =
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

        [HttpPost]
        public HttpResponseMessage postListing(AuctionBEANS newListing)
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
        
        [HttpPut]
        public HttpResponseMessage putListing(AuctionBEANS listingChange)
        {
            if (_listingService.EditListing(listingChange) == true)
            {
                HttpResponseMessage response =
                    Request.CreateResponse(HttpStatusCode.Created, listingChange);
                response.Headers.Location =
                    new Uri(Request.RequestUri, "/api/Listing/" + listingChange.Id.ToString());
                return response;
            }
            else
            {
                HttpResponseMessage response =
                    Request.CreateResponse(HttpStatusCode.NotAcceptable, listingChange);
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
