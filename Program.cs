using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SpanTest
{
    class Program
    {
        static void Main(string[] args)
        {
#if RELEASE
            BenchmarkRunner.Run<SpanTester>();
#else
            var s = new SpanTester { RowCount = 50 };
            var withoutSpan = s.WithoutSpan();
            var withSpan = s.WithSpan();
#endif
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


        [Benchmark]
        public void WithSpan()
        {
            var buffer = new Span<byte>(_filecontent);
            int cursor = 0;

            for (int i = 0; i < RowCount; i++)
            {
                var row = buffer.Slice(cursor, ROWSIZE);
                cursor += ROWSIZE;
                FooLarge.ReadWithSpan(row, _encoding);
            }
        }

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
                FooLarge.ReadWithSpan(row);
            }
        }

        [Benchmark]
        public void WithoutSpan()
        {
            var result = new FooResult();// { FooList = new List<IFoo>(RowCount) };

            using (var stream = new MemoryStream(_filecontent))
            using (var source = new StreamReader(stream, _encoding))
            {
                var buffer = new char[ROWSIZE];
                for (int i = 0; i < RowCount; i++)
                {
                    source.Read(buffer, 0, ROWSIZE);
                    var row = new string(buffer);
                    FooLarge.Read(row);
                }
            }
        }
    }


}
