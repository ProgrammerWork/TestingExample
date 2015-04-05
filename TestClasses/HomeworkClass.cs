namespace TestClasses
{
    public class HomeworkClass
    {
        public string[] DoSomething(string[] strings, string prefix = "", string postfix = "")
        {
            if (strings == null) {
                return null;
            }

            if (prefix == null) prefix = string.Empty;
            if (postfix == null) postfix = string.Empty;

            // get array with input array length
            var s = new string[2 * strings.Length];
            var effectivePrefix = prefix;
            var effectivePostfix = postfix;
            //if length of pre and postfixes are like this
            var sumLength = prefix.Length + postfix.Length;
            if (sumLength < 2)
            {
                effectivePrefix = postfix;
                effectivePostfix = prefix;
            }

            for (var i = 0; i < strings.Length; i++)
            {
                s[i] = "MySuffix" + effectivePrefix + strings[i].ToLower();
                s[strings.Length + i] = strings[i].ToLower() + "MySuffix" + effectivePostfix;
            }

            for (var i = strings.Length; i < s.Length; i++)
            {
                if (s[i].EndsWith("MySuffix") && effectivePostfix != "MySuffix")
                {
                    s[i - strings.Length] = s[i - strings.Length].Remove(0, "MySuffix".Length);
                }
            }
            return s;
        }
    }
}
