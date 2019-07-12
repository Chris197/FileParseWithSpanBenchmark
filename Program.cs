using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.IO;
using System.Text;

namespace SpanTest
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<SpanTester>();
        }
    }

    [RankColumn]
    [MemoryDiagnoser]
    public class SpanTester
    {
        private static byte[] _filecontent;
        private const int ROWSIZE = 252;
        private readonly Encoding _encoding = Encoding.ASCII;

        public SpanTester()
        {
            _filecontent = File.ReadAllBytes("data.txt");
        }

        [Params(1, 50)]
        public int RowCount { get; set; }


        /// <summary>
        /// Parses the file using a span of bytes, decoding to string per field.
        /// </summary>
        [Benchmark]        
        public void WithSpan()
        {
            var buffer = new Span<byte>(_filecontent);
            int cursor = 0;

            for (int i = 0; i < RowCount; i++)
            {
                var row = buffer.Slice(cursor, ROWSIZE);
                cursor += ROWSIZE;
                Foo.ReadWithSpan(row, _encoding);
            }
        }

        /// <summary>
        /// Parses the file using a span of char, after first converting the byte array to a string.
        /// </summary>
        [Benchmark]
        public void WithSpan_StringFirst()
        {
            var buffer1 = new Span<byte>(_filecontent).Slice(0, RowCount * ROWSIZE);
            var buffer = _encoding.GetString(buffer1).AsSpan();

            int cursor = 0;
            for (int i = 0; i < RowCount; i++)
            {
                var row = buffer.Slice(cursor, ROWSIZE);
                cursor += ROWSIZE;
                Foo.ReadWithSpan(row);
            }
        }

        /// <summary>
        /// Parses the file by decoding to string using a StreamReader and then using Substring to read each field.
        /// </summary>
        [Benchmark]
        public void WithoutSpan()
        {
            using (var stream = new MemoryStream(_filecontent))
            using (var source = new StreamReader(stream, _encoding))
            {
                var buffer = new char[ROWSIZE];
                for (int i = 0; i < RowCount; i++)
                {
                    source.Read(buffer, 0, ROWSIZE);
                    var row = new string(buffer);
                    Foo.Read(row);
                }
            }
        }
    }


}
