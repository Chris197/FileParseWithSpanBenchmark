using System;
using System.Collections.Generic;
using System.Text;

namespace SpanTest
{
    public interface IFoo
    {

    }
    public class Foo : IFoo
    {
        public string Field1 { get; set; }
        public string Field2 { get; set; }
        public string Field3 { get; set; }
        public string Field4 { get; set; }
        public string Field5 { get; set; }
        public string Field6 { get; set; }
        public string Field7 { get; set; }
        public string Field8 { get; set; }
        public string Field9 { get; set; }
        public string Field10 { get; set; }

        public static Foo Read(string buffer)
            => new Foo
            {
                Field1 = buffer.Read(1, 2),
                Field2 = buffer.Read(3, 4),
                Field3 = buffer.Read(5, 6),
                Field4 = buffer.Read(7, 11),
                Field5 = buffer.Read(12, 17),
                Field6 = buffer.Read(20, 21),
                Field7 = buffer.Read(22, 25),
                Field8 = buffer.Read(26, 30),
                Field9 = buffer.Read(37, 40),
                Field10 = buffer.Read(49, 53)
            };

        public static Foo ReadWithSpan(ReadOnlySpan<byte> buffer, Encoding encoding)
            => new Foo
            {
                Field1 = buffer.Read(1, 2, encoding),
                Field2 = buffer.Read(3, 4, encoding),
                Field3 = buffer.Read(5, 6, encoding),
                Field4 = buffer.Read(7, 11, encoding),
                Field5 = buffer.Read(12, 17, encoding),
                Field6 = buffer.Read(20, 21, encoding),
                Field7 = buffer.Read(22, 25, encoding),
                Field8 = buffer.Read(26, 30, encoding),
                Field9 = buffer.Read(37, 40, encoding),
                Field10 = buffer.Read(49, 53, encoding)
            };
    }

    public class FooInt : IFoo
    {
        public int Field1 { get; set; }
        public int Field2 { get; set; }
        public int Field3 { get; set; }
        public int Field4 { get; set; }
        public int Field5 { get; set; }
        public int Field6 { get; set; }
        public int Field7 { get; set; }
        public int Field8 { get; set; }
        public int Field9 { get; set; }
        public int Field10 { get; set; }

        public static FooInt Read(string buffer)
            => new FooInt
            {
                Field1 = buffer.ReadInt(1, 2),
                Field2 = buffer.ReadInt(3, 4),
                Field3 = buffer.ReadInt(5, 6),
                Field4 = buffer.ReadInt(7, 11),
                Field5 = buffer.ReadInt(12, 17),
                Field6 = buffer.ReadInt(20, 21),
                Field7 = buffer.ReadInt(22, 25),
                Field8 = buffer.ReadInt(26, 30),
                Field9 = buffer.ReadInt(37, 40),
                Field10 = buffer.ReadInt(49, 53)
            };

        public static FooInt ReadWithSpan(ReadOnlySpan<byte> buffer, Encoding encoding)
            => new FooInt
            {
                Field1 = buffer.ReadInt(1, 2, encoding),
                Field2 = buffer.ReadInt(3, 4, encoding),
                Field3 = buffer.ReadInt(5, 6, encoding),
                Field4 = buffer.ReadInt(7, 11, encoding),
                Field5 = buffer.ReadInt(12, 17, encoding),
                Field6 = buffer.ReadInt(20, 21, encoding),
                Field7 = buffer.ReadInt(22, 25, encoding),
                Field8 = buffer.ReadInt(26, 30, encoding),
                Field9 = buffer.ReadInt(37, 40, encoding),
                Field10 = buffer.ReadInt(49, 53, encoding)
            };
    }

