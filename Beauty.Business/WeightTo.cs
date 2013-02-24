using System;
using System.Linq.Expressions;

namespace Beauty.Business
{
    public class WeightTo : Criteria
    {
        private readonly Weight _weight;

        private WeightTo(Weight weight)
        {
            _weight = weight;
        }

        public static implicit operator WeightTo(Weight weight)
        {
            return new WeightTo(weight);
        }

        protected override Expression<Func<Beauty, bool>> Expression
        {
            get { return beauty => beauty.Weight <= _weight.Value; }
        }
    }
}