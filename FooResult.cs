using System;
using System.Collections.Generic;
using System.Text;

namespace SpanTest
{
    public class FooResult
    {
        public Foo Foo1 { get; set; }
        public FooInt Foo2 { get; set; }

        public FooLarge FooLarge { get; set; }

        public List<IFoo> FooList { get; set; } = new List<IFoo>();
    }
}
