using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Linq;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;


   public static class Api

    {       
            public static List<Article> ScrapeTls()
            {
                var html = GetTLSHtml();
                return GetItems(html);
            }

            private static string GetTLSHtml()
            {
                  using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("user-agent", "amazon is trash");
                    var url = $"https://www.thelakewoodscoop.com";
                    var html = client.GetStringAsync(url).Result;
                    return html;
                }
            }

            private static List<Article> GetItems(string html)
            {
                var parser = new HtmlParser();
                IHtmlDocument document = parser.ParseDocument(html);
                var itemDivs = document.QuerySelectorAll(".post");
                List<Article> items = new List<Article>();
                foreach (var div in itemDivs)
                {
                Article news = new Article();
                    var href = div.QuerySelectorAll("h2 a").First();
            news.Title = href.TextContent.Trim();
            news.Url = href.Attributes["href"].Value;

                    var image = div.QuerySelector("img");
            news.ImageUrl = image.Attributes["src"].Value;

           var date = div.QuerySelector("small");
            if (date!=null && date.TextContent.Trim() != "")
                            {
                news.Date = DateTime.Parse(date.TextContent.Trim());
            }
            items.Add(news);
                }

                return items;
            }
        }

