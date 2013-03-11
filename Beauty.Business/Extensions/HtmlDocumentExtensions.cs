using System;
using System.Collections.Generic;
using System.Linq;
using Beauty.Business.Dal;

namespace HtmlAgilityPack
{
    public static class HtmlDocumentExtensions
    {
        public static IEnumerable<Uri> GetProfileUrls(HtmlDocument profileListPage)
        {
            var profileNodes = profileListPage.DocumentNode.SelectNodes("//td[@valign='TOP']//a[@target='_blank']");
            return profileNodes.Select(x => new Uri(SiteBrowser.BaseUri, x.Attributes["href"].Value)).ToArray();
        }
    }
}