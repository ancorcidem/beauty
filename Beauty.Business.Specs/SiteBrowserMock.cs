using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Beauty.Business.Dal;
using Beauty.Specs.Common;
using StructureMap;

namespace Beauty.Business.Specs
{
    public class SiteBrowserMock : ISiteBrowser
    {
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

            return result;
        }

        public void RegisterBeauty(Age age)
        {
            var factory = ObjectFactory.GetInstance<BeautyFactory>();
            _profiles.Add(factory.CreateHtml(age));
        }
    }
}