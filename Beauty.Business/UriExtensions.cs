﻿using System.Net;
using HtmlAgilityPack;

namespace System
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
    }
}