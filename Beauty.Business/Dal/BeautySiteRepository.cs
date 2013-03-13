using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Beauty.Business.Criterias;

namespace Beauty.Business.Dal
{
    public class BeautySiteRepository : IBeautyRepository
    {
        private readonly ISiteBrowser _browser;

        public BeautySiteRepository(ISiteBrowser browser)
        {
            _browser = browser;
        }

        public IEnumerable<Beauty> Find(IEnumerable<Criteria> criterias)
        {
            var nameValueCollection = HttpUtility.ParseQueryString(string.Empty);
            criterias.ToList().ForEach(x => x.ApplyOn(nameValueCollection));

            var beautiesFromSite = _browser.Select(nameValueCollection);
            
            return beautiesFromSite.Select(Mapper.Map<BeautyProfile, Beauty>);
        }
    }
}