    public class FooLarge : IFoo
    {
        public string Field1 { get; set; }
        public string Field2 { get; set; }
        public string Field3 { get; set; }
        public string Field4 { get; set; }
        public string Field5 { get; set; }
        public string Field6 { get; set; }
        public string Field7 { get; set; }
        public string Field8 { get; set; }
        public string Field9 { get; set; }
        public string Field10 { get; set; }
        public string Field11 { get; set; }
        public string Field12 { get; set; }
        public string Field13 { get; set; }
        public string Field14 { get; set; }
        public string Field15 { get; set; }
        public string Field16 { get; set; }
        public string Field17 { get; set; }
        public string Field18 { get; set; }
        public string Field19 { get; set; }
        public string Field20 { get; set; }
        public string Field21 { get; set; }
        public string Field22 { get; set; }
        public string Field23 { get; set; }
        public string Field24 { get; set; }
        public string Field25 { get; set; }
        public string Field26 { get; set; }
        public string Field27 { get; set; }
        public string Field28 { get; set; }
        public string Field29 { get; set; }
        public string Field30 { get; set; }
        public string Source { get; set; }

        public static FooLarge Read(string buffer)
            => new FooLarge
            {
                Field1 = buffer.Read(1, 2),
                Field2 = buffer.Read(3, 4),
                Field3 = buffer.Read(5, 6),
                Field4 = buffer.Read(7, 11),
                Field5 = buffer.Read(12, 17),
                Field6 = buffer.Read(20, 21),
                Field7 = buffer.Read(22, 25),
                Field8 = buffer.Read(26, 30),
                Field9 = buffer.Read(37, 40),
                Field10 = buffer.Read(49, 53),
                Field11 = buffer.Read(54, 81),
                Field12 = buffer.Read(82, 89),
                Field13 = buffer.Read(90, 90),
                Field14 = buffer.Read(91, 93),
                Field15 = buffer.Read(94, 100),
                Field16 = buffer.Read(101, 107),
                Field17 = buffer.Read(108, 108),
                Field18 = buffer.Read(109, 111),
                Field19 = buffer.Read(112, 114),
                Field20 = buffer.Read(115, 117),
                Field21 = buffer.Read(118, 120),
                Field22 = buffer.Read(121, 130),
                Field23 = buffer.Read(131, 158),
                Field24 = buffer.Read(159, 186),
                Field25 = buffer.Read(187, 206),
                Field26 = buffer.Read(207, 210),
                Field27 = buffer.Read(211, 213),
                Field28 = buffer.Read(214, 241),
                Field29 = buffer.Read(242, 244),
                Field30 = buffer.Read(246, 250)
                //,Source = buffer
            };

        public static FooLarge ReadWithSpan(ReadOnlySpan<byte> buffer, Encoding encoding)
            => new FooLarge
            {
                Field1 = buffer.Read(1, 2, encoding),
                Field2 = buffer.Read(3, 4, encoding),
                Field3 = buffer.Read(5, 6, encoding),
                Field4 = buffer.Read(7, 11, encoding),
                Field5 = buffer.Read(12, 17, encoding),
                Field6 = buffer.Read(20, 21, encoding),
                Field7 = buffer.Read(22, 25, encoding),
                Field8 = buffer.Read(26, 30, encoding),
                Field9 = buffer.Read(37, 40, encoding),
                Field10 = buffer.Read(49, 53, encoding),
                Field11 = buffer.Read(54, 81, encoding),
                Field12 = buffer.Read(82, 89, encoding),
                Field13 = buffer.Read(90, 90, encoding),
                Field14 = buffer.Read(91, 93, encoding),
                Field15 = buffer.Read(94, 100, encoding),
                Field16 = buffer.Read(101, 107, encoding),
                Field17 = buffer.Read(108, 108, encoding),
                Field18 = buffer.Read(109, 111, encoding),
                Field19 = buffer.Read(112, 114, encoding),
                Field20 = buffer.Read(115, 117, encoding),
                Field21 = buffer.Read(118, 120, encoding),
                Field22 = buffer.Read(121, 130, encoding),
                Field23 = buffer.Read(131, 158, encoding),
                Field24 = buffer.Read(159, 186, encoding),
                Field25 = buffer.Read(187, 206, encoding),
                Field26 = buffer.Read(207, 210, encoding),
                Field27 = buffer.Read(211, 213, encoding),
                Field28 = buffer.Read(214, 241, encoding),
                Field29 = buffer.Read(242, 244, encoding),
                Field30 = buffer.Read(246, 250, encoding)
                //,Source = encoding.GetString(buffer)
            };
    }
}
