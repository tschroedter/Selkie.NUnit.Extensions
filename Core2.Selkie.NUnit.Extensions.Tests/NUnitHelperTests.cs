using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NUnit.Framework;

namespace Selkie.NUnit.Extensions.Tests
{
    // ReSharper disable ClassTooBig
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class NUnitHelperTests
    {
        [Test]
        public void AssertDegreesDoesNotThrowForMinusEpsilonTest()
        {
            Assert.DoesNotThrow(() => NUnitHelper.AssertDegrees(100.0,
                                                                100.0 - ( Constants.EpsilonRadians * 0.9 )));
        }

        [Test]
        public void AssertDegreesDoesNotThrowForPlusEpsilonTest()
        {
            Assert.DoesNotThrow(() => NUnitHelper.AssertDegrees(100.0,
                                                                100.0 + ( Constants.EpsilonRadians * 0.9 )));
        }

        [Test]
        public void AssertDegreesDoesNotThrowForSameTest()
        {
            Assert.DoesNotThrow(() => NUnitHelper.AssertDegrees(100.0,
                                                                100.0));
        }

        [Test]
        public void AssertDegreesDoesThrowForMinusEpsilonTest()
        {
            Assert.Throws <AssertionException>(() => NUnitHelper.AssertDegrees(100.0,
                                                                               100.0 - Constants.EpsilonRadians));
        }

        [Test]
        public void AssertDegreesDoesThrowForPlusEpsilonTest()
        {
            Assert.Throws <AssertionException>(() => NUnitHelper.AssertDegrees(100.0,
                                                                               100.0 + Constants.EpsilonRadians));
        }

        [Test]
        public void AssertIsEquivalentAbsoluteIsBiggerEpsilonTest()
        {
            Assert.Throws <AssertionException>(() => NUnitHelper.AssertIsEquivalent(1.0,
                                                                                    100.0,
                                                                                    0.1,
                                                                                    "text"));
        }

        [Test]
        public void AssertIsEquivalentAbsoluteIsNaNTest()
        {
            Assert.Throws <AssertionException>(() => NUnitHelper.AssertIsEquivalent(double.NaN,
                                                                                    100.0,
                                                                                    0.1,
                                                                                    "text"));
        }

        [Test]
        public void AssertIsEquivalentDoesNotThrowTest()
        {
            Assert.DoesNotThrow(() => NUnitHelper.AssertIsEquivalent(100.0,
                                                                     100.0,
                                                                     0.1,
                                                                     "text"));
        }

        [Test]
        public void AssertIsEquivalentMinusEpsilonPlusDeltaTest()
        {
            Assert.Throws <AssertionException>(() => NUnitHelper.AssertIsEquivalent(100.0 - 0.11,
                                                                                    100.0,
                                                                                    0.1,
                                                                                    "text"));
        }

        [Test]
        public void AssertIsEquivalentMinusEpsilonTest()
        {
            Assert.DoesNotThrow(() => NUnitHelper.AssertIsEquivalent(100.0 - 0.1,
                                                                     100.0,
                                                                     0.1,
                                                                     "text"));
        }

        [Test]
        public void AssertIsEquivalentPlusEpsilonPlusDeltaTest()
        {
            Assert.Throws <AssertionException>(() => NUnitHelper.AssertIsEquivalent(100.0 + 0.11,
                                                                                    100.0,
                                                                                    0.1,
                                                                                    "text"));
        }

        [Test]
        public void AssertIsEquivalentPlusEpsilonTest()
        {
            Assert.DoesNotThrow(() => NUnitHelper.AssertIsEquivalent(100.0 + 0.1,
                                                                     100.0,
                                                                     0.1,
                                                                     "text"));
        }

        [Test]
        public void AssertRadiansDoesNotThrowForMinusEpsilonTest()
        {
            Assert.DoesNotThrow(() => NUnitHelper.AssertRadians(100.0,
                                                                100.0 - ( Constants.EpsilonRadians * 0.9 )));
        }

        [Test]
        public void AssertRadiansDoesNotThrowForPlusEpsilonTest()
        {
            Assert.DoesNotThrow(() => NUnitHelper.AssertRadians(100.0,
                                                                100.0 + ( Constants.EpsilonRadians * 0.9 )));
        }

        [Test]
        public void AssertRadiansDoesNotThrowForSameTest()
        {
            Assert.DoesNotThrow(() => NUnitHelper.AssertRadians(100.0,
                                                                100.0));
        }

        [Test]
        public void AssertRadiansDoesThrowForMinusEpsilonTest()
        {
            Assert.Throws <AssertionException>(() => NUnitHelper.AssertRadians(100.0,
                                                                               100.0 - Constants.EpsilonRadians));
        }

        [Test]
        public void AssertRadiansDoesThrowForPlusEpsilonTest()
        {
            Assert.Throws <AssertionException>(() => NUnitHelper.AssertRadians(100.0,
                                                                               100.0 + Constants.EpsilonRadians));
        }

        [Test]
        public void AssertSequenceEqualDoesNotThrowTest()
        {
            int[] listOne =
            {
                1,
                2,
                3
            };

            Assert.DoesNotThrow(() => NUnitHelper.AssertSequenceEqual(listOne,
                                                                      listOne,
                                                                      "Message"));
        }

        [Test]
        public void AssertSequenceEqualDoesThrowForDifferentTest()
        {
            int[] listOne =
            {
                1,
                2,
                3
            };
            List <int> listTwo = new[]
                                 {
                                     1,
                                     2,
                                     4
                                 }.ToList();

            Assert.Throws <AssertionException>(() => NUnitHelper.AssertSequenceEqual(listOne,
                                                                                     listTwo,
                                                                                     "Message"));
        }

        [Test]
        public void AssertSequenceEqualDoesThrowForToLongTest()
        {
            int[] listOne =
            {
                1,
                2,
                3
            };
            List <int> listTwo = new[]
                                 {
                                     1,
                                     2,
                                     3,
                                     4
                                 }.ToList();

            Assert.Throws <AssertionException>(() => NUnitHelper.AssertSequenceEqual(listOne,
                                                                                     listTwo,
                                                                                     "Message"));
        }

        [Test]
        public void AssertSequenceEqualDoesThrowForToShortTest()
        {
            int[] listOne =
            {
                1,
                2,
                3
            };
            List <int> listTwo = new[]
                                 {
                                     1,
                                     2
                                 }.ToList();

            Assert.Throws <AssertionException>(() => NUnitHelper.AssertSequenceEqual(listOne,
                                                                                     listTwo,
                                                                                     "Message"));
        }

        [Test]
        public void ContainsReturnsFalseTest()
        {
            List <int> listOne = new[]
                                 {
                                     1,
                                     2,
                                     3
                                 }.ToList();
            List <int> listTwo = new[]
                                 {
                                     1,
                                     2
                                 }.ToList();

            var lists = new List <List <int>>
                        {
                            listOne
                        };

            Assert.False(NUnitHelper.Contains(lists,
                                              listTwo));
        }

        [Test]
        public void ContainsReturnsTrueTest()
        {
            List <int> listOne = new[]
                                 {
                                     1,
                                     2,
                                     3
                                 }.ToList();
            List <int> listTwo = new[]
                                 {
                                     1,
                                     2
                                 }.ToList();

            var lists = new List <List <int>>
                        {
                            listOne,
                            listTwo
                        };

            Assert.True(NUnitHelper.Contains(lists,
                                             listTwo));
        }

        [Test]
        public void IsEquivalentDoesNotThrowForSameContentTest()
        {
            List <double> listOne = new[]
                                    {
                                        1.0,
                                        2.0,
                                        3.0
                                    }.ToList();
            List <double> listTwo = new[]
                                    {
                                        1.0,
                                        2.0,
                                        3.0
                                    }.ToList();

            Assert.DoesNotThrow(() => NUnitHelper.IsEquivalent(listOne,
                                                               listTwo));
        }

        [Test]
        public void IsEquivalentDoesNotThrowTest()
        {
            List <double> listOne = new[]
                                    {
                                        1.0,
                                        2.0,
                                        3.0
                                    }.ToList();

            Assert.DoesNotThrow(() => NUnitHelper.IsEquivalent(listOne,
                                                               listOne));
        }

        [Test]
        public void IsEquivalentDoesThrowsForDifferentTest()
        {
            List <double> listOne = new[]
                                    {
                                        1.0,
                                        2.0,
                                        3.0
                                    }.ToList();
            List <double> listTwo = new[]
                                    {
                                        1.0,
                                        2.0
                                    }.ToList();

            Assert.Throws <AssertionException>(() => NUnitHelper.IsEquivalent(listOne,
                                                                              listTwo));
        }

        [Test]
        public void IsEquivalentDoesThrowsForToLongTest()
        {
            List <double> listOne = new[]
                                    {
                                        1.0,
                                        2.0,
                                        3.0
                                    }.ToList();
            List <double> listTwo = new[]
                                    {
                                        1.0,
                                        2.0,
                                        3.0,
                                        4.0
                                    }.ToList();

            Assert.Throws <AssertionException>(() => NUnitHelper.IsEquivalent(listOne,
                                                                              listTwo));
        }

        [Test]
        public void IsEquivalentDoesThrowsForToShortTest()
        {
            List <double> listOne = new[]
                                    {
                                        1.0,
                                        2.0,
                                        3.0
                                    }.ToList();
            List <double> listTwo = new[]
                                    {
                                        1.0,
                                        2.0
                                    }.ToList();

            Assert.Throws <AssertionException>(() => NUnitHelper.IsEquivalent(listOne,
                                                                              listTwo));
        }

        [Test]
        public void IsEquivalentReturnsFalseForDifferentValuesTest()
        {
            Assert.False(NUnitHelper.IsEquivalent(0.0,
                                                  10.0));
        }

        [Test]
        public void IsEquivalentReturnsFalseForGreaterEpsilonTest()
        {
            Assert.False(NUnitHelper.IsEquivalent(10.0,
                                                  10.0 + ( Constants.Epsilon * 2.0 )));
        }

        [Test]
        public void IsEquivalentReturnsTrueForSameValuesTest()
        {
            Assert.True(NUnitHelper.IsEquivalent(10.0,
                                                 10.0));
        }

        [Test]
        public void IsEquivalentReturnsTrueForValuesInsideEpsilonTest()
        {
            Assert.True(NUnitHelper.IsEquivalent(10.0,
                                                 10.0 + ( Constants.Epsilon / 2.0 )));
        }
    }
}