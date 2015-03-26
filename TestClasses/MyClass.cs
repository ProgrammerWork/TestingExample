using System;

namespace TestClasses
{
    public class MyClass : IMyClass
    {
        public string MyTrimmingFunc(string attr)
        {
            //guardian if
            if (attr == null)
            {
                throw new ArgumentNullException();
            }
            return attr.Trim();
        }

        public string MyUpperFunc(string attr)
        {
            return attr.ToUpper();
        }
    }
}
