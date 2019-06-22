using System;
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
    public class SelectTest
    {
        const int N = 16;
        static Regex<string>[] regexes;
        static Func<string, int>[] funcs;
        static Dictionary<string, int> dict;
        static string chars = "abcdefghijklmnopq";
        static SelectTest()
        {
            regexes = new Regex<string>[N];
            funcs = new Func<string, int>[N];
            dict = new Dictionary<string, int>();
            foreach(var i in Range(N))
            {
                regexes[i] = Regex<string>.Create(Chars.Create(chars[i]), (a, _) => a.ToString());
                funcs[i] = (s) => dict[s];
                dict[chars[i].ToString()] = i;
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
        public void SelectTest2CustomFunctionCustomError()
        {
            const int K = 2;
            var expr = Select<int>.Create(regexes[0], regexes[1], funcs[0], funcs[1], CustomException);
            var parser = Parser.Create(expr);
            foreach(var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, i);
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions[0].Exception.Message, $"error: {K}");
            }
        }

        [TestMethod]
        public void SelectTest2CustomFunctionNormalError()
        {
            const int K = 2;
            var expr = Select<int>.Create(regexes[0], regexes[1], funcs[0], funcs[1]);
            var parser = Parser.Create(expr);
            foreach(var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, i);
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions.Count, K + 1);
            }
        }

        [TestMethod]
        public void SelectTest2NoFunctionCustomError()
        {
            const int K = 2;
            var expr = Select<string>.Create(regexes[0], regexes[1], CustomException);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, chars[i].ToString());
            }
            foreach(var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions[0].Exception.Message, $"error: {K}");
            }
        }

        [TestMethod]
        public void SelectTest2NoFunctionNormalError()
        {
            const int K = 2;
            var expr = Select<string>.Create(regexes[0], regexes[1]);
            var parser = Parser.Create(expr);
            foreach(var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, chars[i].ToString());
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions.Count, K + 1);
            }
        }

        [TestMethod]
        public void SelectTest3CustomFunctionCustomError()
        {
            const int K = 3;
            var expr = Select<int>.Create(regexes[0], regexes[1], regexes[2], funcs[0], funcs[1], funcs[2], CustomException);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, i);
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions[0].Exception.Message, $"error: {K}");
            }
        }

        [TestMethod]
        public void SelectTest3CustomFunctionNormalError()
        {
            const int K = 3;
            var expr = Select<int>.Create(regexes[0], regexes[1], regexes[2], funcs[0], funcs[1], funcs[2]);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, i);
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions.Count, K + 1);
            }
        }

        [TestMethod]
        public void SelectTest3NoFunctionCustomError()
        {
            const int K = 3;
            var expr = Select<string>.Create(regexes[0], regexes[1], regexes[2], CustomException);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, chars[i].ToString());
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions[0].Exception.Message, $"error: {K}");
            }
        }

        [TestMethod]
        public void SelectTest3NoFunctionNormalError()
        {
            const int K = 3;
            var expr = Select<string>.Create(regexes[0], regexes[1], regexes[2]);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, chars[i].ToString());
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions.Count, K + 1);
            }
        }

        [TestMethod]
        public void SelectTest4CustomFunctionCustomError()
        {
            const int K = 4;
            var expr = Select<int>.Create(regexes[0], regexes[1], regexes[2], regexes[3], funcs[0], funcs[1], funcs[2], funcs[2], CustomException);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, i);
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions[0].Exception.Message, $"error: {K}");
            }
        }

        [TestMethod]
        public void SelectTest4CustomFunctionNormalError()
        {
            const int K = 4;
            var expr = Select<int>.Create(regexes[0], regexes[1], regexes[2], regexes[3], funcs[0], funcs[1], funcs[2], funcs[2]);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, i);
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions.Count, K + 1);
            }
        }

        [TestMethod]
        public void SelectTest4NoFunctionCustomError()
        {
            const int K = 4;
            var expr = Select<string>.Create(regexes[0], regexes[1], regexes[2], regexes[3], CustomException);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, chars[i].ToString());
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions[0].Exception.Message, $"error: {K}");
            }
        }

        [TestMethod]
        public void SelectTest4NoFunctionNormalError()
        {
            const int K = 4;
            var expr = Select<string>.Create(regexes[0], regexes[1], regexes[2], regexes[3]);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, chars[i].ToString());
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions.Count, K + 1);
            }
        }

        [TestMethod]
        public void SelectTest5CustomFunctionCustomError()
        {
            const int K = 5;
            var expr = Select<int>.Create(regexes[0], regexes[1], regexes[2], regexes[3], regexes[4], funcs[0], funcs[1], funcs[2], funcs[2], funcs[2], CustomException);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, i);
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions[0].Exception.Message, $"error: {K}");
            }
        }

        [TestMethod]
        public void SelectTest5CustomFunctionNormalError()
        {
            const int K = 5;
            var expr = Select<int>.Create(regexes[0], regexes[1], regexes[2], regexes[3], regexes[4], funcs[0], funcs[1], funcs[2], funcs[2], funcs[2]);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, i);
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions.Count, K + 1);
            }
        }

        [TestMethod]
        public void SelectTest5NoFunctionCustomError()
        {
            const int K = 5;
            var expr = Select<string>.Create(regexes[0], regexes[1], regexes[2], regexes[3], regexes[4], CustomException);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, chars[i].ToString());
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions[0].Exception.Message, $"error: {K}");
            }
        }

        [TestMethod]
        public void SelectTest5NoFunctionNormalError()
        {
            const int K = 5;
            var expr = Select<string>.Create(regexes[0], regexes[1], regexes[2], regexes[3], regexes[4]);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, chars[i].ToString());
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions.Count, K + 1);
            }
        }

        [TestMethod]
        public void SelectTest6CustomFunctionCustomError()
        {
            const int K = 6;
            var expr = Select<int>.Create(regexes[0], regexes[1], regexes[2], regexes[3], regexes[4], regexes[5], funcs[0], funcs[1], funcs[2], funcs[2], funcs[2], funcs[2], CustomException);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, i);
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions[0].Exception.Message, $"error: {K}");
            }
        }

        [TestMethod]
        public void SelectTest6CustomFunctionNormalError()
        {
            const int K = 6;
            var expr = Select<int>.Create(regexes[0], regexes[1], regexes[2], regexes[3], regexes[4], regexes[5], funcs[0], funcs[1], funcs[2], funcs[2], funcs[2], funcs[2]);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, i);
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions.Count, K + 1);
            }
        }

        [TestMethod]
        public void SelectTest6NoFunctionCustomError()
        {
            const int K = 6;
            var expr = Select<string>.Create(regexes[0], regexes[1], regexes[2], regexes[3], regexes[4], regexes[5], CustomException);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, chars[i].ToString());
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions[0].Exception.Message, $"error: {K}");
            }
        }

        [TestMethod]
        public void SelectTest6NoFunctionNormalError()
        {
            const int K = 6;
            var expr = Select<string>.Create(regexes[0], regexes[1], regexes[2], regexes[3], regexes[4], regexes[5]);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, chars[i].ToString());
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions.Count, K + 1);
            }
        }

        [TestMethod]
        public void SelectTest7CustomFunctionCustomError()
        {
            const int K = 7;
            var expr = Select<int>.Create(regexes[0], regexes[1], regexes[2], regexes[3], regexes[4], regexes[5], regexes[6], funcs[0], funcs[1], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], CustomException);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, i);
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions[0].Exception.Message, $"error: {K}");
            }
        }

        [TestMethod]
        public void SelectTest7CustomFunctionNormalError()
        {
            const int K = 7;
            var expr = Select<int>.Create(regexes[0], regexes[1], regexes[2], regexes[3], regexes[4], regexes[5], regexes[6], funcs[0], funcs[1], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2]);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, i);
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions.Count, K + 1);
            }
        }

        [TestMethod]
        public void SelectTest7NoFunctionCustomError()
        {
            const int K = 7;
            var expr = Select<string>.Create(regexes[0], regexes[1], regexes[2], regexes[3], regexes[4], regexes[5], regexes[6], CustomException);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, chars[i].ToString());
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions[0].Exception.Message, $"error: {K}");
            }
        }

        [TestMethod]
        public void SelectTest7NoFunctionNormalError()
        {
            const int K = 7;
            var expr = Select<string>.Create(regexes[0], regexes[1], regexes[2], regexes[3], regexes[4], regexes[5], regexes[6]);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, chars[i].ToString());
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions.Count, K + 1);
            }
        }

        [TestMethod]
        public void SelectTest8CustomFunctionCustomError()
        {
            const int K = 8;
            var expr = Select<int>.Create(regexes[0], regexes[1], regexes[2], regexes[3], regexes[4], regexes[5], regexes[6], regexes[7], funcs[0], funcs[1], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], CustomException);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, i);
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions[0].Exception.Message, $"error: {K}");
            }
        }

        [TestMethod]
        public void SelectTest8CustomFunctionNormalError()
        {
            const int K = 8;
            var expr = Select<int>.Create(regexes[0], regexes[1], regexes[2], regexes[3], regexes[4], regexes[5], regexes[6], regexes[7], funcs[0], funcs[1], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2]);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, i);
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions.Count, K + 1);
            }
        }

        [TestMethod]
        public void SelectTest8NoFunctionCustomError()
        {
            const int K = 8;
            var expr = Select<string>.Create(regexes[0], regexes[1], regexes[2], regexes[3], regexes[4], regexes[5], regexes[6], regexes[7], CustomException);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, chars[i].ToString());
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions[0].Exception.Message, $"error: {K}");
            }
        }

        [TestMethod]
        public void SelectTest8NoFunctionNormalError()
        {
            const int K = 8;
            var expr = Select<string>.Create(regexes[0], regexes[1], regexes[2], regexes[3], regexes[4], regexes[5], regexes[6], regexes[7]);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, chars[i].ToString());
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions.Count, K + 1);
            }
        }

        [TestMethod]
        public void SelectTest9CustomFunctionCustomError()
        {
            const int K = 9;
            var expr = Select<int>.Create(regexes[0], regexes[1], regexes[2], regexes[3], regexes[4], regexes[5], regexes[6], regexes[7], regexes[8], funcs[0], funcs[1], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], CustomException);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, i);
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions[0].Exception.Message, $"error: {K}");
            }
        }

        [TestMethod]
        public void SelectTest9CustomFunctionNormalError()
        {
            const int K = 9;
            var expr = Select<int>.Create(regexes[0], regexes[1], regexes[2], regexes[3], regexes[4], regexes[5], regexes[6], regexes[7], regexes[8], funcs[0], funcs[1], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2]);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, i);
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions.Count, K + 1);
            }
        }

        [TestMethod]
        public void SelectTest9NoFunctionCustomError()
        {
            const int K = 9;
            var expr = Select<string>.Create(regexes[0], regexes[1], regexes[2], regexes[3], regexes[4], regexes[5], regexes[6], regexes[7], regexes[8], CustomException);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, chars[i].ToString());
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions[0].Exception.Message, $"error: {K}");
            }
        }

        [TestMethod]
        public void SelectTest9NoFunctionNormalError()
        {
            const int K = 9;
            var expr = Select<string>.Create(regexes[0], regexes[1], regexes[2], regexes[3], regexes[4], regexes[5], regexes[6], regexes[7], regexes[8]);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, chars[i].ToString());
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions.Count, K + 1);
            }
        }

        [TestMethod]
        public void SelectTest10CustomFunctionCustomError()
        {
            const int K = 10;
            var expr = Select<int>.Create(regexes[0], regexes[1], regexes[2], regexes[3], regexes[4], regexes[5], regexes[6], regexes[7], regexes[8], regexes[9], funcs[0], funcs[1], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], CustomException);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, i);
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions[0].Exception.Message, $"error: {K}");
            }
        }

        [TestMethod]
        public void SelectTest10CustomFunctionNormalError()
        {
            const int K = 10;
            var expr = Select<int>.Create(regexes[0], regexes[1], regexes[2], regexes[3], regexes[4], regexes[5], regexes[6], regexes[7], regexes[8], regexes[9], funcs[0], funcs[1], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2]);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, i);
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions.Count, K + 1);
            }
        }

        [TestMethod]
        public void SelectTest10NoFunctionCustomError()
        {
            const int K = 10;
            var expr = Select<string>.Create(regexes[0], regexes[1], regexes[2], regexes[3], regexes[4], regexes[5], regexes[6], regexes[7], regexes[8], regexes[9], CustomException);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, chars[i].ToString());
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions[0].Exception.Message, $"error: {K}");
            }
        }

        [TestMethod]
        public void SelectTest10NoFunctionNormalError()
        {
            const int K = 10;
            var expr = Select<string>.Create(regexes[0], regexes[1], regexes[2], regexes[3], regexes[4], regexes[5], regexes[6], regexes[7], regexes[8], regexes[9]);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, chars[i].ToString());
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions.Count, K + 1);
            }
        }

        [TestMethod]
        public void SelectTest11CustomFunctionCustomError()
        {
            const int K = 11;
            var expr = Select<int>.Create(regexes[0], regexes[1], regexes[2], regexes[3], regexes[4], regexes[5], regexes[6], regexes[7], regexes[8], regexes[9], regexes[10], funcs[0], funcs[1], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], CustomException);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, i);
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions[0].Exception.Message, $"error: {K}");
            }
        }

        [TestMethod]
        public void SelectTest11CustomFunctionNormalError()
        {
            const int K = 11;
            var expr = Select<int>.Create(regexes[0], regexes[1], regexes[2], regexes[3], regexes[4], regexes[5], regexes[6], regexes[7], regexes[8], regexes[9], regexes[10], funcs[0], funcs[1], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2]);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, i);
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions.Count, K + 1);
            }
        }

        [TestMethod]
        public void SelectTest11NoFunctionCustomError()
        {
            const int K = 11;
            var expr = Select<string>.Create(regexes[0], regexes[1], regexes[2], regexes[3], regexes[4], regexes[5], regexes[6], regexes[7], regexes[8], regexes[9], regexes[10], CustomException);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, chars[i].ToString());
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions[0].Exception.Message, $"error: {K}");
            }
        }

        [TestMethod]
        public void SelectTest11NoFunctionNormalError()
        {
            const int K = 11;
            var expr = Select<string>.Create(regexes[0], regexes[1], regexes[2], regexes[3], regexes[4], regexes[5], regexes[6], regexes[7], regexes[8], regexes[9], regexes[10]);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, chars[i].ToString());
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions.Count, K + 1);
            }
        }

        [TestMethod]
        public void SelectTest12CustomFunctionCustomError()
        {
            const int K = 12;
            var expr = Select<int>.Create(regexes[0], regexes[1], regexes[2], regexes[3], regexes[4], regexes[5], regexes[6], regexes[7], regexes[8], regexes[9], regexes[10], regexes[11], funcs[0], funcs[1], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], CustomException);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, i);
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions[0].Exception.Message, $"error: {K}");
            }
        }

        [TestMethod]
        public void SelectTest12CustomFunctionNormalError()
        {
            const int K = 12;
            var expr = Select<int>.Create(regexes[0], regexes[1], regexes[2], regexes[3], regexes[4], regexes[5], regexes[6], regexes[7], regexes[8], regexes[9], regexes[10], regexes[11], funcs[0], funcs[1], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2]);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, i);
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions.Count, K + 1);
            }
        }

        [TestMethod]
        public void SelectTest12NoFunctionCustomError()
        {
            const int K = 12;
            var expr = Select<string>.Create(regexes[0], regexes[1], regexes[2], regexes[3], regexes[4], regexes[5], regexes[6], regexes[7], regexes[8], regexes[9], regexes[10], regexes[11], CustomException);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, chars[i].ToString());
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions[0].Exception.Message, $"error: {K}");
            }
        }

        [TestMethod]
        public void SelectTest12NoFunctionNormalError()
        {
            const int K = 12;
            var expr = Select<string>.Create(regexes[0], regexes[1], regexes[2], regexes[3], regexes[4], regexes[5], regexes[6], regexes[7], regexes[8], regexes[9], regexes[10], regexes[11]);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, chars[i].ToString());
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions.Count, K + 1);
            }
        }

        [TestMethod]
        public void SelectTest13CustomFunctionCustomError()
        {
            const int K = 13;
            var expr = Select<int>.Create(regexes[0], regexes[1], regexes[2], regexes[3], regexes[4], regexes[5], regexes[6], regexes[7], regexes[8], regexes[9], regexes[10], regexes[11], regexes[12], funcs[0], funcs[1], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], CustomException);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, i);
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions[0].Exception.Message, $"error: {K}");
            }
        }

        [TestMethod]
        public void SelectTest13CustomFunctionNormalError()
        {
            const int K = 13;
            var expr = Select<int>.Create(regexes[0], regexes[1], regexes[2], regexes[3], regexes[4], regexes[5], regexes[6], regexes[7], regexes[8], regexes[9], regexes[10], regexes[11], regexes[12], funcs[0], funcs[1], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2]);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, i);
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions.Count, K + 1);
            }
        }

        [TestMethod]
        public void SelectTest13NoFunctionCustomError()
        {
            const int K = 13;
            var expr = Select<string>.Create(regexes[0], regexes[1], regexes[2], regexes[3], regexes[4], regexes[5], regexes[6], regexes[7], regexes[8], regexes[9], regexes[10], regexes[11], regexes[12], CustomException);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, chars[i].ToString());
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions[0].Exception.Message, $"error: {K}");
            }
        }

        [TestMethod]
        public void SelectTest13NoFunctionNormalError()
        {
            const int K = 13;
            var expr = Select<string>.Create(regexes[0], regexes[1], regexes[2], regexes[3], regexes[4], regexes[5], regexes[6], regexes[7], regexes[8], regexes[9], regexes[10], regexes[11], regexes[12]);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, chars[i].ToString());
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions.Count, K + 1);
            }
        }

        [TestMethod]
        public void SelectTest14CustomFunctionCustomError()
        {
            const int K = 14;
            var expr = Select<int>.Create(regexes[0], regexes[1], regexes[2], regexes[3], regexes[4], regexes[5], regexes[6], regexes[7], regexes[8], regexes[9], regexes[10], regexes[11], regexes[12], regexes[13], funcs[0], funcs[1], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], CustomException);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, i);
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions[0].Exception.Message, $"error: {K}");
            }
        }

        [TestMethod]
        public void SelectTest14CustomFunctionNormalError()
        {
            const int K = 14;
            var expr = Select<int>.Create(regexes[0], regexes[1], regexes[2], regexes[3], regexes[4], regexes[5], regexes[6], regexes[7], regexes[8], regexes[9], regexes[10], regexes[11], regexes[12], regexes[13], funcs[0], funcs[1], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2]);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, i);
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions.Count, K + 1);
            }
        }

        [TestMethod]
        public void SelectTest14NoFunctionCustomError()
        {
            const int K = 14;
            var expr = Select<string>.Create(regexes[0], regexes[1], regexes[2], regexes[3], regexes[4], regexes[5], regexes[6], regexes[7], regexes[8], regexes[9], regexes[10], regexes[11], regexes[12], regexes[13], CustomException);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, chars[i].ToString());
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions[0].Exception.Message, $"error: {K}");
            }
        }

        [TestMethod]
        public void SelectTest14NoFunctionNormalError()
        {
            const int K = 14;
            var expr = Select<string>.Create(regexes[0], regexes[1], regexes[2], regexes[3], regexes[4], regexes[5], regexes[6], regexes[7], regexes[8], regexes[9], regexes[10], regexes[11], regexes[12], regexes[13]);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, chars[i].ToString());
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions.Count, K + 1);
            }
        }

        [TestMethod]
        public void SelectTest15CustomFunctionCustomError()
        {
            const int K = 15;
            var expr = Select<int>.Create(regexes[0], regexes[1], regexes[2], regexes[3], regexes[4], regexes[5], regexes[6], regexes[7], regexes[8], regexes[9], regexes[10], regexes[11], regexes[12], regexes[13], regexes[14], funcs[0], funcs[1], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], CustomException);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, i);
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions[0].Exception.Message, $"error: {K}");
            }
        }

        [TestMethod]
        public void SelectTest15CustomFunctionNormalError()
        {
            const int K = 15;
            var expr = Select<int>.Create(regexes[0], regexes[1], regexes[2], regexes[3], regexes[4], regexes[5], regexes[6], regexes[7], regexes[8], regexes[9], regexes[10], regexes[11], regexes[12], regexes[13], regexes[14], funcs[0], funcs[1], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2]);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, i);
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions.Count, K + 1);
            }
        }

        [TestMethod]
        public void SelectTest15NoFunctionCustomError()
        {
            const int K = 15;
            var expr = Select<string>.Create(regexes[0], regexes[1], regexes[2], regexes[3], regexes[4], regexes[5], regexes[6], regexes[7], regexes[8], regexes[9], regexes[10], regexes[11], regexes[12], regexes[13], regexes[14], CustomException);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, chars[i].ToString());
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions[0].Exception.Message, $"error: {K}");
            }
        }

        [TestMethod]
        public void SelectTest15NoFunctionNormalError()
        {
            const int K = 15;
            var expr = Select<string>.Create(regexes[0], regexes[1], regexes[2], regexes[3], regexes[4], regexes[5], regexes[6], regexes[7], regexes[8], regexes[9], regexes[10], regexes[11], regexes[12], regexes[13], regexes[14]);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, chars[i].ToString());
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions.Count, K + 1);
            }
        }

        [TestMethod]
        public void SelectTest16CustomFunctionCustomError()
        {
            const int K = 16;
            var expr = Select<int>.Create(regexes[0], regexes[1], regexes[2], regexes[3], regexes[4], regexes[5], regexes[6], regexes[7], regexes[8], regexes[9], regexes[10], regexes[11], regexes[12], regexes[13], regexes[14], regexes[15], funcs[0], funcs[1], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], CustomException);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, i);
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions[0].Exception.Message, $"error: {K}");
            }
        }

        [TestMethod]
        public void SelectTest16CustomFunctionNormalError()
        {
            const int K = 16;
            var expr = Select<int>.Create(regexes[0], regexes[1], regexes[2], regexes[3], regexes[4], regexes[5], regexes[6], regexes[7], regexes[8], regexes[9], regexes[10], regexes[11], regexes[12], regexes[13], regexes[14], regexes[15], funcs[0], funcs[1], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2], funcs[2]);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, i);
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions.Count, K + 1);
            }
        }

        [TestMethod]
        public void SelectTest16NoFunctionCustomError()
        {
            const int K = 16;
            var expr = Select<string>.Create(regexes[0], regexes[1], regexes[2], regexes[3], regexes[4], regexes[5], regexes[6], regexes[7], regexes[8], regexes[9], regexes[10], regexes[11], regexes[12], regexes[13], regexes[14], regexes[15], CustomException);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, chars[i].ToString());
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions[0].Exception.Message, $"error: {K}");
            }
        }

        [TestMethod]
        public void SelectTest16NoFunctionNormalError()
        {
            const int K = 16;
            var expr = Select<string>.Create(regexes[0], regexes[1], regexes[2], regexes[3], regexes[4], regexes[5], regexes[6], regexes[7], regexes[8], regexes[9], regexes[10], regexes[11], regexes[12], regexes[13], regexes[14], regexes[15]);
            var parser = Parser.Create(expr);
            foreach (var i in Range(K))
            {
                Assert.IsTrue(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(ret, chars[i].ToString());
            }
            foreach (var i in Range(K, N + 1))
            {
                Assert.IsFalse(parser.Parse(chars[i].ToString(), out var ret, out var exceptions, out var end));
                Assert.AreEqual(exceptions.Count, K + 1);
            }
        }
    }
}
