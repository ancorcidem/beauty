namespace Beauty.Business
{
    public class Weight
    {
        private readonly int _weightValue;

        private Weight(int weightValue)
        {
            _weightValue = weightValue;
        }

        public static implicit operator Weight(int weightValue)
        {
            return new Weight(weightValue);
        }

        public int Value
        {
            get { return _weightValue; }
        }
    }
}