using System;
using NUnit.Framework;
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
            Assert.AreEqual(myAttrForTest, result);
        }

        [Test]
        public void MyTrimFunc_TrimsTrailingSpaces_ForInputWithTrailingSpaces()
        {
            //arrange
            var input = "I am input with trailing space";
            var inputWithTrailingSpaces = input + " ";

            //act
            var res = new MyClass().MyTrimmingFunc(inputWithTrailingSpaces);

            Assert.AreEqual(input, res);
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
            Assert.AreEqual(input, res);
        }

        [Test]
        public void MyTrimFunc_TrimsAllSpaces_ThenThereAreSpacesOnBothSides()
        {
            var input = "My input";
            var testInput = " " + input + " ";

            var res = new MyClass().MyTrimmingFunc(testInput);
            
            Assert.AreEqual(input, res);
        }

        [Test]
        public void MyTrimFunc_FiresArgumentNullException_OnNullInput()
        {
            string input = null;

            TestDelegate action = () => new MyClass().MyTrimmingFunc(input);

            Assert.Throws<ArgumentNullException>(action);
        }
    }
}
