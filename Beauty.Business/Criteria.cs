using System;
using System.Linq;
using System.Linq.Expressions;

namespace Beauty.Business
{
    public abstract class Criteria
    {
        protected abstract Expression<Func<Beauty, bool>> Expression { get; }

        public IQueryable<Beauty> ApplyOn(IQueryable<Beauty> beauties)
        {
            return beauties.Where(Expression);
        }
    }
}