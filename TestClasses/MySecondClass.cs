using System.Linq;

namespace TestClasses
{
    public class MySecondClass
    {
        private IMyAnotherClass _mAC;

        public MySecondClass(IMyAnotherClass mAC)
        {
            _mAC = mAC;
        }

        public IMyClass MyClass { get; set; }

        public string Transform(string attr)
        {
            var v = MyClass.MyUpperFunc(attr);
            return new string(v.Reverse().ToArray());
        }
    }
}
