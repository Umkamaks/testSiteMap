using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace SiteMapProg.Models
{

    public class SiteMapUrl
    {
        public int Id { get; set; }
        public string UrlSite { get; set; }
        public int TimeOut { get; set; }
        public int? MapSiteId { get;set;}
        [ScriptIgnore]
        public  MapSite MapSite { get; set; }
    }
}
