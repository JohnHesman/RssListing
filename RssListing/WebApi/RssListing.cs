using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Xml;
using Umbraco.Core.Logging;

namespace RssListing.WebApi
{
    public class RssListing
    {
        public static List<RssListingItem> GetListingItems(string feedUrl)
        {
            if (string.IsNullOrWhiteSpace(feedUrl))
            {
                return new List<RssListingItem>();
            }
            var result = new List<RssListingItem>();
            try
            {
                SyndicationFeed articles;
                using (var feed = XmlReader.Create(feedUrl))
                {
                    articles = SyndicationFeed.Load(feed);
                }

                if (articles != null)
                {
                    result.AddRange(articles.Items.Select(article => new RssListingItem
                    {
                        Summary = article.Summary.Text,
                        Title = article.Title.Text,
                        Url = article.Links[0].Uri.ToString()
                    }));
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error<RssListing>("RssListing Error", ex);
            }

            return result;
        }
    }
}
