namespace Beauty.Business
{
    public class Age
    {
        protected bool Equals(Age other)
        {
            return _ageValue == other._ageValue;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Age) obj);
        }

        public override int GetHashCode()
        {
            return _ageValue;
        }

        private readonly int _ageValue;

        private Age(int ageValue)
        {
            _ageValue = ageValue;
        }

        public static implicit operator Age(int weightValue)
        {
            return new Age(weightValue);
        }

        public static bool operator ==(Age firstArg, int secondArg)
        {
            return firstArg == (Age)secondArg;
        }

        public static bool operator ==(Age firstArg, Age secondArg)
        {
            return firstArg.Value == secondArg.Value;
        }

        public static bool operator !=(Age firstArg, Age secondArg)
        {
            return !(firstArg == secondArg);
        }

        public static bool operator !=(Age firstArg, int secondArg)
        {
            return !(firstArg == secondArg);
        }

        public int Value
        {
            get { return _ageValue; }
        }
    }
}