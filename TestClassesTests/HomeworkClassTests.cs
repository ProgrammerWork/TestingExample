using System;
using FluentAssertions;
using NUnit.Framework;
using TestClasses;

namespace TestClassesTests
{
    public class HomeworkClassTests
    {
        private HomeworkClass homeworkClassInstance = new HomeworkClass();

        [Test]
        public void HomeworkClass_ReturnNull_ForNullInput()
        {
            // arrange
            string[] inputStringArray = null;
            // act
            var postProcessingStringArray = homeworkClassInstance.DoSomething(inputStringArray);
            // assert
            postProcessingStringArray.Should().BeNull();
        }

        [TestCase(new string[] { "FIRST ARRAY LINE", "seCOND ARRAY LINE", "12sdDFG AS" },
                  new string[] { "first array line", "second array line", "12sddfg as" })]
        public void HomeworkClass_ReturnLowerCase_ForStringArray(string[] inputStringArray,
                                                                 string[] expectationStringArray)
        {
            // act
            var postProcessingStringArray = homeworkClassInstance.DoSomething(inputStringArray);
            // assert
            postProcessingStringArray.Should().HaveCount(2 * inputStringArray.Length);
            for (int idx = 0; idx < inputStringArray.Length; ++idx) { 
                postProcessingStringArray[idx].Should().BeEquivalentTo(expectationStringArray[idx]);
            }
        }

        string[][] inputStringData = new [] {
                    new [] { "one string" },
                    new [] { "one", "two string"},
                    new [] { "1", "two", "line", "another line", "and another.." },
                    new [] { "1", "2", "", "4", " ", "6", "7.."} };
        [TestCaseSource("inputStringData")]
        public void HomeworkClass_ReturnDoubleLengthArray_ForAnyCorrectArray(string[] inputStringArray)
        {
            // act
            var postProcessingStringArray = homeworkClassInstance.DoSomething(inputStringArray);
            // assert
            postProcessingStringArray.Should().HaveCount(2 * inputStringArray.Length);
        }

        [Test]
        public void HomeworkClass_ThrowException_WhenSendUncorrectArray()
        {
            // arrange
            string[] inputStringArray = new string[] { "FIRST ARRAY LINE", (string)null, "12sdDFG AS" };
            // act
            Action action = () => homeworkClassInstance.DoSomething(inputStringArray);
            // assert
            action.ShouldThrow<ArgumentException>();
        }

        [TestCase(new string[] { "SOURCE" },
                  new string[] { "MySuffixsource",
                                 "sourceMySuffixa"}, "a", "")]
        [TestCase(new string[] { "SOURCE" },
                  new string[] { "bsource",
                                 "sourceMySuffix"}, "", "b")]
        [TestCase(new string[] { "SOURCE"},
                  new string[] { "MySuffixaasource",
                                 "sourceMySuffixbb" }, "aa", "bb")]
        [TestCase(new string[] { "SOURCE" },
                  new string[] { "MySuffixaasource",
                                 "sourceMySuffixMySuffix" }, "aa", "MySuffix")]
        public void HomeworkClass_ProcessedStringsWithPrefixesAndPostfixes_WhenSetThem(string[] inputStringArray, string[] expectationStringArray, string prefix = "", string postfix = "")
        {
            // act
            var postProcessingStringArray = homeworkClassInstance.DoSomething(inputStringArray, prefix, postfix);
            // assert
            postProcessingStringArray.Should().HaveCount(2 * inputStringArray.Length).And.BeEquivalentTo(expectationStringArray);
        }
    }
}
