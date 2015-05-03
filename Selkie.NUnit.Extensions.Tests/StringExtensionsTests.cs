using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NUnit.Framework;

namespace Selkie.NUnit.Extensions.Tests
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class StringExtensionsTests
    {
        [Test]
        public void AsGroupsOfOneTest()
        {
            const string @group = "Group";

            string[] actual = group.AsGroupsOf(1)
                                   .ToArray();

            Assert.AreEqual(5,
                            actual.Length,
                            "Count");
            Assert.True(String.Compare("G",
                                       actual[0],
                                       StringComparison.Ordinal) == 0);
            Assert.True(String.Compare("r",
                                       actual[1],
                                       StringComparison.Ordinal) == 0);
            Assert.True(String.Compare("o",
                                       actual[2],
                                       StringComparison.Ordinal) == 0);
            Assert.True(String.Compare("u",
                                       actual[3],
                                       StringComparison.Ordinal) == 0);
            Assert.True(String.Compare("p",
                                       actual[4],
                                       StringComparison.Ordinal) == 0);
        }

        [Test]
        public void InjectInvariantTest()
        {
            const string expected = "Text: Hello World!";
            string actual = "Text: {0} {1}!".InjectInvariant("Hello",
                                                             "World");

            Assert.AreEqual(expected,
                            actual);
        }

        [Test]
        public void InjectTest()
        {
            const string expected = "Text: Hello World!";
            string actual = "Text: {0} {1}!".Inject("Hello",
                                                    "World");

            Assert.AreEqual(expected,
                            actual);
        }

        [Test]
        public void JoinForEmptyElementsTest()
        {
            string[] elements = new string[0];

            string actual = elements.Join(',',
                                          '.');

            Assert.True(String.Compare(string.Empty,
                                       actual,
                                       StringComparison.Ordinal) == 0);
        }

        [Test]
        public void JoinForOneElementTest()
        {
            string[] elements = {
                                    "a"
                                };

            const string expected = "a";
            string actual = elements.Join(',',
                                          '.');

            Assert.True(String.Compare(expected,
                                       actual,
                                       StringComparison.Ordinal) == 0);
        }

        [Test]
        public void JoinTest()
        {
            string[] elements = {
                                    "a",
                                    "b",
                                    "c"
                                };

            const string expected = "a,b,c";
            string actual = elements.Join(',');

            Assert.True(String.Compare(expected,
                                       actual,
                                       StringComparison.Ordinal) == 0);
        }

        [Test]
        public void JoinTwoSeparatorsTest()
        {
            string[] elements = {
                                    "a",
                                    "b",
                                    "c"
                                };

            const string expected = "a,b.c";
            string actual = elements.Join(',',
                                          '.');

            Assert.True(String.Compare(expected,
                                       actual,
                                       StringComparison.Ordinal) == 0);
        }

        [Test]
        public void LinesTest()
        {
            string @group = "a" + Environment.NewLine + "b" + Environment.NewLine + "c" + Environment.NewLine;

            string[] actual = group.Lines()
                                   .ToArray();

            Assert.AreEqual(3,
                            actual.Length,
                            "Count");
            Assert.True(String.Compare("a",
                                       actual[0],
                                       StringComparison.Ordinal) == 0);
            Assert.True(String.Compare("b",
                                       actual[1],
                                       StringComparison.Ordinal) == 0);
            Assert.True(String.Compare("c",
                                       actual[2],
                                       StringComparison.Ordinal) == 0);
        }

        [Test]
        public void ReplaceNewLinesWithDefaultCaseOneTest()
        {
            const string text = "\n\n";

            string expected = Environment.NewLine + Environment.NewLine;
            string actual = text.ReplaceNewLinesWithDefault();

            Assert.True(String.Compare(expected,
                                       actual,
                                       StringComparison.Ordinal) == 0);
        }

        [Test]
        public void ReplaceNewLinesWithDefaultCaseTwoTest()
        {
            const string text = "\r\n\r\n";

            string expected = Environment.NewLine + Environment.NewLine;
            string actual = text.ReplaceNewLinesWithDefault();

            Assert.True(String.Compare(expected,
                                       actual,
                                       StringComparison.Ordinal) == 0);
        }

        [Test]
        public void WordsTest()
        {
            const string @group = "a b c";

            string[] actual = group.Words()
                                   .ToArray();

            Assert.AreEqual(3,
                            actual.Length,
                            "Count");
            Assert.True(String.Compare("a",
                                       actual[0],
                                       StringComparison.Ordinal) == 0);
            Assert.True(String.Compare("b",
                                       actual[1],
                                       StringComparison.Ordinal) == 0);
            Assert.True(String.Compare("c",
                                       actual[2],
                                       StringComparison.Ordinal) == 0);
        }
    }
}