using System;
using System.Collections.Generic;
using System.Text;

namespace SpanTest
{
    public static class StringExtensions
    {
        /// <summary>
        /// Reads using Substring
        /// </summary>
        public static string Read(this string input, int startIndex, int endIndex)
        {
            return input.Substring(startIndex, endIndex - startIndex);
        }

        /// <summary>
        /// Reads using a Span&lt;char&gt;
        /// </summary>
        public static string Read(this ReadOnlySpan<char> input, int startIndex, int endIndex)
        {
            return new string(input.Slice(startIndex, endIndex - startIndex));
        }

        /// <summary>
        /// Reads using a Span&lt;byte&gt; and decodes using the provided encoding.
        /// </summary>
        public static string Read(this ReadOnlySpan<byte> input, int startIndex, int endIndex, Encoding encoding)
        {
            return encoding.GetString(input.Slice(startIndex, endIndex - startIndex));
        }
    }
}
