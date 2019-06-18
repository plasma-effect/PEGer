using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PEGer;

namespace ParserTest
{
    [TestClass]
    public class RegexTest
    {
        [TestMethod]
        public void RegexTest1()
        {
            var regex = Regex<int>.Create(
                TrueRegex.Predefined.Number,
                (view, index) => int.Parse(view.ToString()));
            var value = Value.Create(regex);
            var parser = Parser.Create(value);
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
            var regex = Regex<int>.Create(
                TrueRegex.Predefined.Number,
                (view, index) => int.Parse(view.ToString()),
                () => new Exception("Parse Error"));
            var value = Value.Create(regex);
            var parser = Parser.Create(value);
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
            var regex = Regex.Create(TrueRegex.Predefined.Name);
            var value = Value.Create(regex);
            var parser = Parser.Create(value);
            {
                Assert.IsTrue(parser.Parse("abc+", out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, "abc");
                Assert.AreEqual(end, 3);
            }
            {
                Assert.IsFalse(parser.ParseFullMatch("abc+", out var ret, out var exceptions));
            }
        }
    }
}
