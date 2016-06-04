using System.Collections.Generic;
using System.Web.Http;
using Umbraco.Web.WebApi;

namespace RssListing.WebApi
{
    public class RssListingPreviewController : UmbracoApiController
    {
        [HttpPost]
        public List<RssListingItem> GetListingItems(FeedRequest feedRequest)
        {
            return RssListing.GetListingItems(feedRequest.FeedUrl);
        }
    }
}
