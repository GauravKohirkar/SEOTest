using SEOTest.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace SEOTest.Controllers
{
    public class SEOController : Controller
    {
        // GET: SEO
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetLinks()
        {
            string keyword = Request["keyword"].ToString();
            string website = Request["website"].ToString();
            SEOModel objSEO = new SEOModel(keyword, website);
            string result = objSEO.YouRank(keyword, website);
            ViewData["SEORank"] = result;
            return View();
        }
    }
}