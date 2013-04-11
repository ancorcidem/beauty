using System;
using System.Collections.Generic;
using Beauty.Business;
using Beauty.Business.Criterias;

namespace Beauty.UI.Specs
{
    public class BeautyFilterStub : IBeautyFilter
    {
        private readonly BeautyMockRepository _beautyMockRepository;
        private IEnumerable<Criteria> _filter;

        public BeautyFilterStub(BeautyMockRepository beautyMockRepository)
        {
            _beautyMockRepository = beautyMockRepository;
        }

        public IEnumerable<Criteria> Filter
        {
            get { return _filter; }

            set
            {
                _filter = value;
                Changed.Raise(this, new FilterChangeEventArgs(value));
                _beautyMockRepository.Find(Filter);
            }
        }

        public event EventHandler<FilterChangeEventArgs> Changed;
    }
}