namespace TestClasses
{
    static public class StringUtils
    {
        static public void SwapStrings(ref string str1, ref string str2)
        {
            string buffStr = str1;
            str1 = str2;
            str2 = buffStr;
        }
    }

    public class HomeworkClass
    {
        public string[] DoSomething(string[] strings, string prefix = "", string postfix = "")
        {
            if (strings == null) return null;
            if (prefix == null) prefix = string.Empty;
            if (postfix == null) postfix = string.Empty;

            if (prefix.Length + postfix.Length < 2)
            {
                StringUtils.SwapStrings(ref prefix, ref postfix);
            }

            var s = new string[2 * strings.Length];
            for (var i = 0; i < strings.Length; ++i)
            {
                var current_string = strings[i].ToLower();
                s[i] = (postfix.Length == 0) ? string.Empty : MAGIC_WORD;
                s[i] += prefix + current_string;
                s[strings.Length + i] = current_string + MAGIC_WORD + postfix;
            }
            return s;
        }

        private const string MAGIC_WORD = "MySuffix";
    }
}
