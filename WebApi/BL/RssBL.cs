using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using WebApi.Models;

namespace WebApi.BL
{
    public static class RssBL
    {
        public static List<FeedItem> ParseRssFile(string linkUrl)
        {
            XmlDocument rssXmlDoc = new XmlDocument();

            rssXmlDoc.Load(linkUrl);

            XmlNodeList rssNodes = rssXmlDoc.SelectNodes("rss/channel/item");

            List<FeedItem> itemsList = new List<FeedItem>();
            foreach (XmlNode rssNode in rssNodes)
            {
                XmlNode rssSubNode = rssNode.SelectSingleNode("title");
                string title = rssSubNode != null ? rssSubNode.InnerText : "";

                rssSubNode = rssNode.SelectSingleNode("link");
                string link = rssSubNode != null ? rssSubNode.InnerText : "";

                rssSubNode = rssNode.SelectSingleNode("description");
                string description = rssSubNode != null ? rssSubNode.InnerText : "";

                rssSubNode = rssNode.SelectSingleNode("description").SelectSingleNode("img");
                string imageUrl = rssSubNode != null ? rssSubNode.InnerText : "";

                DateTime date;
                rssSubNode = rssNode.SelectSingleNode("pubDate");
                string pubdate = rssSubNode != null ? rssSubNode.InnerText : "";
                string dateTime = DateTime.TryParse(pubdate, out date) ? date.ToString("yyyy-MM-dd HH:mm") : string.Empty;

                itemsList.Add(new FeedItem { Title = title, Link = link, Description = description, ImageUrl = imageUrl, Date = dateTime });
            }

            return itemsList;
        }
    }
}