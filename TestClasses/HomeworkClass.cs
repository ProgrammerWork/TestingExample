namespace TestClasses
{
    public class HomeworkClass
    {
        public string[] DoSomething(string[] strings, string prefix, string postfix)
        {
            // get array with input array length
            var s = new string[2 * strings.Length];
            var effectivePrefix = prefix;
            var effectivePostfix = postfix;
            //if length of pre and postfixes are like this
            if (!(prefix.Length > 1 - postfix.Length))
            {
                effectivePrefix = postfix;
                effectivePostfix = prefix;
            }
            for (var i = 0; i < s.Length; i++)
            {
                s[i] = "MySuffix" + effectivePrefix + strings[i / 2].ToLower();
                s[2 * i] = strings[i / 2].ToLower() + "MySuffix" + effectivePostfix;
            }
            for (var i = strings.Length; i < s.Length; i++)
            {
                if (s[i].EndsWith("MySuffix") && effectivePostfix != "MySuffix")
                {
                    s[i - strings.Length] = s[i - strings.Length].Remove(0, 9);
                }
            }
            return s;
        }
    }
}
