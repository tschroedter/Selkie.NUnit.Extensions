using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using JetBrains.Annotations;

namespace Selkie.NUnit.Extensions
{
    public static class StringExtensions
    {
        private static readonly Regex FindNewLines = new Regex("\r\n|\n|\r",
                                                               RegexOptions.Compiled | RegexOptions.CultureInvariant);

        /// <summary>
        ///     Concatenates the specified <paramref name="elements" /> using the
        ///     <paramref name="separator" /> specified.
        /// </summary>
        /// <param name="elements">The strings to concatenate.</param>
        /// <param name="separator">
        ///     The separator to use in between each element.
        /// </param>
        /// <returns>
        ///     The concatenated string.
        /// </returns>
        [NotNull]
        public static string Join([NotNull] this IEnumerable <string> elements,
                                  char separator)
        {
            return elements.Join(separator.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        ///     <para>
        ///         Concatenates the specified <paramref name="elements" /> using the
        ///         <paramref name="separator" /> and last <paramref name="separator" />
        ///     </para>
        ///     <para>specified.</para>
        /// </summary>
        /// <param name="elements">The strings to concatenate.</param>
        /// <param name="separator">
        ///     The separator to use in between all but the last two elements.
        /// </param>
        /// <param name="lastSeparator">
        ///     The <paramref name="separator" /> to use in between the last two
        ///     elements.
        /// </param>
        /// <returns>
        ///     The concatenated string.
        /// </returns>
        [NotNull]
        public static string Join([NotNull] this IEnumerable <string> elements,
                                  char separator,
                                  char lastSeparator)
        {
            return elements.Join(separator.ToString(CultureInfo.InvariantCulture),
                                 lastSeparator.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        ///     Concatenates the specified <paramref name="elements" /> using the
        ///     <paramref name="separator" /> specified.
        /// </summary>
        /// <param name="elements">The strings to concatenate.</param>
        /// <param name="separator">
        ///     The separator to use in between each element.
        /// </param>
        /// <returns>
        ///     The concatenated string.
        /// </returns>
        [NotNull]
        public static string Join([NotNull] this IEnumerable <string> elements,
                                  [NotNull] string separator)
        {
            return elements.Join(separator,
                                 separator);
        }

        /// <summary>
        ///     <para>
        ///         Concatenates the specified <paramref name="elements" /> using the
        ///         <paramref name="separator" /> and last <paramref name="separator" />
        ///     </para>
        ///     <para>specified.</para>
        /// </summary>
        /// <param name="elements">The strings to concatenate.</param>
        /// <param name="separator">
        ///     The separator to use in between all but the last two elements.
        /// </param>
        /// <param name="lastSeparator">
        ///     The <paramref name="separator" /> to use in between the last two
        ///     elements.
        /// </param>
        /// <returns>
        ///     The concatenated string.
        /// </returns>
        [NotNull]
        public static string Join([NotNull] this IEnumerable <string> elements,
                                  [NotNull] string separator,
                                  [NotNull] string lastSeparator)
        {
            IList <string> list = elements as IList <string> ?? new List <string>(elements);
            int numberElements = list.Count;

            if ( numberElements == 0 )
            {
                return string.Empty;
            }

            if ( numberElements == 1 )
            {
                return list [ 0 ];
            }

            string joined = JoinElements(separator,
                                         lastSeparator,
                                         list);

            return joined;
        }

        [NotNull]
        private static string JoinElements([NotNull] string separator,
                                           [NotNull] string lastSeparator,
                                           [NotNull] IList <string> list)
        {
            var builder = new StringBuilder(list [ 0 ]);

            var index = 1;
            int lastElement = list.Count - 1;

            for ( ; ; )
            {
                if ( index != lastElement )
                {
                    builder.Append(separator + list [ index ]);
                    index++;
                }
                else
                {
                    builder.Append(lastSeparator + list [ index ]);
                    break;
                }
            }

            return builder.ToString();
        }

        /// <summary>
        ///     Splits a string in to a list of strings with the specified number of
        ///     characters.
        /// </summary>
        /// <param name="text">The string to split up.</param>
        /// <param name="numberOfCharacters">
        ///     The number of characters in each group.
        /// </param>
        /// <returns>
        ///     A list of groups.
        /// </returns>
        [NotNull]
        public static IEnumerable <string> AsGroupsOf([NotNull] this string text,
                                                      int numberOfCharacters)
        {
            var index = 0;

            for ( ; ; )
            {
                int length = Math.Min(numberOfCharacters,
                                      text.Length - index);

                if ( length <= 0 )
                {
                    yield break;
                }

                yield return text.Substring(index,
                                            length);

                index += numberOfCharacters;
            }
        }

        /// <summary>
        ///     <para>
        ///         Replaces the <paramref name="format" /> item in a specified
        ///         <see cref="string" /> with the text equivalent of the value of a
        ///         corresponding <see cref="object" />
        ///     </para>
        ///     <para>
        ///         instance in a specified array.
        ///         <see cref="System.Globalization.CultureInfo.CurrentCulture" />
        ///     </para>
        ///     <para>will be used as the <see cref="IFormatProvider" /> .</para>
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="arguments">
        ///     An <see cref="Object" /> array containing zero or more objects to
        ///     format.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="format" /> or args is null.
        /// </exception>
        /// <exception cref="FormatException">
        ///     <paramref name="format" /> is invalid. -or- The number indicating an
        ///     argument to <paramref name="format" /> is less than zero, or greater
        ///     than or equal to the length of the args array.
        /// </exception>
        /// <returns>
        ///     A copy of <paramref name="format" /> in which the
        ///     <paramref name="format" /> items have been replaced by the
        ///     <see cref="String" /> equivalent of the corresponding instances of
        ///     <see cref="Object" /> in args.
        /// </returns>
        [NotNull]
        [StringFormatMethod("format")]
        public static string Inject([NotNull] this string format,
                                    [NotNull] params object[] arguments)
        {
            return string.Format(CultureInfo.CurrentCulture,
                                 format,
                                 arguments);
        }

        /// <summary>
        ///     <para>
        ///         Replaces the <paramref name="format" /> item in a specified
        ///         <see cref="String" /> with the text equivalent of the value of a
        ///         corresponding <see cref="Object" />
        ///     </para>
        ///     <para>
        ///         instance in a specified array.
        ///         <see cref="System.Globalization.CultureInfo.InvariantCulture" />
        ///     </para>
        ///     <para>will be used as the <see cref="IFormatProvider" /> .</para>
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="arguments">
        ///     An <see cref="Object" /> array containing zero or more objects to
        ///     format.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="format" /> or args is null.
        /// </exception>
        /// <exception cref="FormatException">
        ///     <paramref name="format" /> is invalid. -or- The number indicating an
        ///     argument to <paramref name="format" /> is less than zero, or greater
        ///     than or equal to the length of the args array.
        /// </exception>
        /// <returns>
        ///     A copy of <paramref name="format" /> in which the
        ///     <paramref name="format" /> items have been replaced by the
        ///     <see cref="String" /> equivalent of the corresponding instances of
        ///     <see cref="Object" /> in args.
        /// </returns>
        [NotNull]
        [StringFormatMethod("format")]
        public static string InjectInvariant([NotNull] this string format,
                                             [NotNull] params object[] arguments)
        {
            return string.Format(CultureInfo.InvariantCulture,
                                 format,
                                 arguments);
        }

        /// <summary>
        ///     Replaces all standard forms of line terminator ( <c>\r</c> ,
        ///     <c>\n</c> , <c>\r\n</c> ) with the
        ///     <see cref="System.Environment.NewLine" /> .
        /// </summary>
        /// <param name="text">The text to normalize.</param>
        /// <returns>
        ///     The normalized text.
        /// </returns>
        [NotNull]
        public static string ReplaceNewLinesWithDefault([NotNull] this string text)
        {
            return text.ReplaceNewLinesWith(Environment.NewLine);
        }

        /// <summary>
        ///     Replaces all standard forms of line terminator ( <c>\r</c> ,
        ///     <c>\n</c> , <c>\r\n</c> ) with the specified
        ///     <paramref name="newLine" />
        /// </summary>
        /// <param name="text">The text to normalize.</param>
        /// <param name="newLine">
        ///     The string to use for line termination.
        /// </param>
        /// <returns>
        ///     The normalized text.
        /// </returns>
        [NotNull]
        public static string ReplaceNewLinesWith([NotNull] this string text,
                                                 [NotNull] string newLine)
        {
            return FindNewLines.Replace(text,
                                        newLine);
        }

        /// <summary>
        ///     Breaks a string up into a list of strings at new line characters.
        ///     The resulting strings do not contain any new line characters.
        /// </summary>
        [NotNull]
        public static IEnumerable <string> Lines([NotNull] this string text)
        {
            var reader = new StringReader(text);

            for ( ; ; )
            {
                string line = reader.ReadLine();

                if ( line == null )
                {
                    yield break;
                }

                yield return line;
            }
        }

        /// <summary>
        ///     Breaks a string up into a list of words, which are delimited by
        ///     white space.
        /// </summary>
        [NotNull]
        public static IEnumerable <string> Words([NotNull] this string text)
        {
            return Regex.Split(text,
                               @"\s+");
        }
    }
}