using System;
using System.Globalization;
using System.Linq.Expressions;

namespace Beauty.Business.Criterias
{
    public class AgeFrom : Criteria
    {
        private readonly int _ageFromValue;

        public AgeFrom(int ageFromValue)
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

        public override string Value
        {
            get { return _ageFromValue.ToString(CultureInfo.InvariantCulture); }
        }

        public override string ParamName
        {
            get { return "AgeMin"; }
        }
    }
}