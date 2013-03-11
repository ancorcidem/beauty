using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading.Tasks;
using System.Web;
using HtmlAgilityPack;

namespace Beauty.Business.Dal
{
    public class SiteBrowser : ISiteBrowser
    {
        internal static readonly Uri BaseUri = new Uri("http://intimby.net/");

        private static readonly Uri ProfilesListUri = new Uri(BaseUri,
                                                              "cgi-bin/select.pl?Gender=any&Orientation=any&penpal=2&friendship=2&flirt=2&marriage=2&sponsor=2&money=2&City=0&newcity=&AgeMin=0&AgeMax=99&Social=any&Added=any&OrderBy=datepublished&Start=0");

        public IEnumerable<BeautyProfile> Select(NameValueCollection queryParams)
        {
            var queryParamsPrototype = HttpUtility.ParseQueryString(ProfilesListUri.Query);
            foreach (var key in queryParams.AllKeys)
            {
                queryParamsPrototype[key] = queryParams[key];
            }

            var builder = new UriBuilder(ProfilesListUri) {Query = queryParamsPrototype.ToString()};

            var profileListPage = builder.Uri.GetHtmlDocument();

            var profileUrs = HtmlDocumentExtensions.GetProfileUrls(profileListPage);
            var profiles = new List<BeautyProfile>();
            Parallel.ForEach(profileUrs, uri =>
                {
                    var profile = new BeautyProfile(uri.GetHtmlDocument(), uri);
                    lock (profiles)
                    {
                        profiles.Add(profile);
                    }
                });

            return profiles;
        }
    }
}