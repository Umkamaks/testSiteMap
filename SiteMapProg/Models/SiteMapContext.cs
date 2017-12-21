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

            MapSite mapSite = new MapSite() { NameSite = "Podrobnosti.uaffff" };
            db.MapSites.Add(mapSite);
            db.SaveChanges();


            SiteMapUrl siteMaps1 = new SiteMapUrl() { MapSite= mapSite, TimeOut = 1, UrlSite = "Podrobnosti" };
            SiteMapUrl siteMaps2 = new SiteMapUrl() { MapSite = mapSite, TimeOut = 1, UrlSite = "Podrobnosti" };
            SiteMapUrl siteMaps3 = new SiteMapUrl() {MapSite = mapSite, TimeOut = 1, UrlSite = "Podrobnosti" };
            db.SiteMapsUrls.AddRange(new List<SiteMapUrl> { siteMaps1, siteMaps2, siteMaps3 });
            db.SaveChanges();


        }
    }
}