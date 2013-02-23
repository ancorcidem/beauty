using System;
using System.Linq.Expressions;

namespace Beauty.Business
{
    public class AgeFrom : Criteria
    {
        private readonly int _ageFromValue;

        private AgeFrom(int ageFromValue)
        {
            _ageFromValue = ageFromValue;
        }


        public static implicit operator AgeFrom(int ageFromValue)
        {
            return new AgeFrom(ageFromValue);
        }

        protected override Expression<Func<Beauty, bool>> Expression
        {
            get { return beauty => beauty.Age >= _ageFromValue; }
        }

    }
}