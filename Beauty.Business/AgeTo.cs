using System;
using System.Linq.Expressions;

namespace Beauty.Business
{
    public class AgeTo : Criteria
    {
        private readonly int _ageToValue;

        private AgeTo(int ageToValue)
        {
            _ageToValue = ageToValue;
        }

        public static implicit operator AgeTo(int ageToValue)
        {
            return new AgeTo(ageToValue);
        }

        protected override Expression<Func<Beauty, bool>> Expression
        {
            get { return beauty => beauty.Age <= _ageToValue; }
        }
    }
}