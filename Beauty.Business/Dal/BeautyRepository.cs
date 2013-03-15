using System.Collections.Generic;
using Beauty.Business.Criterias;
using StructureMap;

namespace Beauty.Business.Dal
{
    public class BeautyRepository : IBeautyFilter
    {
        private readonly IExecutionEngine _executionEngine;
        private readonly BeautySqlRepository _sqlRepository;
        private readonly List<Criteria> _filter = new List<Criteria>();

        public BeautyRepository(IExecutionEngine executionEngine, BeautySqlRepository sqlRepository)
        {
            _executionEngine = executionEngine;
            _sqlRepository = sqlRepository;
        }

        IEnumerable<Criteria> IBeautyFilter.Filter
        {
            get { return _filter.ToArray(); }
            set
            {
                _filter.Clear();
                _filter.AddRange(value);

                var criterias = _filter.ToArray();
                _executionEngine.Execute(() => _sqlRepository.Find(criterias));
                //_executionEngine.Execute(() => QuerySiteRepository(criterias));
            }
        }

        private void QuerySiteRepository(IEnumerable<Criteria> filter)
        {
            var siteRepository = ObjectFactory.GetInstance<BeautySiteRepository>();

            siteRepository.Find(filter);
        }
    }
}