using System;

namespace TestClasses
{
    public class MyClass
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
    }
}
