using System.Linq;

namespace System
{
    public static class StringTransformationExtensions
    {
        public static T[] ToArrayOf<T>(this string arg)
        {
            return arg.Split(',').Select(x => Convert.ChangeType(x.Trim(), typeof (T))).Cast<T>().ToArray();
        }
    }
}