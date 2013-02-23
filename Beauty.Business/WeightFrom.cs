using System;
using System.Linq.Expressions;

namespace Beauty.Business
{
    public class WeightFrom : Criteria
    {
        private readonly Weight _weight;

        private WeightFrom(Weight weight)
        {
            _weight = weight;
        }

        public static implicit operator WeightFrom(Weight weightFromValue)
        {
            return new WeightFrom(weightFromValue);
        }
        protected override Expression<Func<Beauty, bool>> Expression
        {
            get { return beauty => beauty.Weight >= _weight.Value; }
        }
    }
}