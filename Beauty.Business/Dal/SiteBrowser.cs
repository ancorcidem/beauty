using System;
using System.Collections.Specialized;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using Beauty.Business.ServiceBus;
using Common.Logging;
using HtmlAgilityPack;

namespace Beauty.Business.Dal
{
    public class SiteBrowser : ISiteBrowser
    {
        private readonly IBus _bus;
        internal static readonly Uri BaseUri = new Uri("http://intimby.net/");

        private static readonly Uri ProfilesListUri = new Uri(BaseUri,
                                                              "cgi-bin/select.pl?Gender=any&Orientation=any&penpal=2&friendship=2&flirt=2&marriage=2&sponsor=2&money=2&City=0&newcity=&AgeMin=0&AgeMax=99&Social=any&Added=any&OrderBy=datepublished&Start=0");

        public SiteBrowser(IBus bus)
        {
            _bus = bus;
        }

        public void Select(NameValueCollection queryParams)
        {
            var queryParamsPrototype = HttpUtility.ParseQueryString(ProfilesListUri.Query);
            foreach (var key in queryParams.AllKeys)
            {
                queryParamsPrototype[key] = queryParams[key];
            }

            var builder = new UriBuilder(ProfilesListUri) {Query = queryParamsPrototype.ToString()};

            var profileListPage = builder.Uri.GetHtmlDocument();

            var profileUrs = HtmlDocumentExtensions.GetProfileUrls(profileListPage);
            Parallel.ForEach(profileUrs, uri =>
                {
                    try
                    {
                        var profile = new BeautyProfile(uri.GetHtmlDocument(), uri);
                        _bus.Publish(new BeautyProfileFoundMessage {Profile = profile});
                    }
                    catch (WebException exception)
                    {
                        var logger = LogManager.GetLogger<SiteBrowser>();
                        logger.Error(exception);
                    }
                });
        }
    }
}