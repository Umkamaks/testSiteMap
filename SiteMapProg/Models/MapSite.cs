using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteMapProg.Models
{

    public class MapSite
    {
        public int Id { get; set; }
        public string NameSite { get; set; }
        public ICollection<SiteMapUrl> SiteMapUrls { get; set; }

        public MapSite()
        {
            SiteMapUrls = new List<SiteMapUrl>();
        }
    }
}