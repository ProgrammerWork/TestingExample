using System;
namespace TestClasses
{
    public class HomeworkClass
    {
        public string[] DoSomething(string[] strings, string prefix = "", string postfix = "")
        {
            if (strings == null) return null;
            if (prefix == null) prefix = string.Empty;
            if (postfix == null) postfix = string.Empty;

            Tuple<string, string> fixes = SumLengthLessThen(prefix, postfix, 2) ?
                new Tuple<string, string>(postfix, prefix) :
                new Tuple<string, string>(prefix, postfix);

            var s = new string[2 * strings.Length];
            for (var i = 0; i < strings.Length; ++i)
            {
                if (strings[i] == null) {
                    throw new ArgumentException();
                }
                var current_string = strings[i].ToLower();
                s[i] = (fixes.Item2.Length == 0) ? string.Empty : MAGIC_WORD;
                s[i] += fixes.Item1 + current_string;
                s[strings.Length + i] = current_string + MAGIC_WORD + fixes.Item2;
            }
            return s;
        }

        private bool SumLengthLessThen(string str1, string str2, int maxVal)
        {
            return (str1.Length + str2.Length) < maxVal;
        }

        private const string MAGIC_WORD = "MySuffix";
    }
}
