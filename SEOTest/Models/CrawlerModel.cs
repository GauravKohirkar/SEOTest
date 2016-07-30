using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace SEOTest.Models
{
    public class CrawlerModel
    {
        /// <summary>
        /// Private Variables
        /// </summary>
        private static Regex REGEX_FOR_GOOGLE_SEARCH_RESULT = new Regex(@"<h3 class=""r""><a href=""/.*?\?q=(.*?)"">(.*?)</a>", RegexOptions.IgnoreCase);

        /// <summary>
        /// Get Lists of SearchResults
        /// </summary>
        /// <param name="response"></param>
        /// <returns>Lists of SearchResults</returns>
        public static List<WebsiteModel> ReturnWebsites(string responeObject)
        {
            var websites = new List<WebsiteModel>();

            var matchingoptions = REGEX_FOR_GOOGLE_SEARCH_RESULT.Match(responeObject);
            int rank = 1;
            while (matchingoptions.Success && matchingoptions.Groups.Count == 3)
            {
                var uriString = matchingoptions.Groups[1].Value;

                Uri uri;

                // Discard invalid urls
                if (!Uri.TryCreate(uriString, UriKind.Absolute, out uri))
                {
                    
                }
                else
                {
                    var description = matchingoptions.Groups[2].Value;
                    rank++;
                    websites.Add(new WebsiteModel(uri, description,rank ));
                }

                matchingoptions = matchingoptions.NextMatch();
            }

            // return the websites searched
            return websites;
        }
    }
}