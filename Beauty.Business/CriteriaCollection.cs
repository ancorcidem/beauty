using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Beauty.Business
{
    public class CriteriaCollection
    {
        private readonly IBeautyRepository _repository;

        public CriteriaCollection(IBeautyRepository repository)
        {
            _repository = repository;
        }

        private readonly List<Expression<Func<Beauty, bool>>> _criterias =
            new List<Expression<Func<Beauty, bool>>>();

        public void Add(Expression<Func<Beauty, bool>> expression)
        {
            _criterias.Add(expression);
        }

        public IEnumerable<Beauty> Find()
        {
            IQueryable<Beauty> queryable = _repository.Beauties;
            foreach (var criteria in _criterias)
            {
                queryable = queryable.Where(criteria);
            }

            return queryable.Select(beauty => beauty);
        }
    }
}