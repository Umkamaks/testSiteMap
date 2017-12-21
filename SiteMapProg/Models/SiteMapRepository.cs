using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SiteMapProg.Models
{
    public class SiteMapRepository
    {

        SiteMapContext siteMapContext = new SiteMapContext();

        public void Create(MapSite item)
        {
            siteMapContext.MapSites.Add(item);
            siteMapContext.SaveChanges();
        }
        public MapSite FindById(int? id)
        {
            return siteMapContext.MapSites.Find(id);
        }
        public IEnumerable<MapSite> Get()
        {
            return siteMapContext.MapSites.Include(m=>m.SiteMapUrls).ToList();
        }
        public IEnumerable<MapSite> Get(Func<MapSite, bool> predicate)
        {
            return siteMapContext.MapSites.Include(m => m.SiteMapUrls).Where(predicate);
        }
        public void Remove(MapSite item)
        {
            siteMapContext.MapSites.Remove(item);
            siteMapContext.SaveChanges();
        }
        public void Update(MapSite item)
        {
            siteMapContext.Entry(item).State = EntityState.Modified;
            siteMapContext.SaveChanges();
        }
    }
}