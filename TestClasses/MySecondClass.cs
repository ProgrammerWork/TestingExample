using System.Linq;

namespace TestClasses
{
    public class MySecondClass
    {
        public IMyAnotherClass MyAnotherClass { get; set; }

        public string Transform(string attr)
        {
            var v = MyAnotherClass.MyLowerFunc(attr);
            return new string(v.Reverse().ToArray());
        }
    }
}
