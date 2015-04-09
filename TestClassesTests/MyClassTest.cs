using System;
using FluentAssertions;
using NUnit.Framework;
using TestClasses;

namespace TestClassesTests
{
    //public class MyClassTest
    //{
    //    [Test]
    //    public void MyTrimFunc_ReturnsTheSame_ThenThereAreNoSpacesAtEnds()
    //    {
    //        //arrange
    //        var classEntity = new MyClass();
    //        const string myAttrForTest = "I am attr";

    //        //act
    //        var result = classEntity.MyTrimmingFunc(myAttrForTest);

    //        //assert
    //        result.Should().Be(myAttrForTest);
    //    }

    //    [Test]
    //    public void MyTrimFunc_TrimsTrailingSpaces_ForInputWithTrailingSpaces()
    //    {
    //        //arrange
    //        const string input = "I am input with trailing space";
    //        const string inputWithTrailingSpaces = input + " ";
    //        var res = new MyClass().MyTrimmingFunc(inputWithTrailingSpaces);
    //        res.Should().Be(input);
    //    }

    //    [Test]
    //    public void MyTrimFunc_TrimsBeginningSpaces_ThenThereAreSome()
    //    {
    //        //arrange
    //        var input = "I am input for your test";
    //        var inputWithBeginningSpaces = " " + input;

    //        //act
    //        var res = new MyClass().MyTrimmingFunc(inputWithBeginningSpaces);

    //        //assert
    //        res.Should().Be(input);
    //    }

    //    [TestCase("My input")]
    //    [TestCase("My second input")]
    //    public void MyTrimFunc_TrimsAllSpaces_ThenThereAreSpacesOnBothSides(string input)
    //    {
    //        //var input = "My input";
    //        var testInput = " " + input + " ";

    //        var res = new MyClass().MyTrimmingFunc(testInput);

    //        res.Should().Be(input);
    //    }

    //    [Test]
    //    public void MyTrimFunc_FiresArgumentNullException_OnNullInput()
    //    {
    //        string input = null;

    //        Action action = () => new MyClass().MyTrimmingFunc(input);

    //        action.ShouldThrow<ArgumentNullException>();
    //    }
    //}
}
