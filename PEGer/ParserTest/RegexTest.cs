using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PEGer;
using static TrueRegex.Predefined;

namespace ParserTest
{
    [TestClass]
    public class RegexTest
    {
        [TestMethod]
        public void RegexTest1()
        {
            var regex = Regex.Create(Number,
                (view, index) => int.Parse(view.ToString()));
            var parser = Parser.Create(regex);
            {
                Assert.IsTrue(parser.Parse("123", out var ret, out var exceptions,out var end));
                Assert.AreEqual(ret, 123);
                Assert.AreEqual(end, 3);
            }
            {
                Assert.IsTrue(parser.Parse("12a", out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, 12);
                Assert.AreEqual(end, 2);
            }
            {
                Assert.IsFalse(parser.Parse("abc", out var ret, out var exceptions, out var end));
            }
            {
                Assert.IsFalse(parser.ParseFullMatch("12a", out var ret, out var exceptions));
            }
        }

        [TestMethod]
        public void RegexTest2()
        {
            var regex = Regex.Create(Number,
                (view, index) => int.Parse(view.ToString()),
                () => new Exception("Parse Error"));
            var parser = Parser.Create(regex);
            {
                Assert.IsTrue(parser.Parse("123", out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, 123);
                Assert.AreEqual(end, 3);
            }
            {
                Assert.IsTrue(parser.Parse("12a", out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, 12);
                Assert.AreEqual(end, 2);
            }
            {
                Assert.IsFalse(parser.Parse("abc", out var ret, out var exceptions, out var end));
            }
            {
                Assert.IsFalse(parser.ParseFullMatch("12a", out var ret, out var exceptions));
            }
        }

        [TestMethod]
        public void RegexTest3()
        {
            var regex = Regex.Create(Name);
            var parser = Parser.Create(regex);
            {
                Assert.IsTrue(parser.Parse("abc+", out var ret, out _, out var end));
                Assert.AreEqual(ret, "abc");
                Assert.AreEqual(end, 3);
            }
            {
                Assert.IsFalse(parser.ParseFullMatch("abc+", out _, out _));
            }
        }

        [TestMethod]
        public void RegexTest4()
        {
            var regex = Regex.Create(+TrueRegex.Predefined.String.Create("aa"), false);
            var parser = Parser.Create(regex);
            {
                Assert.IsTrue(parser.Parse("aaaaaa", out var ret, out _, out _));
                Assert.AreEqual(ret, "aa");
            }
        }

        [TestMethod]
        public void RegexTest5()
        {
            var parser = Parser.Create(Number.ToExpr());
            {
                Assert.IsTrue(parser.Parse("123", out var ret, out _, out _));
                Assert.AreEqual(ret.ToString(), "123");
            }
        }

        [TestMethod]
        public void RegexTest6()
        {
            var parser = Parser.Create(Number.ToExpr((view, _) => int.Parse(view)));
            {
                Assert.IsTrue(parser.Parse("123", out var ret, out _, out _));
                Assert.AreEqual(ret, 123);
            }
        }

        [TestMethod]
        public void RegexTest7()
        {
            var parser = Parser.Create(Number.ToExpr((view, _) => int.Parse(view), () => new Exception("Fails")));
            {
                Assert.IsTrue(parser.Parse("123", out var ret, out _, out _));
                Assert.AreEqual(ret, 123);
            }
            {
                Assert.IsFalse(parser.Parse("abc", out _, out var exceptions, out _));
                Assert.AreEqual(exceptions[0].Exception.Message, "Fails");
            }
        }
    }
}
