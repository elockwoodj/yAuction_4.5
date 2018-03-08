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
            //Ask Dharam about BEANs in Controllers while exposing API's - not sure as to process 
            IList<yAuction.Data.BEANS.AuctionBEANS> listing =
                //This GetListings refers to the AuctionDAO method, wihch cannot be converted into this data type
                _listingService.GetListings(id);
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
