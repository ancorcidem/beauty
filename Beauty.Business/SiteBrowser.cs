using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using HtmlAgilityPack;

namespace Beauty.Business
{
    public class SiteBrowser : ISiteBrowser
    {
        private static readonly Uri BaseUri = new Uri("http://intimby.net/");

        private static readonly Uri ProfilesListUri = new Uri(BaseUri,
                                                              "cgi-bin/select.pl?Gender=any&Orientation=any&penpal=2&friendship=2&flirt=2&marriage=2&sponsor=2&money=2&City=0&newcity=&AgeMin=0&AgeMax=99&Social=any&Added=any&OrderBy=datepublished");

        public IEnumerable<BeautyProfile> Select(NameValueCollection queryParams)
        {
            var queryParamsPrototype = HttpUtility.ParseQueryString(ProfilesListUri.Query);
            foreach (var key in queryParams.AllKeys)
            {
                queryParamsPrototype[key] = queryParams[key];
            }

            var builder = new UriBuilder(ProfilesListUri) {Query = queryParamsPrototype.ToString()};

            var profileListPage = builder.Uri.GetHtmlDocument();

            var profileUrs = GetProfileUrls(profileListPage);
            var profiles = new List<BeautyProfile>();
            Parallel.ForEach(profileUrs, uri =>
                {
                    var profile = new BeautyProfile(uri.GetHtmlDocument());
                    lock (profiles)
                    {
                        profiles.Add(profile);
                    }
                });

            return profiles;
        }

        private IEnumerable<Uri> GetProfileUrls(HtmlDocument profileListPage)
        {
            var profileNodes = profileListPage.DocumentNode.SelectNodes("//td[@valign='TOP']//a[@target='_blank']");
            return profileNodes.Select(x => new Uri(BaseUri, x.Attributes["href"].Value)).ToArray();
        }
    }
}
