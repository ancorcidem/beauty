using System;
using System.Net;
using HtmlAgilityPack;
using StructureMap;

namespace Beauty.Business.Dal
{
    public static class UriExtensions
    {
        public static HtmlDocument GetHtmlDocument(this Uri address)
        {
            var webClient = new WebClient();

            var profileListPage = new HtmlDocument();
            string profileListPageContent = webClient.DownloadString(address);
            profileListPage.LoadHtml(profileListPageContent);
            return profileListPage;
        }

        public static byte[] DownloadImage(this Uri address)
        {
            return ObjectFactory.GetInstance<IImageDownloader>().Download(address);
        }
    }
}