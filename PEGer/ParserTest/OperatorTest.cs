using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PEGer;
using TrueRegex;
using static TrueRegex.Predefined;
using static UtilityLibrary.IntegerEnumerable;

namespace ParserTest
{
    [TestClass]
    public class OperatorTest
    {
        [TestMethod]
        public void SelectTest()
        {
            var text = "abcdefghijklmnopqrstuvwxyz";
            var es = "abcdefghijklmnop".Select(c => c.ToString().ToExpr()).ToArray();
            var expr = es[0] | es[1] | es[2] | es[3] | es[4] | es[5] | es[6] | es[7] | es[8] | es[9] | es[10] | es[11] | es[12] | es[13] | es[14] | es[15];
            var parser = Parser.Create(expr);
            foreach(var i in Range(0, 16))
            {
                Assert.IsTrue(parser.Parse(text[i].ToString(), out _, out _, out _));
            }
            foreach (var i in Range(16, text.Length))
            {
                Assert.IsFalse(parser.Parse(text[i].ToString(), out _, out _, out _));
            }
        }

        [TestMethod]
        public void RepeatTest()
        {
            var expr = ~"123".ToExpr();
            var parser = Parser.Create(expr);
            {
                Assert.IsTrue(parser.Parse("123123", out _, out _, out _));
            }
            {
                Assert.IsTrue(parser.Parse("123124", out _, out _, out var end));
                Assert.AreEqual(end, 3);
            }
        }
    }
}
