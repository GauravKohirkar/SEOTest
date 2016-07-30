using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace SEOTest.Models
{
    public class SEOModel
    {
        private string keyword = "";
        private string companyURL = "";
        public int yourrank = -1;
        private static Encoding ENCODING = Encoding.UTF8;

        public SEOModel(string keyword, string companyURL)
        {
            this.keyword = keyword;
            this.companyURL = companyURL;
        }

        public string YouRank(string keyword, string companyURL)
        {
            companyURL = companyURL.ToLower();
            // Call the google website for search 100 entries.
            UriModel objUril = new UriModel(keyword, 0, 100);
            var uri = objUril.getUri();
            var request = CreateWebRequest(uri);

            // send request and process result
            var response = ExchangeResponse(request);
            var encoding = EncodeResponse(response, ENCODING);
            List<WebsiteModel> result = ProcessStream(response, encoding);

            foreach (WebsiteModel objWebsite in result)
            {
                string WebURL = objWebsite.getCleanURL().ToLower();
                if (WebURL.Contains(companyURL))
                    return "Congratulations!! Your company ranks " + objWebsite.rank + "th in today's search.";
            }
            return "Sorry!! your company was not found in top 100 searches. Kindly improve your SEO!!";
        }

        private static HttpWebRequest CreateWebRequest(Uri uri)
        {
            var request = WebRequest.Create(uri) as HttpWebRequest;
            if (request == null)
            {
                throw new InvalidOperationException("Request couldn't be generated.");
            }
            return request;
        }
        private static HttpWebResponse ExchangeResponse(WebRequest webRequest)
        {
            var response = webRequest.GetResponse() as HttpWebResponse;
            if (response == null)
            {
                throw new InvalidOperationException("Failed to retrieve response.");
            }

            return response;
        }
        private static Encoding EncodeResponse(HttpWebResponse response, Encoding defaultTo)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(response.CharacterSet))
                {
                    return Encoding.GetEncoding(response.CharacterSet);
                }
            }
            catch (Exception ex)
            {
            }

            // default
            return defaultTo;
        }
        private static List<WebsiteModel> ProcessStream(WebResponse response, Encoding encoding)
        {
            using (var responseStream = response.GetResponseStream())
            using (var streamReader = new StreamReader(responseStream, encoding))
            {
                var responsed = streamReader.ReadToEnd();
                var results = CrawlerModel.ReturnWebsites(responsed);
                return results;
            }
        }

    }
}