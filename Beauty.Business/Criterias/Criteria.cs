using System;
using System.Collections.Specialized;
using System.Linq;
using System.Linq.Expressions;
using Beauty.Business.Dal;

namespace Beauty.Business.Criterias
{
    public abstract class Criteria : IUrlEmbeddedCriteria
    {
        protected abstract Expression<Func<Beauty, bool>> Expression { get; }

        public IQueryable<Beauty> ApplyOn(IQueryable<Beauty> beauties)
        {
            return beauties.Where(Expression);
        }

        public NameValueCollection ApplyOn(NameValueCollection queryParams)
        {
            queryParams[ParamName] = Value;
            return queryParams;
        }

        public abstract string Value { get; }

        public abstract string ParamName { get; }
    }
}