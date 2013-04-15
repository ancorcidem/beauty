using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Beauty.Business.Dal;
using Beauty.Business.ServiceBus;
using Beauty.Specs.Common;
using StructureMap;

namespace Beauty.Business
{
    public class SiteBrowserMock : ISiteBrowser
    {
        private readonly IBus _bus;
        private readonly List<BeautyProfile> _profiles = new List<BeautyProfile>();

        public SiteBrowserMock(IBus bus)
        {
            _bus = bus;
        }

        public void Select(NameValueCollection queryParams)
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
            foreach (var profile in result)
            {
                _bus.Publish(new BeautyProfileFoundMessage {Profile = profile});
            }
        }

        public void RegisterBeauty(Age age)
        {
            _profiles.Add(BeautyFactory.CreateHtml(age));
        }

        private static BeautyFactory BeautyFactory
        {
            get { return ObjectFactory.GetInstance<BeautyFactory>(); }
        }

        public void Register(IEnumerable<Beauty> beauties)
        {
            _profiles.AddRange(beauties.Select(x => BeautyFactory.CreateHtml(x)));
        }
    }
}