using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;

namespace SiteMapProg.Models
{
    public class TestSiteMap
    {
        public MapSite TestSites(IEnumerable<string> siteUrl, MapSite mapSite)
        {
            ICollection<SiteMapUrl> mapSiteUrlList = new List<SiteMapUrl>();
            SiteMapUrl siteMap = new SiteMapUrl();
            int i = 0;

            foreach (var item in siteUrl)
            {
                if (i < 20) //количество ссылок = 20
                {
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    HttpWebRequest HttpWReq = (HttpWebRequest)WebRequest.Create(item);
                    HttpWebResponse HttpWResp = (HttpWebResponse)HttpWReq.GetResponse();
                    HttpWResp.Close();
                    stopwatch.Stop();
                    TimeSpan ts = stopwatch.Elapsed;
                    mapSiteUrlList.Add(new SiteMapUrl {UrlSite=item, TimeOut= ts.Milliseconds });
                    i++;
                }
                else
                {
                    break;
                }
            }
            mapSite.SiteMapUrls = mapSiteUrlList;
            return mapSite;

        }
    }
}