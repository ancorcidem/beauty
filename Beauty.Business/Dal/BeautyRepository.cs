using System;
using System.Collections.Generic;
using System.Linq;
using Beauty.Business.Criterias;
using StructureMap;

namespace Beauty.Business.Dal
{
    public class BeautyRepository : IBeautyFilter, IBeautyDataFeed
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
                _executionEngine.Execute(() => QuerySqlRepository(criterias));
                _executionEngine.Execute(() => QuerySiteRepository(criterias));
            }
        }

        private void QuerySqlRepository(IEnumerable<Criteria> criterias)
        {
            var result = _sqlRepository.Find(criterias);
            Found.Raise(this, new BeautyFoundEventArgs {Beauties = result.ToArray()});
        }

        private void QuerySiteRepository(IEnumerable<Criteria> filter)
        {
            var siteRepository = ObjectFactory.GetInstance<BeautySiteRepository>();
            var result = siteRepository.Find(filter);

            //IEnumerable<Beauty> resultFromStorage;
            //lock (_sqlRepository)
            //{
            //    resultFromStorage = _sqlRepository.Find(filter).ToArray();
            //}


            
            Found.Raise(this, new BeautyFoundEventArgs {Beauties = result.ToArray()});
        }

        public event EventHandler<BeautyFoundEventArgs> Found;
    }
}