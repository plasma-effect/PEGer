using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PEGer;
using TrueRegex;
using static TrueRegex.Predefined;

namespace ParserTest
{
    [TestClass]
    public class ContinueTest
    {
        static String<string> first = "123".ToExpr();
        static String<string> second = "456".ToExpr();
        static String<string> third = "789".ToExpr();
        [TestMethod]
        public void SequenceTest()
        {
            var expr = Sequence<string>.Create(first, Continue.Create(second), third, (a, b, c) => "OK");
            var parser = Parser.Create(expr);
            {
                Assert.IsTrue(parser.Parse("123456789", out var ret, out _, out _));
                Assert.AreEqual(ret, "OK");
            }
            {
                Assert.IsFalse(parser.Parse("123789", out _, out var exceptions, out _));
                Assert.AreEqual(exceptions.Count, 1);
            }
        }

        [TestMethod]
        public void RepeatTest()
        {
            var seq = Sequence<string>.Create(first, second, (a, b) => "");
            var expr = Repeat<int>.Create(Continue.Create(seq), list => list.Count, 0, 2);
            var parser = Parser.Create(expr);
            {
                Assert.IsTrue(parser.Parse("123456123456", out var ret, out var exceptions, out _));
                Assert.AreEqual(ret, 2);
            }
            {
                Assert.IsFalse(parser.Parse("123123456", out _, out var exceptions, out _));
                Assert.AreEqual(exceptions.Count, 2);
            }
        }

        [TestMethod]
        public void MixTest()
        {
            var expr = Repeat<int>.Create(Sequence<string>.Create(first, Continue.Create(second), (a, b) => ""), list => list.Count);
            var parser = Parser.Create(expr);
            {
                Assert.IsTrue(parser.Parse("123456123456", out var ret, out var exceptions, out _));
                Assert.AreEqual(ret, 2);
            }
            {
                Assert.IsFalse(parser.Parse("123123456", out _, out var exceptions, out _));
                Assert.AreEqual(exceptions.Count, 1);
            }
        }
    }
}
