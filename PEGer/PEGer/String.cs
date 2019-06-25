//Copyright (c) 2019 plasma_effect
//This source code is under MIT License. See ./LICENSE
using System;
using System.Collections.Generic;
using System.Text;
using UtilityLibrary;
using static UtilityLibrary.Expected<PEGer.ParsingException>;
using static UtilityLibrary.IntegerEnumerable;

namespace PEGer
{
    /// <summary>
    /// Constant String Expression
    /// </summary>
    /// <typeparam name="TResult">Return Type</typeparam>
    public class String<TResult> : ExpressionBase<TResult>
    {
        string str;
        Func<int, TResult> func;
        Func<int, Exception> error;

        internal String(string str, Func<int, TResult> func, Func<int, Exception> error)
        {
            this.str = str;
            this.func = func;
            this.error = error;
        }

        internal override InstanceBase<TResult, ParseResult> InstanceImplement<ParseResult>(Parser<ParseResult> parser, List<IExpression> exprs, int thisIndex)
        {
            return new StringInstancedClass<TResult, ParseResult>(this.str, this.func, this.error, parser, thisIndex);
        }
    }

    /// <summary>
    /// Constant String Expression
    /// </summary>
    public static class String
    {
        internal static ArgumentException DefaultException(int index)
        {
            return new ArgumentException($"Matching failed at {index + 1}");
        }

        /// <summary>
        /// Create String Expression with Transform Function
        /// </summary>
        /// <typeparam name="TResult">Return Type</typeparam>
        /// <param name="str">Target String</param>
        /// <param name="func">Transform Function</param>
        /// <returns>String Expression</returns>
        public static String<TResult> Create<TResult>(string str, Func<int, TResult> func)
        {
            return new String<TResult>(str, func, DefaultException);
        }

        /// <summary>
        /// Create String Expression with Transform Function and Custom Exception
        /// </summary>
        /// <typeparam name="TResult">Return Type</typeparam>
        /// <param name="str">Target String</param>
        /// <param name="func">Transform Function</param>
        /// <param name="error">Function that return Custom Exception</param>
        /// <returns>String Expression</returns>
        public static String<TResult> Create<TResult>(string str, Func<int, TResult> func, Func<int, Exception> error)
        {
            return new String<TResult>(str, func, error);
        }

        /// <summary>
        /// Create String Expression
        /// </summary>
        /// <param name="str">Target String</param>
        /// <returns>String Expression</returns>
        public static String<string> Create(string str)
        {
            return new String<string>(str, _ => str, DefaultException);
        }

        /// <summary>
        /// Create String Expression with Custom Exception
        /// </summary>
        /// <param name="str">Target String</param>
        /// <param name="error">Function that return Custom Exception</param>
        /// <returns>String Expression</returns>
        public static String<string> Create(string str, Func<int, Exception> error)
        {
            return new String<string>(str, _ => str, error);
        }

        /// <summary>
        /// Transform String to String Expression
        /// </summary>
        /// <param name="str">Base String</param>
        /// <returns>String Expression</returns>
        public static String<string> ToExpr(this string str)
        {
            return Create(str);
        }

        /// <summary>
        /// Transform String to String Expression with Transform Function
        /// </summary>
        /// <typeparam name="T">Expression Return Type</typeparam>
        /// <param name="str">Base String</param>
        /// <param name="func">Transform Function</param>
        /// <returns>String Expression</returns>
        public static String<T> ToExpr<T>(this string str,Func<int,T> func)
        {
            return new String<T>(str, func, DefaultException);
        }

        /// <summary>
        /// Transform String to String Expression with Transform Function and Custom Exception
        /// </summary>
        /// <typeparam name="T">Expression Return Type</typeparam>
        /// <param name="str">Base String</param>
        /// <param name="func">Transform Function</param>
        /// <param name="error">Function that return Custom Exception</param>
        /// <returns>String Expression</returns>
        public static String<T> ToExpr<T>(this string str, Func<int, T> func, Func<int, Exception> error)
        {
            return new String<T>(str, func, error);
        }
    }

    internal class StringInstancedClass<TResult, ParseResult> : InstanceBase<TResult, ParseResult>
    {
        string str;
        Func<int, TResult> func;
        Func<int, Exception> error;

        public StringInstancedClass(string str, Func<int, TResult> func, Func<int, Exception> error, Parser<ParseResult> parser, int thisIndex) : base(parser, thisIndex)
        {
            this.str = str;
            this.func = func;
            this.error = error;
        }

        protected override Expected<TResult, ParsingException> ParseImplementation(string str, ref int index, List<ParsingException> exceptions, MemoDictionary memo)
        {
            var start = index;
            foreach (var i in Range(this.str.Length))
            {
                if (index == str.Length)
                {
                    return Failure<TResult>(new ParsingException(index, new ReachEndOfStringException()));
                }
                else if (this.str[i] != str[index])
                {
                    return Failure<TResult>(new ParsingException(index, this.error(i)));
                }
                ++index;
            }
            return Success(this.func(start));
        }
    }
}
