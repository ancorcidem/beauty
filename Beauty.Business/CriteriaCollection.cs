﻿using System.Collections.Generic;

namespace Beauty.Business
{
    public class CriteriaCollection
    {
        private readonly IBeautyRepository _beautyRepository;

        public CriteriaCollection(IBeautyRepository beautyRepository)
        {
            _beautyRepository = beautyRepository;
        }

        private readonly List<Criteria> _criterias =
            new List<Criteria>();

        public void Add(Criteria criteria)
        {
            _criterias.Add(criteria);
        }

        public IEnumerable<Beauty> Find()
        {
            return _beautyRepository.Find(_criterias);
        }
    }
}