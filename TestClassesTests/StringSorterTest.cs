using FluentAssertions;
using NUnit.Framework;
using TestClasses;

namespace TestClassesTests
{
    internal class StringSorterTest
    {        

        [Test]
        public void SortAndChageCase_WorksWell_WithNull()
        {
            string[] nullArray = null;

            var res = new StringSorter().SortAndChangeCase(nullArray);

            res.Should().BeNull();
        }

        [Test]
        public void SortAndChageCase_Sorts_OnOneElementArray()
        {
            var nullArray = new[] {""};

            var res = new StringSorter().SortAndChangeCase(nullArray);

            res.Should().HaveCount(1);
            res[0].Should().BeEmpty();
        }

        [Test]
        public void SortAndChageCase_MakesLowerCase_OnOneElementArray()
        {
            var str = "LowerMyCase";
            var nullArray = new[] { str };

            var res = new StringSorter().SortAndChangeCase(nullArray);

            res.Should().HaveCount(1);
            res[0].Should().Be(str.ToLower());
        }

        [Test]
        public void SortAndChageCase_MakesUpperCase_OnOneElementArray()
        {
            var str = "UpperMyCase";
            var nullArray = new[] { str };

            var res = new StringSorter().SortAndChangeCase(nullArray, toLower:false);

            res.Should().HaveCount(1);
            res[0].Should().Be(str.ToUpper());
        }

        [Test]
        public void SortAndChageCase_SortsTwoElementArray()
        {
            var str = "UpperMyCase";
            var str2 = "UpeerMyCase2";
            var array = new[] { str, str2 };

            var res = new StringSorter().SortAndChangeCase(array);

            res.Should().HaveCount(2);
            res[0].Length.Should().BeLessOrEqualTo(res[1].Length);
        }

        [Test]
        public void SortAndChageCase_SortsTwoElementArrayDescending()
        {
            var str = "UpperMyCase";
            var str2 = "UpeerMyCase2";
            var array = new[] { str, str2 };

            var res = new StringSorter().SortAndChangeCase(array, @ascending: false);

            res.Should().HaveCount(2);
            res[1].Length.Should().BeLessOrEqualTo(res[0].Length);
        }

        [Test]
        public void SortAndChangeCase_SortsAndChangesCase_OnTwoElementArray()
        {
            var str = "UpperMyCase";
            var str2 = "UpeerMyCase2";
            var array = new[] { str2, str };

            var res = new StringSorter().SortAndChangeCase(array);

            res.Should().HaveCount(2);
            res[0].Length.Should().BeLessOrEqualTo(res[1].Length);
            res[0].Should().Be(str.ToLower());
            res[1].Should().Be(str2.ToLower());
        }
    }
}
