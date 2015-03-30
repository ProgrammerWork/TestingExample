using System.Linq;

namespace TestClasses
{
    public class MySecondClass
    {
   

        public IMyClass MyClass { get; set; }

        public string Transform(string attr)
        {
            var v = MyClass.MyUpperFunc(attr);
            return new string(v.Reverse().ToArray());
        }
    }
}
