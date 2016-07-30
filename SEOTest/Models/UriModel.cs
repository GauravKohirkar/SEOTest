using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SEOTest.Models
{
    public class UriModel
    {
        private string keyword = "";
        private int startpage = 0;
        private int numberofsearches = 0;

        public UriModel(string keyword, int startpage, int numberofsearches)
        {
            this.keyword = keyword;
            this.startpage = startpage;
            this.numberofsearches = numberofsearches;
        }

        public Uri getUri()
        {
            var uri = "https://www.google.com.au/search?q=" + keyword + "&start=" + startpage + "&num=" + numberofsearches + "";
            return new Uri(uri);
        }
    }
}