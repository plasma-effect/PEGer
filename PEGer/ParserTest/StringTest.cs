using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PEGer;
using TrueRegex;

namespace ParserTest
{
    [TestClass]
    public class StringTest
    {
        [TestMethod]
        public void StringTest1()
        {
            var expr = String<int>.Create("123", i => i);
            var parser = Parser.Create(expr);
            {
                Assert.IsTrue(parser.Parse("  123", out var ret, out _, out var end));
                Assert.AreEqual(ret, 2);
                Assert.AreEqual(end, 5);
            }
            {
                Assert.IsFalse(parser.Parse("124", out _, out _, out _));
            }
        }

        [TestMethod]
        public void StringTest2()
        {
            var expr = String<int>.Create("123", i => i, v => new System.Exception($"Error: {v}"));
            var parser = Parser.Create(expr);
            {
                Assert.IsTrue(parser.Parse("  123", out var ret, out _, out var end));
                Assert.AreEqual(ret, 2);
                Assert.AreEqual(end, 5);
            }
            {
                Assert.IsFalse(parser.Parse("  124", out _, out var exceptions, out _));
                Assert.AreEqual(exceptions[0].Exception.Message, "Error: 2");
            }
        }

        [TestMethod]
        public void StringTest3()
        {
            var expr = String.Create("123");
            var parser = Parser.Create(expr);
            {
                Assert.IsTrue(parser.Parse("  123", out var ret, out _, out _));
                Assert.AreEqual(ret, "123");
            }
            {
                Assert.IsFalse(parser.Parse("  124", out _, out _, out _));
            }
        }

        [TestMethod]
        public void StringTest4()
        {
            var expr = String.Create("123", v => new System.Exception($"Error: {v}"));
            var parser = Parser.Create(expr);
            {
                Assert.IsTrue(parser.Parse("  123", out var ret, out _, out _));
                Assert.AreEqual(ret, "123");
            }
            {
                Assert.IsFalse(parser.Parse("  124", out _, out var exceptions, out _));
                Assert.AreEqual(exceptions[0].Exception.Message, "Error: 2");
            }
        }

        [TestMethod]
        public void StringTest5()
        {
            var parser = Parser.Create("123".ToExpr());
            {
                Assert.IsTrue(parser.Parse("  123", out var ret, out _, out _));
                Assert.AreEqual(ret, "123");
            }
            {
                Assert.IsFalse(parser.Parse("  124", out _, out _, out _));
            }
        }

        [TestMethod]
        public void StringTest6()
        {
            var parser = Parser.Create("123".ToExpr(i => i));
            {
                Assert.IsTrue(parser.Parse("  123", out var ret, out _, out var end));
                Assert.AreEqual(ret, 2);
                Assert.AreEqual(end, 5);
            }
            {
                Assert.IsFalse(parser.Parse("124", out _, out _, out _));
            }
        }

        [TestMethod]
        public void StringTest7()
        {
            var parser = Parser.Create("123".ToExpr(i => i, v => new System.Exception($"Error: {v}")));
            {
                Assert.IsTrue(parser.Parse("  123", out var ret, out _, out _));
                Assert.AreEqual(ret, 2);
            }
            {
                Assert.IsFalse(parser.Parse("  124", out _, out var exceptions, out _));
                Assert.AreEqual(exceptions[0].Exception.Message, "Error: 2");
            }
        }
    }
}
