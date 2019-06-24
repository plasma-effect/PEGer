using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PEGer;
using TrueRegex;
using static TrueRegex.Predefined;

namespace ParserTest
{
    [TestClass]
    public class RecursiveTest
    {
        static Regex<int> number = Regex<int>.Create(Number, (view, _) => int.Parse(view.ToString()));
        static int Mul(List<int> list, int v)
        {
            foreach (var u in list)
            {
                v *= u;
            }
            return v;
        }
        static int Sum(List<int> list, int v)
        {
            foreach (var u in list)
            {
                v += u;
            }
            return v;
        }
        [TestMethod]
        public void AllTest()
        {
            var atomic = new Value<int>();
            var mul = Sequence<int>.Create(~Sequence<int>.Create(atomic, "*".ToExpr(), (v, _) => v), atomic, Mul);
            var sum = Sequence<int>.Create(~Sequence<int>.Create(mul, "+".ToExpr(), (v, _) => v), mul, Sum);
            atomic.Expr = Select<int>.Create(number, Sequence<int>.Create("(".ToExpr(), sum, ")".ToExpr(), (a, b, c) => b));
            var parser = Parser.Create(sum);
            {
                var text = "1 + 2 + 3 * 4 * 5 * (6 + 7 + 8) * 9";
                Assert.IsTrue(parser.Parse(text, out var ret, out _, out var end));
                Assert.AreEqual(ret, 1 + 2 + 3 * 4 * 5 * (6 + 7 + 8) * 9);
                Assert.AreEqual(text.Length, end);
            }
            {
                var text = "1 + 2 +";
                Assert.IsFalse(parser.Parse(text, out _, out _, out _));
            }
        }
    }
}
