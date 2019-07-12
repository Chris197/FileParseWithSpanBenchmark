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
            /*
            Console.Write(new string('0', 252));
            Console.Write(new string('1', 252));
            Console.Write(new string('2', 252));
            Console.Write(new string('3', 252));
            Console.Write(new string('4', 252));
            Console.Write(new string('5', 252));
            Console.Write(new string('6', 252));
            Console.Write(new string('7', 252));
            Console.Write(new string('8', 252));
            Console.Write(new string('9', 252));
            Console.ReadLine();
            */

#if RELEASE
            BenchmarkRunner.Run<SpanTester>();
#else
            var s = new SpanTester { RowCount = 50 };
            var withoutSpan = s.WithoutSpan();
            var withSpan = s.WithSpan();
#endif
        }
    }

    [WarmupCount(3)]
    [IterationCount(5)]
    [RankColumn]
    //[Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [MemoryDiagnoser]
    public class SpanTester
    {
        private static byte[] _filecontent;
        private const int ROWSIZE = 252;
        private readonly Encoding _encoding = Encoding.ASCII;

        public SpanTester()
        {
            _filecontent = File.ReadAllBytes("data.txt");
            //_filecontent = File.ReadAllBytes("kpn.CU");
        }

        [Params(1, 50)]
        public int RowCount { get; set; }


        [Benchmark]
        public FooResult WithSpan()
        {
            var result = new FooResult();// { FooList = new List<IFoo>(RowCount) };

            var buffer = new Span<byte>(_filecontent);
            int cursor = 0;
            for (int i = 0; i < RowCount; i++)
            {
                var row = buffer.Slice(cursor, ROWSIZE);
                cursor += ROWSIZE;

                //result.Foo1 = Foo.ReadWithSpan(row, _encoding);
                //result.Foo2 = FooInt.ReadWithSpan(row, _encoding);
                //result.FooList.Add(FooLarge.ReadWithSpan(row, _encoding));
                result.FooLarge = FooLarge.ReadWithSpan(row, _encoding);
            }
            return result;
        }

        [Benchmark]
        public FooResult WithoutSpan()
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
                    //result.Foo1 = Foo.Read(row);
                    //result.FooList.Add(FooLarge.Read(row));
                    result.FooLarge = FooLarge.Read(row);
            }
            }
            return result;
        }
    }

    
}
