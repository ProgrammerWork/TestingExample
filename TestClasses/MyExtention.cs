using System.Collections.Generic;
using System.Linq;

namespace TestClasses
{
    public static class MyExtention
    {
        public static IOrderedEnumerable<string> SortByLengthWithFlag(this IEnumerable<string> s, bool ascending)
        {
            return ascending
                ? s.OrderBy(str => str.Length)
                : s.OrderByDescending(str => str.Length);
        }

        public static IEnumerable<string> ChangeCaseWithFlag(this IEnumerable<string> strings, bool toLower)
        {
            return strings.Select(str => toLower ? str.ToLower() : str.ToUpper());
        }
    }
}