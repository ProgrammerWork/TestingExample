using System;
using Funq;
using TestClasses;

namespace TestingExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new Container();

            //resolve deps from IMyClass as new MyClass()
            container.RegisterAutoWiredAs<MyClass, IMyClass>();

            container.RegisterAutoWiredAs<MyAnotherClass, IMyAnotherClass>();

            //store MySecondClass with Dependencies injected
            container.RegisterAutoWired<MySecondClass>();

            //return stored instance of MySecondClass
            var mSC = container.Resolve<MySecondClass>();

            Console.WriteLine(mSC.Transform("I am awesome!"));
            Console.ReadLine();
        }
    }
}
