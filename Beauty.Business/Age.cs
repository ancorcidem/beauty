namespace Beauty.Business
{
    public class Age
    {
        private readonly int _weightValue;

        private Age(int weightValue)
        {
            _weightValue = weightValue;
        }

        public static implicit operator Age(int weightValue)
        {
            return new Age(weightValue);
        }

        public int Value
        {
            get { return _weightValue; }
        }
    }
}