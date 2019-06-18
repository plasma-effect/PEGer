using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PEGer;
using static TrueRegex.Predefined;

namespace ParserTest
{
    [TestClass]
    public class RepeatTest
    {
        static int Sum(List<int> list)
        {
            var ret = 0;
            foreach (var v in list)
            {
                ret += v;
            }
            return ret;
        }
        static Regex<int> regex = Regex<int>.Create(Number, (view, _) => int.Parse(view.ToString()));

        [TestMethod]
        public void RepeatTest1()
        {
            var rep = Repeat<int>.Set(regex).Create(Sum);
            var value = Value.Create(rep);
            var parser = Parser.Create(value);
            {
                Assert.IsTrue(parser.Parse("1 2 3 4 a", out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, 10);
                Assert.AreEqual(end, 7);
            }
            {
                Assert.IsFalse(parser.ParseFullMatch("1 2 3 a", out var ret, out var exceptions));
            }
        }

        [TestMethod]
        public void RepeatTest2()
        {
            var rep = Repeat<int>.Set(regex).Create(Sum, 2);
            var value = Value.Create(rep);
            var parser = Parser.Create(value);
            {
                Assert.IsTrue(parser.Parse("1 2 3 4 a", out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, 10);
                Assert.AreEqual(end, 7);
            }
            {
                Assert.IsFalse(parser.Parse("1", out var ret, out var exceptions, out var end));
                Assert.IsTrue(exceptions[0].Exception is ArgumentOutOfRangeException);
            }
        }

        [TestMethod]
        public void RepeatTest3()
        {
            var rep = Repeat<int>.Set(regex).Create(Sum, 2, 3);
            var value = Value.Create(rep);
            var parser = Parser.Create(value);
            {
                Assert.IsTrue(parser.Parse("1 2 3 4", out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, 6);
                Assert.AreEqual(end, 5);
            }
            {
                Assert.IsFalse(parser.Parse("1", out var ret, out var exceptions, out var end));
                Assert.IsTrue(exceptions[0].Exception is ArgumentOutOfRangeException);
            }
        }

        [TestMethod]
        public void RepeatTest4()
        {
            var rep = Repeat<int>.Set(regex).Create(Sum, _ => new Exception("Test"));
            var value = Value.Create(rep);
            var parser = Parser.Create(value);
            {
                Assert.IsTrue(parser.Parse("1 2 3 4 a", out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, 10);
                Assert.AreEqual(end, 7);
            }
            {
                Assert.IsFalse(parser.ParseFullMatch("1 2 3 a", out var ret, out var exceptions));
            }
        }

        [TestMethod]
        public void RepeatTest5()
        {
            var rep = Repeat<int>.Set(regex).Create(Sum, 2, _ => new Exception("Test"));
            var value = Value.Create(rep);
            var parser = Parser.Create(value);
            {
                Assert.IsTrue(parser.Parse("1 2 3 4 a", out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, 10);
                Assert.AreEqual(end, 7);
            }
            {
                Assert.IsFalse(parser.Parse("1", out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions[0].Exception.Message, "Test");
            }
        }

        [TestMethod]
        public void RepeatTest6()
        {
            var rep = Repeat<int>.Set(regex).Create(Sum, 2, 3, _ => new Exception("Test"));
            var value = Value.Create(rep);
            var parser = Parser.Create(value);
            {
                Assert.IsTrue(parser.Parse("1 2 3 4 a", out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, 6);
                Assert.AreEqual(end, 5);
            }
            {
                Assert.IsFalse(parser.Parse("1", out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions[0].Exception.Message, "Test");
            }
        }
    }
}
