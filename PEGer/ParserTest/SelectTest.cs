using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PEGer;
using static TrueRegex.Predefined;
using static UtilityLibrary.IntegerEnumerable;

namespace ParserTest
{
    [TestClass]
    public class SelectTest
    {
        const int N = 16;
        static String<string>[] strings;
        static Func<string, int>[] funcs;
        static string chars = "abcdefghijklmnopq";
        static SelectTest()
        {
            strings = new String<string>[N];
            funcs = new Func<string, int>[N];
            foreach (var i in Range(N))
            {
                strings[i] = chars[i].ToString().ToExpr();
                funcs[i] = _ => i * i;
            }
        }
        #region custom_exceptions
        static Exception CustomExceptionParams(params ParsingException[] exceptions)
        {
            return new Exception($"error: {exceptions.Length}");
        }
        static Exception CustomException(ParsingException exc1, ParsingException exc2)
        {
            return CustomExceptionParams(exc1, exc2);
        }
        static Exception CustomException(ParsingException exc1, ParsingException exc2, ParsingException exc3)
        {
            return CustomExceptionParams(exc1, exc2, exc3);
        }
        static Exception CustomException(ParsingException exc1, ParsingException exc2, ParsingException exc3, ParsingException exc4)
        {
            return CustomExceptionParams(exc1, exc2, exc3, exc4);
        }
        static Exception CustomException(ParsingException exc1, ParsingException exc2, ParsingException exc3, ParsingException exc4, ParsingException exc5)
        {
            return CustomExceptionParams(exc1, exc2, exc3, exc4, exc5);
        }
        static Exception CustomException(ParsingException exc1, ParsingException exc2, ParsingException exc3, ParsingException exc4, ParsingException exc5, ParsingException exc6)
        {
            return CustomExceptionParams(exc1, exc2, exc3, exc4, exc5, exc6);
        }
        static Exception CustomException(ParsingException exc1, ParsingException exc2, ParsingException exc3, ParsingException exc4, ParsingException exc5, ParsingException exc6, ParsingException exc7)
        {
            return CustomExceptionParams(exc1, exc2, exc3, exc4, exc5, exc6, exc7);
        }
        static Exception CustomException(ParsingException exc1, ParsingException exc2, ParsingException exc3, ParsingException exc4, ParsingException exc5, ParsingException exc6, ParsingException exc7, ParsingException exc8)
        {
            return CustomExceptionParams(exc1, exc2, exc3, exc4, exc5, exc6, exc7, exc8);
        }
        static Exception CustomException(ParsingException exc1, ParsingException exc2, ParsingException exc3, ParsingException exc4, ParsingException exc5, ParsingException exc6, ParsingException exc7, ParsingException exc8, ParsingException exc9)
        {
            return CustomExceptionParams(exc1, exc2, exc3, exc4, exc5, exc6, exc7, exc8, exc9);
        }
        static Exception CustomException(ParsingException exc1, ParsingException exc2, ParsingException exc3, ParsingException exc4, ParsingException exc5, ParsingException exc6, ParsingException exc7, ParsingException exc8, ParsingException exc9, ParsingException exc10)
        {
            return CustomExceptionParams(exc1, exc2, exc3, exc4, exc5, exc6, exc7, exc8, exc9, exc10);
        }
        static Exception CustomException(ParsingException exc1, ParsingException exc2, ParsingException exc3, ParsingException exc4, ParsingException exc5, ParsingException exc6, ParsingException exc7, ParsingException exc8, ParsingException exc9, ParsingException exc10, ParsingException exc11)
        {
            return CustomExceptionParams(exc1, exc2, exc3, exc4, exc5, exc6, exc7, exc8, exc9, exc10, exc11);
        }
        static Exception CustomException(ParsingException exc1, ParsingException exc2, ParsingException exc3, ParsingException exc4, ParsingException exc5, ParsingException exc6, ParsingException exc7, ParsingException exc8, ParsingException exc9, ParsingException exc10, ParsingException exc11, ParsingException exc12)
        {
            return CustomExceptionParams(exc1, exc2, exc3, exc4, exc5, exc6, exc7, exc8, exc9, exc10, exc11, exc12);
        }
        static Exception CustomException(ParsingException exc1, ParsingException exc2, ParsingException exc3, ParsingException exc4, ParsingException exc5, ParsingException exc6, ParsingException exc7, ParsingException exc8, ParsingException exc9, ParsingException exc10, ParsingException exc11, ParsingException exc12, ParsingException exc13)
        {
            return CustomExceptionParams(exc1, exc2, exc3, exc4, exc5, exc6, exc7, exc8, exc9, exc10, exc11, exc12, exc13);
        }
        static Exception CustomException(ParsingException exc1, ParsingException exc2, ParsingException exc3, ParsingException exc4, ParsingException exc5, ParsingException exc6, ParsingException exc7, ParsingException exc8, ParsingException exc9, ParsingException exc10, ParsingException exc11, ParsingException exc12, ParsingException exc13, ParsingException exc14)
        {
            return CustomExceptionParams(exc1, exc2, exc3, exc4, exc5, exc6, exc7, exc8, exc9, exc10, exc11, exc12, exc13, exc14);
        }
        static Exception CustomException(ParsingException exc1, ParsingException exc2, ParsingException exc3, ParsingException exc4, ParsingException exc5, ParsingException exc6, ParsingException exc7, ParsingException exc8, ParsingException exc9, ParsingException exc10, ParsingException exc11, ParsingException exc12, ParsingException exc13, ParsingException exc14, ParsingException exc15)
        {
            return CustomExceptionParams(exc1, exc2, exc3, exc4, exc5, exc6, exc7, exc8, exc9, exc10, exc11, exc12, exc13, exc14, exc15);
        }
        static Exception CustomException(ParsingException exc1, ParsingException exc2, ParsingException exc3, ParsingException exc4, ParsingException exc5, ParsingException exc6, ParsingException exc7, ParsingException exc8, ParsingException exc9, ParsingException exc10, ParsingException exc11, ParsingException exc12, ParsingException exc13, ParsingException exc14, ParsingException exc15, ParsingException exc16)
        {
            return CustomExceptionParams(exc1, exc2, exc3, exc4, exc5, exc6, exc7, exc8, exc9, exc10, exc11, exc12, exc13, exc14, exc15, exc16);
        }
        #endregion
        [TestMethod]
        public void SelectTest2CustomError()
        {
            const int K = 2;
            var expr = Select.Create(strings[0], strings[1], funcs[0], funcs[1], CustomException);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out _, out _));
                Assert.AreEqual(ret, i * i);
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions[0].Exception.Message, $"error: {K}");
            }
        }

        [TestMethod]
        public void SelectTest2NormalError()
        {
            const int K = 2;
            var expr = Select.Create(strings[0], strings[1], funcs[0], funcs[1]);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, i * i);
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions.Count, K + 1);
            }
        }
        [TestMethod]
        public void SelectTest3CustomError()
        {
            const int K = 3;
            var expr = Select.Create(strings[0], strings[1], strings[2], funcs[0], funcs[1], funcs[2], CustomException);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out _, out _));
                Assert.AreEqual(ret, i * i);
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions[0].Exception.Message, $"error: {K}");
            }
        }

        [TestMethod]
        public void SelectTest3NormalError()
        {
            const int K = 3;
            var expr = Select.Create(strings[0], strings[1], strings[2], funcs[0], funcs[1], funcs[2]);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, i * i);
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions.Count, K + 1);
            }
        }
        [TestMethod]
        public void SelectTest4CustomError()
        {
            const int K = 4;
            var expr = Select.Create(strings[0], strings[1], strings[2], strings[3], funcs[0], funcs[1], funcs[2], funcs[3], CustomException);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out _, out _));
                Assert.AreEqual(ret, i * i);
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions[0].Exception.Message, $"error: {K}");
            }
        }

        [TestMethod]
        public void SelectTest4NormalError()
        {
            const int K = 4;
            var expr = Select.Create(strings[0], strings[1], strings[2], strings[3], funcs[0], funcs[1], funcs[2], funcs[3]);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, i * i);
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions.Count, K + 1);
            }
        }
        [TestMethod]
        public void SelectTest5CustomError()
        {
            const int K = 5;
            var expr = Select.Create(strings[0], strings[1], strings[2], strings[3], strings[4], funcs[0], funcs[1], funcs[2], funcs[3], funcs[4], CustomException);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out _, out _));
                Assert.AreEqual(ret, i * i);
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions[0].Exception.Message, $"error: {K}");
            }
        }

        [TestMethod]
        public void SelectTest5NormalError()
        {
            const int K = 5;
            var expr = Select.Create(strings[0], strings[1], strings[2], strings[3], strings[4], funcs[0], funcs[1], funcs[2], funcs[3], funcs[4]);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, i * i);
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions.Count, K + 1);
            }
        }
        [TestMethod]
        public void SelectTest6CustomError()
        {
            const int K = 6;
            var expr = Select.Create(strings[0], strings[1], strings[2], strings[3], strings[4], strings[5], funcs[0], funcs[1], funcs[2], funcs[3], funcs[4], funcs[5], CustomException);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out _, out _));
                Assert.AreEqual(ret, i * i);
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions[0].Exception.Message, $"error: {K}");
            }
        }

        [TestMethod]
        public void SelectTest6NormalError()
        {
            const int K = 6;
            var expr = Select.Create(strings[0], strings[1], strings[2], strings[3], strings[4], strings[5], funcs[0], funcs[1], funcs[2], funcs[3], funcs[4], funcs[5]);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, i * i);
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions.Count, K + 1);
            }
        }
        [TestMethod]
        public void SelectTest7CustomError()
        {
            const int K = 7;
            var expr = Select.Create(strings[0], strings[1], strings[2], strings[3], strings[4], strings[5], strings[6], funcs[0], funcs[1], funcs[2], funcs[3], funcs[4], funcs[5], funcs[6], CustomException);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out _, out _));
                Assert.AreEqual(ret, i * i);
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions[0].Exception.Message, $"error: {K}");
            }
        }

        [TestMethod]
        public void SelectTest7NormalError()
        {
            const int K = 7;
            var expr = Select.Create(strings[0], strings[1], strings[2], strings[3], strings[4], strings[5], strings[6], funcs[0], funcs[1], funcs[2], funcs[3], funcs[4], funcs[5], funcs[6]);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, i * i);
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions.Count, K + 1);
            }
        }
        [TestMethod]
        public void SelectTest8CustomError()
        {
            const int K = 8;
            var expr = Select.Create(strings[0], strings[1], strings[2], strings[3], strings[4], strings[5], strings[6], strings[7], funcs[0], funcs[1], funcs[2], funcs[3], funcs[4], funcs[5], funcs[6], funcs[7], CustomException);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out _, out _));
                Assert.AreEqual(ret, i * i);
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions[0].Exception.Message, $"error: {K}");
            }
        }

        [TestMethod]
        public void SelectTest8NormalError()
        {
            const int K = 8;
            var expr = Select.Create(strings[0], strings[1], strings[2], strings[3], strings[4], strings[5], strings[6], strings[7], funcs[0], funcs[1], funcs[2], funcs[3], funcs[4], funcs[5], funcs[6], funcs[7]);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, i * i);
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions.Count, K + 1);
            }
        }
        [TestMethod]
        public void SelectTest9CustomError()
        {
            const int K = 9;
            var expr = Select.Create(strings[0], strings[1], strings[2], strings[3], strings[4], strings[5], strings[6], strings[7], strings[8], funcs[0], funcs[1], funcs[2], funcs[3], funcs[4], funcs[5], funcs[6], funcs[7], funcs[8], CustomException);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out _, out _));
                Assert.AreEqual(ret, i * i);
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions[0].Exception.Message, $"error: {K}");
            }
        }

        [TestMethod]
        public void SelectTest9NormalError()
        {
            const int K = 9;
            var expr = Select.Create(strings[0], strings[1], strings[2], strings[3], strings[4], strings[5], strings[6], strings[7], strings[8], funcs[0], funcs[1], funcs[2], funcs[3], funcs[4], funcs[5], funcs[6], funcs[7], funcs[8]);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, i * i);
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions.Count, K + 1);
            }
        }
        [TestMethod]
        public void SelectTest10CustomError()
        {
            const int K = 10;
            var expr = Select.Create(strings[0], strings[1], strings[2], strings[3], strings[4], strings[5], strings[6], strings[7], strings[8], strings[9], funcs[0], funcs[1], funcs[2], funcs[3], funcs[4], funcs[5], funcs[6], funcs[7], funcs[8], funcs[9], CustomException);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out _, out _));
                Assert.AreEqual(ret, i * i);
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions[0].Exception.Message, $"error: {K}");
            }
        }

        [TestMethod]
        public void SelectTest10NormalError()
        {
            const int K = 10;
            var expr = Select.Create(strings[0], strings[1], strings[2], strings[3], strings[4], strings[5], strings[6], strings[7], strings[8], strings[9], funcs[0], funcs[1], funcs[2], funcs[3], funcs[4], funcs[5], funcs[6], funcs[7], funcs[8], funcs[9]);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, i * i);
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions.Count, K + 1);
            }
        }
        [TestMethod]
        public void SelectTest11CustomError()
        {
            const int K = 11;
            var expr = Select.Create(strings[0], strings[1], strings[2], strings[3], strings[4], strings[5], strings[6], strings[7], strings[8], strings[9], strings[10], funcs[0], funcs[1], funcs[2], funcs[3], funcs[4], funcs[5], funcs[6], funcs[7], funcs[8], funcs[9], funcs[10], CustomException);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out _, out _));
                Assert.AreEqual(ret, i * i);
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions[0].Exception.Message, $"error: {K}");
            }
        }

        [TestMethod]
        public void SelectTest11NormalError()
        {
            const int K = 11;
            var expr = Select.Create(strings[0], strings[1], strings[2], strings[3], strings[4], strings[5], strings[6], strings[7], strings[8], strings[9], strings[10], funcs[0], funcs[1], funcs[2], funcs[3], funcs[4], funcs[5], funcs[6], funcs[7], funcs[8], funcs[9], funcs[10]);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, i * i);
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions.Count, K + 1);
            }
        }
        [TestMethod]
        public void SelectTest12CustomError()
        {
            const int K = 12;
            var expr = Select.Create(strings[0], strings[1], strings[2], strings[3], strings[4], strings[5], strings[6], strings[7], strings[8], strings[9], strings[10], strings[11], funcs[0], funcs[1], funcs[2], funcs[3], funcs[4], funcs[5], funcs[6], funcs[7], funcs[8], funcs[9], funcs[10], funcs[11], CustomException);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out _, out _));
                Assert.AreEqual(ret, i * i);
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions[0].Exception.Message, $"error: {K}");
            }
        }

        [TestMethod]
        public void SelectTest12NormalError()
        {
            const int K = 12;
            var expr = Select.Create(strings[0], strings[1], strings[2], strings[3], strings[4], strings[5], strings[6], strings[7], strings[8], strings[9], strings[10], strings[11], funcs[0], funcs[1], funcs[2], funcs[3], funcs[4], funcs[5], funcs[6], funcs[7], funcs[8], funcs[9], funcs[10], funcs[11]);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, i * i);
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions.Count, K + 1);
            }
        }
        [TestMethod]
        public void SelectTest13CustomError()
        {
            const int K = 13;
            var expr = Select.Create(strings[0], strings[1], strings[2], strings[3], strings[4], strings[5], strings[6], strings[7], strings[8], strings[9], strings[10], strings[11], strings[12], funcs[0], funcs[1], funcs[2], funcs[3], funcs[4], funcs[5], funcs[6], funcs[7], funcs[8], funcs[9], funcs[10], funcs[11], funcs[12], CustomException);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out _, out _));
                Assert.AreEqual(ret, i * i);
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions[0].Exception.Message, $"error: {K}");
            }
        }

        [TestMethod]
        public void SelectTest13NormalError()
        {
            const int K = 13;
            var expr = Select.Create(strings[0], strings[1], strings[2], strings[3], strings[4], strings[5], strings[6], strings[7], strings[8], strings[9], strings[10], strings[11], strings[12], funcs[0], funcs[1], funcs[2], funcs[3], funcs[4], funcs[5], funcs[6], funcs[7], funcs[8], funcs[9], funcs[10], funcs[11], funcs[12]);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, i * i);
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions.Count, K + 1);
            }
        }
        [TestMethod]
        public void SelectTest14CustomError()
        {
            const int K = 14;
            var expr = Select.Create(strings[0], strings[1], strings[2], strings[3], strings[4], strings[5], strings[6], strings[7], strings[8], strings[9], strings[10], strings[11], strings[12], strings[13], funcs[0], funcs[1], funcs[2], funcs[3], funcs[4], funcs[5], funcs[6], funcs[7], funcs[8], funcs[9], funcs[10], funcs[11], funcs[12], funcs[13], CustomException);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out _, out _));
                Assert.AreEqual(ret, i * i);
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions[0].Exception.Message, $"error: {K}");
            }
        }

        [TestMethod]
        public void SelectTest14NormalError()
        {
            const int K = 14;
            var expr = Select.Create(strings[0], strings[1], strings[2], strings[3], strings[4], strings[5], strings[6], strings[7], strings[8], strings[9], strings[10], strings[11], strings[12], strings[13], funcs[0], funcs[1], funcs[2], funcs[3], funcs[4], funcs[5], funcs[6], funcs[7], funcs[8], funcs[9], funcs[10], funcs[11], funcs[12], funcs[13]);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, i * i);
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions.Count, K + 1);
            }
        }
        [TestMethod]
        public void SelectTest15CustomError()
        {
            const int K = 15;
            var expr = Select.Create(strings[0], strings[1], strings[2], strings[3], strings[4], strings[5], strings[6], strings[7], strings[8], strings[9], strings[10], strings[11], strings[12], strings[13], strings[14], funcs[0], funcs[1], funcs[2], funcs[3], funcs[4], funcs[5], funcs[6], funcs[7], funcs[8], funcs[9], funcs[10], funcs[11], funcs[12], funcs[13], funcs[14], CustomException);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out _, out _));
                Assert.AreEqual(ret, i * i);
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions[0].Exception.Message, $"error: {K}");
            }
        }

        [TestMethod]
        public void SelectTest15NormalError()
        {
            const int K = 15;
            var expr = Select.Create(strings[0], strings[1], strings[2], strings[3], strings[4], strings[5], strings[6], strings[7], strings[8], strings[9], strings[10], strings[11], strings[12], strings[13], strings[14], funcs[0], funcs[1], funcs[2], funcs[3], funcs[4], funcs[5], funcs[6], funcs[7], funcs[8], funcs[9], funcs[10], funcs[11], funcs[12], funcs[13], funcs[14]);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, i * i);
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions.Count, K + 1);
            }
        }
        [TestMethod]
        public void SelectTest16CustomError()
        {
            const int K = 16;
            var expr = Select.Create(strings[0], strings[1], strings[2], strings[3], strings[4], strings[5], strings[6], strings[7], strings[8], strings[9], strings[10], strings[11], strings[12], strings[13], strings[14], strings[15], funcs[0], funcs[1], funcs[2], funcs[3], funcs[4], funcs[5], funcs[6], funcs[7], funcs[8], funcs[9], funcs[10], funcs[11], funcs[12], funcs[13], funcs[14], funcs[15], CustomException);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out _, out _));
                Assert.AreEqual(ret, i * i);
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions[0].Exception.Message, $"error: {K}");
            }
        }

        [TestMethod]
        public void SelectTest16NormalError()
        {
            const int K = 16;
            var expr = Select.Create(strings[0], strings[1], strings[2], strings[3], strings[4], strings[5], strings[6], strings[7], strings[8], strings[9], strings[10], strings[11], strings[12], strings[13], strings[14], strings[15], funcs[0], funcs[1], funcs[2], funcs[3], funcs[4], funcs[5], funcs[6], funcs[7], funcs[8], funcs[9], funcs[10], funcs[11], funcs[12], funcs[13], funcs[14], funcs[15]);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, i * i);
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions.Count, K + 1);
            }
        }
    }
}
