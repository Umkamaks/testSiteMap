using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SiteMapProg.Models
{
    public class SiteMapContext : DbContext
    {

        static SiteMapContext()
        {

            Database.SetInitializer<SiteMapContext>(new MyContextInitializer());
        }
        public SiteMapContext(): base("DefaultConnection") {  }

        public DbSet<MapSite> MapSites { get; set; }
        public DbSet<SiteMapUrl> SiteMapsUrls { get; set; }
    }
    class MyContextInitializer : DropCreateDatabaseAlways<SiteMapContext>
    {
        protected override void Seed(SiteMapContext db)
        {

            MapSite mapSite = new MapSite() { NameSite = "http://podrobnosti.ua" };
            db.MapSites.Add(mapSite);
            db.SaveChanges();


            SiteMapUrl siteMaps1 = new SiteMapUrl() { MapSite= mapSite, TimeOut = 1, UrlSite = "http://podrobnosti.ua/2223807-v-ankare-progremel-vzryv-pervye-foto-i-video.html" };
            SiteMapUrl siteMaps2 = new SiteMapUrl() { MapSite = mapSite, TimeOut = 1, UrlSite = "http://podrobnosti.ua/2223806-pod-zhitomirom-zastrelilsja-ukrainskij-voennyj.html" };
            SiteMapUrl siteMaps3 = new SiteMapUrl() {MapSite = mapSite, TimeOut = 1, UrlSite = "http://podrobnosti.ua/2223767-pogoda-na-2-fevralja-ukrainu-nakrojut-dozhdi.html" };
            db.SiteMapsUrls.AddRange(new List<SiteMapUrl> { siteMaps1, siteMaps2, siteMaps3 });
            db.SaveChanges();


        }
    }
}