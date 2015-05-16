using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JetBrains.Annotations;
using NUnit.Framework;

namespace Selkie.NUnit.Extensions
{
    public sealed class NUnitHelper
    {
        public static void AssertIsEquivalent(double value1,
                                              double value2,
                                              [NotNull] string text = "")
        {
            AssertIsEquivalent(value1,
                               value2,
                               Constants.Epsilon,
                               text);
        }

        public static void AssertIsEquivalent(double value1,
                                              double value2,
                                              double epsilon)
        {
            AssertIsEquivalent(value1,
                               value2,
                               Constants.Epsilon,
                               string.Empty);
        }

        // ReSharper disable once TooManyArguments
        public static void AssertIsEquivalent(double value1,
                                              double value2,
                                              double epsilon,
                                              [NotNull] string text)
        {
            double abs = Math.Abs(value1 - value2);

            if ( double.IsNaN(abs) )
            {
                Assert.Fail(text + " - Absolute difference is NaN!");
            }

            if ( abs > epsilon )
            {
                Assert.Fail(text + "Absolute difference {0} but epsilon is {1}!".Inject(abs,
                                                                                        epsilon));
            }
        }

        public static bool IsEquivalent(double value1,
                                        double value2)
        {
            return IsEquivalent(value1,
                                value2,
                                Constants.Epsilon);
        }

        public static bool IsEquivalent(double value1,
                                        double value2,
                                        double epsilon)
        {
            double abs = Math.Abs(value1 - value2);

            return !double.IsNaN(abs) && abs < epsilon;
        }

        public static void IsEquivalent([NotNull] IList <double> value1,
                                        [NotNull] IList <double> value2)
        {
            Assert.AreEqual(value1.Count,
                            value2.Count,
                            "Length is different!");

            for ( var i = 0 ; i < value1.Count ; i++ )
            {
                string text = string.Format("[{0}] Expected '{1}' but actual is '{2}'!",
                                            i,
                                            value1 [ i ],
                                            value2 [ i ]);

                Assert.IsTrue(IsEquivalent(value1 [ i ],
                                           value2 [ i ]),
                              text);
            }
        }

        public static bool Contains([NotNull] List <List <int>> listOfList,
                                    [NotNull] List <int> expected)
        {
            return listOfList.Any(list => list.SequenceEqual(expected));
        }

        public static void AssertSequenceEqual <T>([NotNull] IEnumerable <T> sequenceOne,
                                                   [NotNull] IEnumerable <T> sequenceTwo,
                                                   [NotNull] string message)
        {
            T[] one = sequenceOne.ToArray();
            T[] two = sequenceTwo.ToArray();

            if ( !one.SequenceEqual(two) )
            {
                string oneText = SequenceToString(one);
                string twoText = SequenceToString(two);
                string text = string.Format("{0}: Expected sequence is '{1}' but actual is '{2}'!",
                                            message,
                                            oneText,
                                            twoText);

                Assert.Fail(text);
            }
        }

        [NotNull]
        private static string SequenceToString <T>([NotNull] IEnumerable <T> sequence)
        {
            T[] array = sequence.ToArray();

            var sb = new StringBuilder();

            sb.Append("{");

            for ( var i = 0 ; i < array.Length ; i++ )
            {
                sb.Append(array [ i ]);

                if ( i < ( array.Length - 1 ) )
                {
                    sb.Append(",");
                }
            }

            sb.Append("}");

            return sb.ToString();
        }

        public static void AssertRadians(double expected,
                                         double actual)
        {
            AssertIsEquivalent(expected,
                               actual,
                               Constants.EpsilonRadians,
                               "Radians");
        }

        public static void AssertDegrees(double expected,
                                         double actual)
        {
            AssertIsEquivalent(expected,
                               actual,
                               Constants.EpsilonDegrees,
                               "Radians");
        }
    }
}