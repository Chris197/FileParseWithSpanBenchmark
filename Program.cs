using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
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

            //var s = new SpanTester { RowCount = 5 };
            //var withoutSpan = s.WithoutSpan();
            //var withSpan = s.WithSpan();
        }

    }

    [RankColumn]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [MemoryDiagnoser]
    public class SpanTester
    {
        private static byte[] _filecontent;
        private const int ROWSIZE = 252;

        public SpanTester()
        {
            _filecontent = File.ReadAllBytes("data.txt");
        }

        [Params(1, 4, 10)]
        public int RowCount { get; set; }


        [Benchmark]
        public Foo WithSpan()
        {
            var foo = new Foo();

            var buffer = new Span<byte>(_filecontent);
            int cursor = 0;
            for (int i = 0; i < RowCount; i++)
            {
                var row = buffer.Slice(cursor, ROWSIZE);
                foo.Field1 = Encoding.UTF8.GetString(row.Slice(0, 1));
                cursor += ROWSIZE;
            }
            return foo;
        }

        [Benchmark]
        public Foo WithoutSpan()
        {
            var foo = new Foo();

            using (var stream = new MemoryStream(_filecontent))
            using (var source = new StreamReader(stream, Encoding.UTF8))
            {
                var buffer = new char[ROWSIZE];
                for (int i = 0; i < RowCount; i++)
                {
                    source.Read(buffer, 0, ROWSIZE);
                    var row = new string(buffer);
                    foo.Field1 = row.Substring(0, 1);
                }
            }
            return foo;
        }
    }
}
