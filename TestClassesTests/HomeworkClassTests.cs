//using TestClasses;
//using NUnit.Framework;
//using FluentAssertions;

using System;
using FluentAssertions;
using NUnit.Framework;
using TestClasses;

namespace TestClassesTests
{
    public class HomeworkClassTests
    {
        [Test]
        public void TestHomeworkClassWithNullStringArray()
        {
            // arrange
            var homeworkClassInstance = new HomeworkClass();
            string[] inputStringArray = null;
            string prefix = null;
            string postfix = null;
            
            // act
            var postProcessingStringArray = homeworkClassInstance.DoSomething(inputStringArray, prefix, postfix);
            
            // assert
            postProcessingStringArray.Should().BeNull();
        }

        [Test]
        public void TestHomeworkClassArrayHasOneEmptyStringAndOtherNullParams()
        {
            // arrange
            var homeworkClassInstance = new HomeworkClass();
            string[] inputStringArray = {""};
            string prefix = null;
            string postfix = null;

            // act
            var postProcessingStringArray = homeworkClassInstance.DoSomething(inputStringArray, prefix, postfix);

            // assert
            string[] expectationStringArray = { "", "MySuffix" };
            postProcessingStringArray.Should().HaveCount(2).And.BeEquivalentTo(expectationStringArray);
        }

        [Test]
        public void TestHomeworkClassArrayHasFewStringsAndOtherNullParams()
        {
            // arrange
            var homeworkClassInstance = new HomeworkClass();
            string[] inputStringArray = { "First ARRay liNe", "sEConD arraY LIne" };
            string prefix = null;
            string postfix = null;

            // act
            var postProcessingStringArray = homeworkClassInstance.DoSomething(inputStringArray, prefix, postfix);

            // assert
            
            string[] expectationStringArray = { "first array line",
                                                "second array line",
                                                "first array lineMySuffix",
                                                "second array lineMySuffix" };
            postProcessingStringArray.Should().HaveCount(4).And.BeEquivalentTo(expectationStringArray);
        }

        string[][] inputStringData = new [] {
                    new [] { "one string" },
                    new [] { "one", "two string"},
                    new [] { "1", "two", "line", "another line", "and another.." },
                    new [] { "1", "2", "", "4", " ", "6", "7.."}
                                       };
        [TestCaseSource("inputStringData")]
        public void TestHomeworkClassArrayCheckOutputArraySize(string[] inputStringArray)
        {
            // arrange
            var homeworkClassInstance = new HomeworkClass();
            string prefix = null;
            string postfix = null;

            // act
            var postProcessingStringArray = homeworkClassInstance.DoSomething(inputStringArray, prefix, postfix);

            // assert
            postProcessingStringArray.Should().HaveCount(2 * inputStringArray.Length);
        }

        [Test]
        public void TestHomeworkClassArrayHasFewStringWithShortPrefixSwapPostfix()
        {
            // arrange
            var homeworkClassInstance = new HomeworkClass();
            string[] inputStringArray = { "First ARRay liNe", "sEConD arraY LIne" };
            string prefix = "a";
            string postfix = null;

            // act
            var postProcessingStringArray = homeworkClassInstance.DoSomething(inputStringArray, prefix, postfix);

            // assert
            string[] expectationStringArray = { "MySuffixfirst array line",
                                                "MySuffixsecond array line",
                                                "first array lineMySuffixa",
                                                "second array lineMySuffixa" };
            postProcessingStringArray.Should().HaveCount(4).And.BeEquivalentTo(expectationStringArray);
        }

        [Test]
        public void TestHomeworkClassArrayHasFewStringWithShortPostfixSwapPrefix()
        {
            // arrange
            var homeworkClassInstance = new HomeworkClass();
            string[] inputStringArray = { "First ARRay liNe", "sEConD arraY LIne" };
            string prefix = null;
            string postfix = "b";

            // act
            var postProcessingStringArray = homeworkClassInstance.DoSomething(inputStringArray, prefix, postfix);

            // assert
            string[] expectationStringArray = { "bfirst array line",
                                                "bsecond array line",
                                                "first array lineMySuffix",
                                                "second array lineMySuffix" };
            postProcessingStringArray.Should().HaveCount(4).And.BeEquivalentTo(expectationStringArray);
        }

        [Test]
        public void TestHomeworkClassArrayHasFewStringWithPrefixAndPostfix()
        {
            // arrange
            var homeworkClassInstance = new HomeworkClass();
            string[] inputStringArray = { "First ARRay liNe", 
                                          "sEConD arraY LIne",
                                          "3rd LINE"};
            string prefix = "aa";
            string postfix = "bb";

            // act
            var postProcessingStringArray = homeworkClassInstance.DoSomething(inputStringArray, prefix, postfix);

            // assert
            string[] expectationStringArray = { "MySuffixaafirst array line",
                                                "MySuffixaasecond array line",
                                                "MySuffixaa3rd line",
                                                "first array lineMySuffixbb",
                                                "second array lineMySuffixbb",
                                                "3rd lineMySuffixbb"};
            postProcessingStringArray.Should().HaveCount(6).And.BeEquivalentTo(expectationStringArray);
        }

        [Test]
        public void TestHomeworkClassArrayHasFewStringWithPrefixAndPostfixLikeMagicWord()
        {
            // arrange
            var homeworkClassInstance = new HomeworkClass();
            string[] inputStringArray = { "First ARRay liNe", 
                                          "sEConD arraY LIne",
                                          "3rd LINE"};
            string prefix = "aa";
            string postfix = "MySuffix";

            // act
            var postProcessingStringArray = homeworkClassInstance.DoSomething(inputStringArray, prefix, postfix);

            // assert
            string[] expectationStringArray = { "MySuffixaafirst array line",
                                                "MySuffixaasecond array line",
                                                "MySuffixaa3rd line",
                                                "first array lineMySuffixMySuffix",
                                                "second array lineMySuffixMySuffix",
                                                "3rd lineMySuffixMySuffix"};
            postProcessingStringArray.Should().HaveCount(6).And.BeEquivalentTo(expectationStringArray);
        }
    }
}
