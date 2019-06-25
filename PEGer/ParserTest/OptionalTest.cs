using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PEGer;
using static TrueRegex.Predefined;

namespace ParserTest
{
    [TestClass]
    public class OptionalTest
    {
        static Regex<int> regex = Regex.Create(Number, (view, _) => int.Parse(view.ToString()));
        [TestMethod]
        public void OptionalTest1()
        {
            var expr = Optional.Create(regex, v => $"success: {v}", () => "failure");
            var parser = Parser.Create(expr);
            {
                Assert.IsTrue(parser.Parse("1", out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, "success: 1");
                Assert.AreEqual(end, 1);
            }
            {
                Assert.IsTrue(parser.Parse("a", out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, "failure");
                Assert.AreEqual(end, 0);
            }
        }

        [TestMethod]
        public void OptionalTest2()
        {
            var expr = Optional.Create(regex, () => -1);
            var parser = Parser.Create(expr);
            {
                Assert.IsTrue(parser.Parse("1", out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, 1);
                Assert.AreEqual(end, 1);
            }
            {
                Assert.IsTrue(parser.Parse("a", out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, -1);
                Assert.AreEqual(end, 0);
            }
        }
    }
}
