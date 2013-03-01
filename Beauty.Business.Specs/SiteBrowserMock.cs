using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using StructureMap;

namespace Beauty.Business.Specs
{
    public class SiteBrowserMock : ISiteBrowser
    {
        //private static read only Uri BaseUrl = new Uri("http://intimby.net/cgi-bin/select.pl");
        private readonly List<BeautyProfile> _profiles = new List<BeautyProfile>();

        public IEnumerable<BeautyProfile> Select(NameValueCollection queryParams)
        {
            var ageMinParam = queryParams["AgeMin"];
            var result = Enumerable.Empty<BeautyProfile>();
            if (!string.IsNullOrEmpty(ageMinParam))
            {
                result = _profiles.Where(x => x.Age >= int.Parse(ageMinParam));
            }

            var ageMaxParam = queryParams["AgeMax"];
            if (!string.IsNullOrEmpty(ageMaxParam))
            {
                result = result.Where(x => x.Age <= int.Parse(ageMaxParam));
            }

            //http://intimby.net/cgi-bin/select.pl?Gender=any&Orientation=any&penpal=2&friendship=2&flirt=2&marriage=2&sponsor=2&money=2&City=0&newcity=&AgeMin=0&AgeMax=99&Social=any&Added=any&OrderBy=datepublished
            //url
            //var uri = new Uri(url);
            //var parameters = HttpUtility.ParseQueryString(uri.Query);
            //var ageFrom = parameters["AgeFrom"]

            return result;
        }

        public void RegisterBeauty(Age age)
        {
            var factory = ObjectFactory.GetInstance<BeautyFactory>();
            _profiles.Add(factory.CreateHtml(age));
        }
    }
}