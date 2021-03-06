﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace SiteMapProg.Models
{
    public class SiteMapDoc
    {
        public IEnumerable<string> ParseSitemapFile(string nameSite)
        {
            IList<string> listSite = new List<string>();
            XmlDocument rssXmlDoc = new XmlDocument();
            string fullUrl = nameSite + "/sitemap.xml";
            try
            {
                rssXmlDoc.Load(fullUrl);
                if (rssXmlDoc == null)
                {
                    throw new Exception("Не правильный адресс сайта");
                }

                foreach (XmlNode topNode in rssXmlDoc.ChildNodes)
                {
                    if (topNode.Name.ToLower() == "urlset")
                    {
                        XmlNamespaceManager nsmgr = new XmlNamespaceManager(rssXmlDoc.NameTable);
                        nsmgr.AddNamespace("ns", topNode.NamespaceURI);

                        XmlNodeList urlNodes = topNode.ChildNodes;
                        foreach (XmlNode urlNode in urlNodes)
                        {
                            XmlNode locNode = urlNode.SelectSingleNode("ns:loc", nsmgr);
                            string link = locNode != null ? locNode.InnerText : "";
                            listSite.Add(link);
                        }
                    }
                    if (topNode.Name.ToLower() == "sitemapindex")
                    {
                        XmlNamespaceManager nsmgr = new XmlNamespaceManager(rssXmlDoc.NameTable);
                        nsmgr.AddNamespace("ns", topNode.NamespaceURI);

                        XmlNodeList urlNodes = topNode.ChildNodes;
                        foreach (XmlNode urlNode in urlNodes)
                        {
                            XmlNode locNode = urlNode.SelectSingleNode("ns:loc", nsmgr);
                            string link = locNode != null ? locNode.InnerText : "";
                            listSite.Add(link);
                        }
                        listSite = ParseSitemapIndex(listSite);
                    }
                }
                return listSite;
            }
            catch (Exception)
            {
                throw new Exception("Отсутсвует карта сайта");
            }

        }
        private IList<string> ParseSitemapIndex(IList<string> sitemapIndex)
        {
            IList<string> listSite = new List<string>();
            XmlDocument rssXmlDoc = new XmlDocument();
            int j = 0;
            foreach (var url in sitemapIndex)
            {
                if (j==1)
                {
                    break;
                }
                rssXmlDoc.Load(url);
                foreach (XmlNode topNode in rssXmlDoc.ChildNodes)
                {
                    if (topNode.Name.ToLower() == "urlset")
                    {
                        XmlNamespaceManager nsmgr = new XmlNamespaceManager(rssXmlDoc.NameTable);
                        nsmgr.AddNamespace("ns", topNode.NamespaceURI);

                        XmlNodeList urlNodes = topNode.ChildNodes;

                        foreach (XmlNode urlNode in urlNodes)
                        {
                                XmlNode locNode = urlNode.SelectSingleNode("ns:loc", nsmgr);
                                string link = locNode != null ? locNode.InnerText : "";
                                listSite.Add(link);
                        }
                    }
                }
                j++;
            }

            return listSite;
        }
    }
}