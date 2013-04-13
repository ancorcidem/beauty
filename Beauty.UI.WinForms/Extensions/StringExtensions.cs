namespace System
{
    public static class StringExtensions
    {
        public static void ParseToIntAndStoreTo(this string valueToParse, Action<int> setAction)
        {
            int result;
            if (int.TryParse(valueToParse, out result))
            {
                setAction(result);
            }
        }
    }
}