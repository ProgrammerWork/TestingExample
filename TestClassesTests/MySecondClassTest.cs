using FluentAssertions;
using Moq;
using NUnit.Framework;
using TestClasses;

namespace TestClassesTests
{
    class TestMyClass : IMyClass
    {
        public string MyTrimmingFunc(string attr)
        {
            return default(string);
        }

        public string MyUpperFunc(string attr)
        {
            return default(string);
        }
    }

    public class MySecondClassTest
    {
        [TestCase("my string", "gnirts ym")]
        [TestCase("My", "yM")]
        public void Transform_RevertString_AnyString(string input, string expect)
        {
            //arrange
            var mySecondClass = new MySecondClass();
            var moq = new Mock<IMyClass>();
            moq.Setup(d => d.MyUpperFunc(It.IsAny<string>())).Returns<string>(str => str);
            mySecondClass.MyClass = moq.Object;

            //act
            var res = mySecondClass.Transform(input);

            //assert
            res.Should().Be(expect);
            moq.Verify((c)=>c.MyUpperFunc(It.IsAny<string>()), Times.Once());
        }

        [Test]
        public void Transform_CallsMyUpperFunc()
        {
            //arrange
            var input = "My";
            var expect = "yM";
            var mySecondClass = new MySecondClass();
            var moq = new Mock<IMyClass>();
            moq.Setup(d => d.MyUpperFunc(It.IsAny<string>())).Returns<string>(str => str);
            mySecondClass.MyClass = moq.Object;

            //act
            mySecondClass.Transform(input);

            //assert
            moq.Verify((c) => c.MyUpperFunc(input), Times.AtMostOnce());
        }
    }
}
