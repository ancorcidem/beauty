using System;
using System.Globalization;
using System.Linq.Expressions;

namespace Beauty.Business.Criterias
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

        public override string Value
        {
            get { return _ageToValue.ToString(CultureInfo.InvariantCulture); }
        }

        public override string ParamName
        {
            get { return "AgeMax"; }
        }
    }
}