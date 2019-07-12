using System;
using System.Collections.Generic;
using System.Text;

namespace SpanTest
{
    public static class StringExtensions
    {
        public static string Read(this string input, int startIndex, int endIndex)
        {
            return input.Substring(startIndex - 1, endIndex - startIndex + 1)/*.Trim()*/;
        }

        public static int ReadInt(this string input, int startIndex, int endIndex)
        {
            var text = input.Read(startIndex, endIndex);
            return int.Parse(text);
        }

        public static string Read(this ReadOnlySpan<char> input, int startIndex, int endIndex)
        {
            return input.Slice(startIndex - 1, endIndex - startIndex + 1).ToString()/*.Trim()*/;
        }

        public static int ReadInt(this ReadOnlySpan<char> input, int startIndex, int endIndex)
        {
            return int.Parse(input.Read(startIndex, endIndex));
        }

        public static string Read(this ReadOnlySpan<byte> input, int startIndex, int endIndex, Encoding encoding)
        {
            return encoding.GetString(input.Slice(startIndex - 1, endIndex - startIndex + 1))/*.Trim()*/;
        }

        public static int ReadInt(this ReadOnlySpan<byte> input, int startIndex, int endIndex, Encoding encoding)
        {
            return int.Parse(input.Read(startIndex, endIndex, encoding));
        }
    }
}
