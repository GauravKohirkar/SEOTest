using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace SEOTest.Models
{
    public class WebsiteModel
    {
        private static readonly Regex REGEX_FOR_CLEAN_URL = new Regex("^[^&]+", RegexOptions.IgnoreCase);
        private Uri cleanurl;
        private string description;
        public int rank = -1;

        public WebsiteModel(Uri uri, string text, int rank)
        {
            this.cleanurl = new Uri(REGEX_FOR_CLEAN_URL.Match(uri.OriginalString).Groups[0].Value);
            this.description = text;
            this.rank = rank;
        }

        public string getCleanURL()
        {
            return this.cleanurl.ToString();
        }
        public string getDescription()
        {
            return this.description;
        }

        // PUBLIC METHODS
        public override string ToString()
        {
            return String.Format("{0}{1}[{2}]", description, Environment.NewLine, this.cleanurl);
        }
    }
}