using System.Collections.Generic;
using System.Linq;
using Beauty.Business;
using Beauty.Business.Criterias;
using Rhino.Mocks;

namespace Beauty.UI.Specs
{
    public class BeautyFilterStub : IBeautyFilter
    {
        private readonly BeautyMockRepository _beautyMockRepository;
        private readonly IBeautyDataFeed _dataFeedStub;
        private IEnumerable<Criteria> _filter;

        public BeautyFilterStub(BeautyMockRepository beautyMockRepository, IBeautyDataFeed dataFeedStub)
        {
            _beautyMockRepository = beautyMockRepository;
            _dataFeedStub = dataFeedStub;
        }

        public IEnumerable<Criteria> Filter
        {
            get { return _filter; }

            set
            {
                _filter = value;
                var result = _beautyMockRepository.Find(Filter);
                _dataFeedStub.Raise(eventSubscription: dataFeed => dataFeed.Found += null, sender: _dataFeedStub,
                                    args: new BeautyFoundEventArgs {Beauties = result.ToArray(), Criterias = Filter.ToArray()});
            }
        }
    }
}