using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PEGer;
using TrueRegex;
using UtilityLibrary;
using static TrueRegex.Predefined;

namespace ParserTest
{
    [TestClass]
    public class PredicateTest
    {
        static ExpressionBase<StringView> baseExpr = Regex.Create(Number);
        static Exception TestCustomException(int index)
        {
            return new Exception($"error: {index}");
        }

        [TestMethod]
        public void AndPredicateTest()
        {
            var expr = AndPredicate.Create(baseExpr);
            var parser = Parser.Create(expr);
            {
                Assert.IsTrue(parser.Parse("123", out var ret, out _, out var end));
                Assert.AreEqual("123", ret.ToString());
                Assert.AreEqual(end, 0);
            }
            {
                Assert.IsFalse(parser.Parse("abc", out _, out _, out _));
            }
        }

        [TestMethod]
        public void NotPredicateTest1()
        {
            var expr = NotPredicate.Create(baseExpr, 1);
            var parser = Parser.Create(expr);
            {
                Assert.IsFalse(parser.Parse("123", out _, out _, out _));
            }
            {
                Assert.IsTrue(parser.Parse("abc", out var ret, out _, out var end));
                Assert.AreEqual(ret, 1);
                Assert.AreEqual(end, 0);
            }
        }

        [TestMethod]
        public void NotPredicateTest2()
        {
            var expr = NotPredicate.Create(baseExpr, 1, TestCustomException);
            var parser = Parser.Create(expr);
            {
                Assert.IsFalse(parser.Parse("123", out _, out var exceptions, out _));
                Assert.AreEqual(exceptions[0].Exception.Message, "error: 0");
            }
            {
                Assert.IsTrue(parser.Parse("abc", out var ret, out _, out var end));
                Assert.AreEqual(ret, 1);
                Assert.AreEqual(end, 0);
            }
        }

        [TestMethod]
        public void NotPredicateTest3()
        {
            var expr = NotPredicate.Create(baseExpr, (index) => index + 1);
            var parser = Parser.Create(expr);
            {
                Assert.IsFalse(parser.Parse("123", out _, out _, out _));
            }
            {
                Assert.IsTrue(parser.Parse("abc", out var ret, out _, out var end));
                Assert.AreEqual(ret, 1);
                Assert.AreEqual(end, 0);
            }
        }

        [TestMethod]
        public void NotPredicateTest4()
        {
            var expr = NotPredicate.Create(baseExpr, (index) => index + 1, TestCustomException);
            var parser = Parser.Create(expr);
            {
                Assert.IsFalse(parser.Parse("123", out _, out var exceptions, out _));
                Assert.AreEqual(exceptions[0].Exception.Message, "error: 0");
            }
            {
                Assert.IsTrue(parser.Parse("abc", out var ret, out _, out var end));
                Assert.AreEqual(ret, 1);
                Assert.AreEqual(end, 0);
            }
        }
    }
}
