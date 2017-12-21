using SiteMapProg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiteMapProg.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult SiteJson(string urladdress)
        {
            SiteMapUrl siteMapUrl = new SiteMapUrl();
            SiteMapRepository siteMapRepository = new SiteMapRepository();
            string massage;
            IEnumerable<string> listSite = new List<string>();
            SiteMapDoc siteMapDoc = new SiteMapDoc();
            TestSiteMap testSiteMap = new TestSiteMap();
            MapSite mapSite = new MapSite();
            try
            {
                listSite = siteMapDoc.ParseSitemapFile(urladdress);// список страниц            
                mapSite.NameSite = urladdress;
                testSiteMap.TestSites(listSite, mapSite);//Для наглядности работоспособности сайта используеться первые 15 линков
                siteMapRepository.Create(mapSite);
                return Json(mapSite.SiteMapUrls.OrderBy(m => m.TimeOut), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                massage = ex.Message;
                return Json(massage, JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult History()
        {
            IEnumerable<MapSite> mapSite = new List<MapSite>();
            SiteMapRepository siteMapRepository = new SiteMapRepository();
            mapSite = siteMapRepository.Get();
            return View(mapSite);
        }
    }
}