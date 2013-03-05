using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Beauty.Business
{
    public class BeautyRepository : IBeautyRepository
    {
        private readonly BeautySqlRepository _sqlRepository;
        private readonly BeautySiteRepository _siteRepository;

        public BeautyRepository(BeautySqlRepository sqlRepository, BeautySiteRepository siteRepository)
        {
            _sqlRepository = sqlRepository;
            _siteRepository = siteRepository;
        }

        public IEnumerable<Beauty> Find(IEnumerable<Criteria> criterias)
        {
            var result = new List<Beauty>();
            
            //result.AddRange(_siteRepository.Find(criterias));
            //_siteRepository.Find(criterias);
            return result;
        }
    }

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
            return beautiesFromSite.Select(x => (Beauty) x);
        }
    }
}