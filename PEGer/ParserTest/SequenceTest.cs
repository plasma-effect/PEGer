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
    public class SequenceTest
    {
        static Regex<int> number = Regex<int>.Create(Number, (view, _) => int.Parse(view.ToString()));
        static Regex<string> plus = Regex.Create(Predefined.String.Create("+"));

        static int SumParams(params int[] vs)
        {
            return vs.Sum();
        }
        #region sums
        static int Sum(int a1, int a2)
        {
            return SumParams(a1, a2);
        }

        static int Sum(int a1, int a2, int a3)
        {
            return SumParams(a1, a2, a3);
        }

        static int Sum(int a1, int a2, int a3, int a4)
        {
            return SumParams(a1, a2, a3, a4);
        }

        static int Sum(int a1, int a2, int a3, int a4, int a5)
        {
            return SumParams(a1, a2, a3, a4, a5);
        }

        static int Sum(int a1, int a2, int a3, int a4, int a5, int a6)
        {
            return SumParams(a1, a2, a3, a4, a5, a6);
        }

        static int Sum(int a1, int a2, int a3, int a4, int a5, int a6, int a7)
        {
            return SumParams(a1, a2, a3, a4, a5, a6, a7);
        }

        static int Sum(int a1, int a2, int a3, int a4, int a5, int a6, int a7, int a8)
        {
            return SumParams(a1, a2, a3, a4, a5, a6, a7, a8);
        }

        static int Sum(int a1, int a2, int a3, int a4, int a5, int a6, int a7, int a8, int a9)
        {
            return SumParams(a1, a2, a3, a4, a5, a6, a7, a8, a9);
        }

        static int Sum(int a1, int a2, int a3, int a4, int a5, int a6, int a7, int a8, int a9, int a10)
        {
            return SumParams(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10);
        }

        static int Sum(int a1, int a2, int a3, int a4, int a5, int a6, int a7, int a8, int a9, int a10, int a11)
        {
            return SumParams(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11);
        }

        static int Sum(int a1, int a2, int a3, int a4, int a5, int a6, int a7, int a8, int a9, int a10, int a11, int a12)
        {
            return SumParams(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12);
        }

        static int Sum(int a1, int a2, int a3, int a4, int a5, int a6, int a7, int a8, int a9, int a10, int a11, int a12, int a13)
        {
            return SumParams(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13);
        }

        static int Sum(int a1, int a2, int a3, int a4, int a5, int a6, int a7, int a8, int a9, int a10, int a11, int a12, int a13, int a14)
        {
            return SumParams(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14);
        }

        static int Sum(int a1, int a2, int a3, int a4, int a5, int a6, int a7, int a8, int a9, int a10, int a11, int a12, int a13, int a14, int a15)
        {
            return SumParams(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15);
        }

        static int Sum(int a1, int a2, int a3, int a4, int a5, int a6, int a7, int a8, int a9, int a10, int a11, int a12, int a13, int a14, int a15, int a16)
        {
            return SumParams(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15, a16);
        }
        #endregion
        static Exception CustomError(ParsingException exception, int index)
        {
            return new Exception($"error: {index}");
        }

        [TestMethod]
        public void SequenceTest2NoError()
        {
            var expr = Sequence<int>.Create(number, number, Sum);
            var parser = Parser.Create(expr);
            {
                Assert.IsTrue(parser.Parse("1 2", out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, 3);
                Assert.AreEqual(end, 3);
            }
            {
                Assert.IsFalse(parser.Parse("1", out var ret, out var exceptions, out var end));
            }
        }

        [TestMethod]
        public void SequenceTest2WithError()
        {
            var expr = Sequence<int>.Create(number, number, Sum, CustomError);
            var parser = Parser.Create(expr);
            {
                Assert.IsTrue(parser.Parse("1 2", out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, 3);
                Assert.AreEqual(end, 3);
            }
            {
                Assert.IsFalse(parser.Parse("1", out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions[0].Exception.Message, "error: 1");
            }
        }

        [TestMethod]
        public void SequenceTest3NoError()
        {
            var expr = Sequence<int>.Create(number, number, number, Sum);
            var parser = Parser.Create(expr);
            {
                Assert.IsTrue(parser.Parse("1 2 3", out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, 6);
                Assert.AreEqual(end, 5);
            }
            {
                Assert.IsFalse(parser.Parse("2 3", out var ret, out var exceptions, out var end));
            }
        }

        [TestMethod]
        public void SequenceTest3WithError()
        {
            var expr = Sequence<int>.Create(number, number, number, Sum, CustomError);
            var parser = Parser.Create(expr);
            {
                Assert.IsTrue(parser.Parse("1 2 3", out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, 6);
                Assert.AreEqual(end, 5);
            }
            {
                Assert.IsFalse(parser.Parse("2 3", out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions[0].Exception.Message, "error: 2");
            }
        }

        [TestMethod]
        public void SequenceTest4NoError()
        {
            var expr = Sequence<int>.Create(number, number, number, number, Sum);
            var parser = Parser.Create(expr);
            {
                Assert.IsTrue(parser.Parse("1 2 3 4", out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, 10);
                Assert.AreEqual(end, 7);
            }
            {
                Assert.IsFalse(parser.Parse("2 3 4", out var ret, out var exceptions, out var end));
            }
        }

        [TestMethod]
        public void SequenceTest4WithError()
        {
            var expr = Sequence<int>.Create(number, number, number, number, Sum, CustomError);
            var parser = Parser.Create(expr);
            {
                Assert.IsTrue(parser.Parse("1 2 3 4", out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, 10);
                Assert.AreEqual(end, 7);
            }
            {
                Assert.IsFalse(parser.Parse("2 3 4", out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions[0].Exception.Message, "error: 3");
            }
        }

        [TestMethod]
        public void SequenceTest5NoError()
        {
            var expr = Sequence<int>.Create(number, number, number, number, number, Sum);
            var parser = Parser.Create(expr);
            {
                Assert.IsTrue(parser.Parse("1 2 3 4 5", out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, 15);
                Assert.AreEqual(end, 9);
            }
            {
                Assert.IsFalse(parser.Parse("2 3 4 5", out var ret, out var exceptions, out var end));
            }
        }

        [TestMethod]
        public void SequenceTest5WithError()
        {
            var expr = Sequence<int>.Create(number, number, number, number, number, Sum, CustomError);
            var parser = Parser.Create(expr);
            {
                Assert.IsTrue(parser.Parse("1 2 3 4 5", out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, 15);
                Assert.AreEqual(end, 9);
            }
            {
                Assert.IsFalse(parser.Parse("2 3 4 5", out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions[0].Exception.Message, "error: 4");
            }
        }

        [TestMethod]
        public void SequenceTest6NoError()
        {
            var expr = Sequence<int>.Create(number, number, number, number, number, number, Sum);
            var parser = Parser.Create(expr);
            {
                Assert.IsTrue(parser.Parse("1 2 3 4 5 6", out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, 21);
                Assert.AreEqual(end, 11);
            }
            {
                Assert.IsFalse(parser.Parse("2 3 4 5 6", out var ret, out var exceptions, out var end));
            }
        }

        [TestMethod]
        public void SequenceTest6WithError()
        {
            var expr = Sequence<int>.Create(number, number, number, number, number, number, Sum, CustomError);
            var parser = Parser.Create(expr);
            {
                Assert.IsTrue(parser.Parse("1 2 3 4 5 6", out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, 21);
                Assert.AreEqual(end, 11);
            }
            {
                Assert.IsFalse(parser.Parse("2 3 4 5 6", out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions[0].Exception.Message, "error: 5");
            }
        }

        [TestMethod]
        public void SequenceTest7NoError()
        {
            var expr = Sequence<int>.Create(number, number, number, number, number, number, number, Sum);
            var parser = Parser.Create(expr);
            {
                Assert.IsTrue(parser.Parse("1 2 3 4 5 6 7", out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, 28);
                Assert.AreEqual(end, 13);
            }
            {
                Assert.IsFalse(parser.Parse("2 3 4 5 6 7", out var ret, out var exceptions, out var end));
            }
        }

        [TestMethod]
        public void SequenceTest7WithError()
        {
            var expr = Sequence<int>.Create(number, number, number, number, number, number, number, Sum, CustomError);
            var parser = Parser.Create(expr);
            {
                Assert.IsTrue(parser.Parse("1 2 3 4 5 6 7", out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, 28);
                Assert.AreEqual(end, 13);
            }
            {
                Assert.IsFalse(parser.Parse("2 3 4 5 6 7", out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions[0].Exception.Message, "error: 6");
            }
        }

        [TestMethod]
        public void SequenceTest8NoError()
        {
            var expr = Sequence<int>.Create(number, number, number, number, number, number, number, number, Sum);
            var parser = Parser.Create(expr);
            {
                Assert.IsTrue(parser.Parse("1 2 3 4 5 6 7 8", out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, 36);
                Assert.AreEqual(end, 15);
            }
            {
                Assert.IsFalse(parser.Parse("2 3 4 5 6 7 8", out var ret, out var exceptions, out var end));
            }
        }

        [TestMethod]
        public void SequenceTest8WithError()
        {
            var expr = Sequence<int>.Create(number, number, number, number, number, number, number, number, Sum, CustomError);
            var parser = Parser.Create(expr);
            {
                Assert.IsTrue(parser.Parse("1 2 3 4 5 6 7 8", out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, 36);
                Assert.AreEqual(end, 15);
            }
            {
                Assert.IsFalse(parser.Parse("2 3 4 5 6 7 8", out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions[0].Exception.Message, "error: 7");
            }
        }

        [TestMethod]
        public void SequenceTest9NoError()
        {
            var expr = Sequence<int>.Create(number, number, number, number, number, number, number, number, number, Sum);
            var parser = Parser.Create(expr);
            {
                Assert.IsTrue(parser.Parse("1 2 3 4 5 6 7 8 9", out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, 45);
                Assert.AreEqual(end, 17);
            }
            {
                Assert.IsFalse(parser.Parse("2 3 4 5 6 7 8 9", out var ret, out var exceptions, out var end));
            }
        }

        [TestMethod]
        public void SequenceTest9WithError()
        {
            var expr = Sequence<int>.Create(number, number, number, number, number, number, number, number, number, Sum, CustomError);
            var parser = Parser.Create(expr);
            {
                Assert.IsTrue(parser.Parse("1 2 3 4 5 6 7 8 9", out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, 45);
                Assert.AreEqual(end, 17);
            }
            {
                Assert.IsFalse(parser.Parse("2 3 4 5 6 7 8 9", out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions[0].Exception.Message, "error: 8");
            }
        }

        [TestMethod]
        public void SequenceTest10NoError()
        {
            var expr = Sequence<int>.Create(number, number, number, number, number, number, number, number, number, number, Sum);
            var parser = Parser.Create(expr);
            {
                Assert.IsTrue(parser.Parse("1 2 3 4 5 6 7 8 9 10", out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, 55);
                Assert.AreEqual(end, 20);
            }
            {
                Assert.IsFalse(parser.Parse("2 3 4 5 6 7 8 9 10", out var ret, out var exceptions, out var end));
            }
        }

        [TestMethod]
        public void SequenceTest10WithError()
        {
            var expr = Sequence<int>.Create(number, number, number, number, number, number, number, number, number, number, Sum, CustomError);
            var parser = Parser.Create(expr);
            {
                Assert.IsTrue(parser.Parse("1 2 3 4 5 6 7 8 9 10", out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, 55);
                Assert.AreEqual(end, 20);
            }
            {
                Assert.IsFalse(parser.Parse("2 3 4 5 6 7 8 9 10", out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions[0].Exception.Message, "error: 9");
            }
        }

        [TestMethod]
        public void SequenceTest11NoError()
        {
            var expr = Sequence<int>.Create(number, number, number, number, number, number, number, number, number, number, number, Sum);
            var parser = Parser.Create(expr);
            {
                Assert.IsTrue(parser.Parse("1 2 3 4 5 6 7 8 9 10 11", out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, 66);
                Assert.AreEqual(end, 23);
            }
            {
                Assert.IsFalse(parser.Parse("2 3 4 5 6 7 8 9 10 11", out var ret, out var exceptions, out var end));
            }
        }

        [TestMethod]
        public void SequenceTest11WithError()
        {
            var expr = Sequence<int>.Create(number, number, number, number, number, number, number, number, number, number, number, Sum, CustomError);
            var parser = Parser.Create(expr);
            {
                Assert.IsTrue(parser.Parse("1 2 3 4 5 6 7 8 9 10 11", out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, 66);
                Assert.AreEqual(end, 23);
            }
            {
                Assert.IsFalse(parser.Parse("2 3 4 5 6 7 8 9 10 11", out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions[0].Exception.Message, "error: 10");
            }
        }

        [TestMethod]
        public void SequenceTest12NoError()
        {
            var expr = Sequence<int>.Create(number, number, number, number, number, number, number, number, number, number, number, number, Sum);
            var parser = Parser.Create(expr);
            {
                Assert.IsTrue(parser.Parse("1 2 3 4 5 6 7 8 9 10 11 12", out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, 78);
                Assert.AreEqual(end, 26);
            }
            {
                Assert.IsFalse(parser.Parse("2 3 4 5 6 7 8 9 10 11 12", out var ret, out var exceptions, out var end));
            }
        }

        [TestMethod]
        public void SequenceTest12WithError()
        {
            var expr = Sequence<int>.Create(number, number, number, number, number, number, number, number, number, number, number, number, Sum, CustomError);
            var parser = Parser.Create(expr);
            {
                Assert.IsTrue(parser.Parse("1 2 3 4 5 6 7 8 9 10 11 12", out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, 78);
                Assert.AreEqual(end, 26);
            }
            {
                Assert.IsFalse(parser.Parse("2 3 4 5 6 7 8 9 10 11 12", out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions[0].Exception.Message, "error: 11");
            }
        }

        [TestMethod]
        public void SequenceTest13NoError()
        {
            var expr = Sequence<int>.Create(number, number, number, number, number, number, number, number, number, number, number, number, number, Sum);
            var parser = Parser.Create(expr);
            {
                Assert.IsTrue(parser.Parse("1 2 3 4 5 6 7 8 9 10 11 12 13", out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, 91);
                Assert.AreEqual(end, 29);
            }
            {
                Assert.IsFalse(parser.Parse("2 3 4 5 6 7 8 9 10 11 12 13", out var ret, out var exceptions, out var end));
            }
        }

        [TestMethod]
        public void SequenceTest13WithError()
        {
            var expr = Sequence<int>.Create(number, number, number, number, number, number, number, number, number, number, number, number, number, Sum, CustomError);
            var parser = Parser.Create(expr);
            {
                Assert.IsTrue(parser.Parse("1 2 3 4 5 6 7 8 9 10 11 12 13", out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, 91);
                Assert.AreEqual(end, 29);
            }
            {
                Assert.IsFalse(parser.Parse("2 3 4 5 6 7 8 9 10 11 12 13", out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions[0].Exception.Message, "error: 12");
            }
        }

        [TestMethod]
        public void SequenceTest14NoError()
        {
            var expr = Sequence<int>.Create(number, number, number, number, number, number, number, number, number, number, number, number, number, number, Sum);
            var parser = Parser.Create(expr);
            {
                Assert.IsTrue(parser.Parse("1 2 3 4 5 6 7 8 9 10 11 12 13 14", out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, 105);
                Assert.AreEqual(end, 32);
            }
            {
                Assert.IsFalse(parser.Parse("2 3 4 5 6 7 8 9 10 11 12 13 14", out var ret, out var exceptions, out var end));
            }
        }

        [TestMethod]
        public void SequenceTest14WithError()
        {
            var expr = Sequence<int>.Create(number, number, number, number, number, number, number, number, number, number, number, number, number, number, Sum, CustomError);
            var parser = Parser.Create(expr);
            {
                Assert.IsTrue(parser.Parse("1 2 3 4 5 6 7 8 9 10 11 12 13 14", out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, 105);
                Assert.AreEqual(end, 32);
            }
            {
                Assert.IsFalse(parser.Parse("2 3 4 5 6 7 8 9 10 11 12 13 14", out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions[0].Exception.Message, "error: 13");
            }
        }

        [TestMethod]
        public void SequenceTest15NoError()
        {
            var expr = Sequence<int>.Create(number, number, number, number, number, number, number, number, number, number, number, number, number, number, number, Sum);
            var parser = Parser.Create(expr);
            {
                Assert.IsTrue(parser.Parse("1 2 3 4 5 6 7 8 9 10 11 12 13 14 15", out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, 120);
                Assert.AreEqual(end, 35);
            }
            {
                Assert.IsFalse(parser.Parse("2 3 4 5 6 7 8 9 10 11 12 13 14 15", out var ret, out var exceptions, out var end));
            }
        }

        [TestMethod]
        public void SequenceTest15WithError()
        {
            var expr = Sequence<int>.Create(number, number, number, number, number, number, number, number, number, number, number, number, number, number, number, Sum, CustomError);
            var parser = Parser.Create(expr);
            {
                Assert.IsTrue(parser.Parse("1 2 3 4 5 6 7 8 9 10 11 12 13 14 15", out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, 120);
                Assert.AreEqual(end, 35);
            }
            {
                Assert.IsFalse(parser.Parse("2 3 4 5 6 7 8 9 10 11 12 13 14 15", out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions[0].Exception.Message, "error: 14");
            }
        }

        [TestMethod]
        public void SequenceTest16NoError()
        {
            var expr = Sequence<int>.Create(number, number, number, number, number, number, number, number, number, number, number, number, number, number, number, number, Sum);
            var parser = Parser.Create(expr);
            {
                Assert.IsTrue(parser.Parse("1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16", out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, 136);
                Assert.AreEqual(end, 38);
            }
            {
                Assert.IsFalse(parser.Parse("2 3 4 5 6 7 8 9 10 11 12 13 14 15 16", out var ret, out var exceptions, out var end));
            }
        }

        [TestMethod]
        public void SequenceTest16WithError()
        {
            var expr = Sequence<int>.Create(number, number, number, number, number, number, number, number, number, number, number, number, number, number, number, number, Sum, CustomError);
            var parser = Parser.Create(expr);
            {
                Assert.IsTrue(parser.Parse("1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16", out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, 136);
                Assert.AreEqual(end, 38);
            }
            {
                Assert.IsFalse(parser.Parse("2 3 4 5 6 7 8 9 10 11 12 13 14 15 16", out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions[0].Exception.Message, "error: 15");
            }
        }

        [TestMethod]
        public void CustomSequenceTestNoError()
        {
            var expr = Sequence<int>.Create(number, plus, number, (a, _, b) => a + b);
            var parser = Parser.Create(expr);
            {
                Assert.IsTrue(parser.Parse("1 + 2", out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, 3);
                Assert.AreEqual(end, 5);
            }
            {
                Assert.IsFalse(parser.Parse("1 + a", out var ret, out var exceptions, out var end));
            }
        }

        [TestMethod]
        public void CustomSequenceTestWithError()
        {
            var expr = Sequence<int>.Create(number, plus, number, (a, _, b) => a + b,CustomError);
            var parser = Parser.Create(expr);
            {
                Assert.IsTrue(parser.Parse("1 + 2", out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, 3);
                Assert.AreEqual(end, 5);
            }
            {
                Assert.IsFalse(parser.Parse("1 + a", out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions[0].Exception.Message, "error: 2");
            }
        }
    }
}
