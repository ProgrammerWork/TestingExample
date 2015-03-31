using System;
using NUnit.Framework;
using FluentAssertions;
using TestClasses;

namespace TestClassesTests
{
    public class MyClassTest
    {
        [Test]
        public void MyTrimFunc_ReturnsTheSame_ThenThereAreNoSpacesAtEnds()
        {
            //arrange
            var classEntity = new MyClass();
            const string myAttrForTest = "I am attr";

            //act
            var result = classEntity.MyTrimmingFunc(myAttrForTest);

            //assert
            result.Should().Be(myAttrForTest);
            //Assert.AreEqual(myAttrForTest, result);
        }

        [Test]
        public void MyTrimFunc_TrimsTrailingSpaces_ForInputWithTrailingSpaces()
        {
            //arrange
            var input = "I am input with trailing space";
            var inputWithTrailingSpaces = input + " ";

            //act
            var res = new MyClass().MyTrimmingFunc(inputWithTrailingSpaces);

            //Assert.AreEqual(input, res);
            res.Should().StartWith("I am").And.EndWith("trailing space");
        }

        [Test]
        public void MyTrimFunc_TrimsBeginningSpaces_ThenThereAreSome()
        {
            //arrange
            var input = "I am input for your test";
            var inputWithBeginningSpaces = " " + input;

            //act
            var res = new MyClass().MyTrimmingFunc(inputWithBeginningSpaces);

            //assert
            //Assert.AreEqual(input, res);
            res.Should().BeOfType<string>().And.Equals(input);
        }

        [Test]
        public void MyTrimFunc_TrimsAllSpaces_ThenThereAreSpacesOnBothSides()
        {
            var input = "My input";
            var testInput = " " + input + " ";

            var res = new MyClass().MyTrimmingFunc(testInput);
            
            //Assert.AreEqual(input, res);
            res.Should().HaveLength(input.Length, "expected this string length");
        }

        [Test]
        public void MyTrimFunc_FiresArgumentNullException_OnNullInput()
        {
            string input = null;

            Action action = () => new MyClass().MyTrimmingFunc(input);

            action.ShouldThrow<ArgumentNullException>();
           // Assert.Throws<ArgumentNullException>(action);
        }
    }
}
