using System;
using System.Collections.Generic;
using System.Linq;

namespace TestClasses
{
    public class HomeworkClass
    {
        private int _counter = 0;

        public string[] DoSomething(string[] strings, string prefix = "", string postfix = "")
        {
            if (strings == null)
                return null;
            if (strings.Any(str => str == null))
                throw new ArgumentException();            

            var fixes = GetOrderedFixes(prefix, postfix);

            var lowerStrings = strings.Select(str => str.ToLower()).ToList();

            var firstArray = lowerStrings.Select(str => ((fixes.Item2.Length == 0) ? string.Empty : MAGIC_WORD) + fixes.Item1 + str);
            var secondArray = lowerStrings.Select(str => str + MAGIC_WORD + fixes.Item2);            
            return firstArray.Union(secondArray).ToArray();
        }

        private Tuple<string, string> GetOrderedFixes(string prefix, string postfix)
        {
            if (prefix == null) prefix = string.Empty;
            if (postfix == null) postfix = string.Empty;
            return ShouldKeepPrefixPostfix(prefix, postfix) ?
                new Tuple<string, string>(prefix, postfix) :
                new Tuple<string, string>(postfix, prefix);
        }

        private bool ShouldKeepPrefixPostfix(string prefix, string postfix)
        {
            return SumLengthGreaterOrEqualThan(prefix, postfix, 2);
        }

        private bool SumLengthGreaterOrEqualThan(string str1, string str2, int maxVal)
        {
            return (str1.Length + str2.Length) >= maxVal;
        }

        private const string MAGIC_WORD = "MySuffix";
    }
}
