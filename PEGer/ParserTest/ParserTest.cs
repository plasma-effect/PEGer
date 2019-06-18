using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PEGer;

namespace ParserTest
{
    [TestClass]
    public class ParserTest
    {
        [TestMethod]
        public void RegexTest()
        {
            var regex = Regex<int>.Create(
                TrueRegex.Predefined.Number,
                (view, index) => int.Parse(view.ToString()));
            var value = Value.Create(regex);
            var parser = new Parser<int>(value);
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
    }
}
