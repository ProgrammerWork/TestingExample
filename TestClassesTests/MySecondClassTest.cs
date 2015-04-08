using FluentAssertions;
using Moq;
using NUnit.Framework;
using TestClasses;

namespace TestClassesTests
{
    public class MySecondClassTest
    {
        [TestCase("my string", "gnirts ym")]
        [TestCase("My", "yM")]
        public void Transform_RevertString_AnyString(string input, string expect)
        {
            //arrange
            var mySecondClass = new MySecondClass();
            var moq = new Mock<IMyAnotherClass>();
            moq.Setup(d => d.MyLowerFunc(It.IsAny<string>())).Returns<string>(str => str);
            mySecondClass.MyAnotherClass = moq.Object;

            //act
            var res = mySecondClass.Transform(input);

            //assert
            res.Should().Be(expect);
            moq.Verify((c) => c.MyLowerFunc(It.IsAny<string>()), Times.Once());
        }

        [Test]
        public void Transform_CallsMyUpperFunc()
        {
            //arrange
            var input = "My";
            var mySecondClass = new MySecondClass();
            var moq = new Mock<IMyAnotherClass>();
            moq.Setup(d => d.MyLowerFunc(It.IsAny<string>())).Returns<string>(str => str);
            mySecondClass.MyAnotherClass = moq.Object;

            //act
            mySecondClass.Transform(input);

            //assert
            moq.Verify((c) => c.MyLowerFunc(input), Times.AtMostOnce());
        }
    }
}
