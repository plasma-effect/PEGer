﻿//Copyright (c) 2019 plasma_effect
//This source code is under MIT License. See ./LICENSE
using System;
using System.Collections.Generic;
using System.Text;
using TrueRegex;
using UtilityLibrary;
using static UtilityLibrary.Expected<PEGer.ParsingException>;

namespace PEGer
{
    /// <summary>
    /// Regular Expression
    /// </summary>
    /// <typeparam name="T">Return Type</typeparam>
    public class Regex<T> : ExpressionBase<T>
    {
        IRegex regex;
        Func<StringView, int, T> func;
        bool greedy;
        Func<Exception> error;

        internal Regex(IRegex regex, Func<StringView, int, T> func, bool greedy, Func<Exception> error)
        {
            this.regex = regex;
            this.func = func;
            this.greedy = greedy;
            this.error = error;
        }

        internal override InstanceBase<T, ParseResult> InstanceImplement<ParseResult>(Parser<ParseResult> parser, List<IExpression> exprs, int thisIndex)
        {
            return new InstancedClass<ParseResult>(this.regex, this.func, this.greedy, this.error, parser, thisIndex);
        }

        internal class InstancedClass<ParseResult> : InstanceBase<T, ParseResult>
        {
            IRegex regex;
            Func<StringView, int, T> func;
            bool greedy;
            Func<Exception> error;
            Func<IEnumerable<char>, int?> match;

            public InstancedClass(IRegex regex, Func<StringView, int, T> func, bool greedy, Func<Exception> error, Parser<ParseResult> parser, int thisIndex) : base(parser, thisIndex)
            {
                this.regex = regex;
                this.func = func;
                this.greedy = greedy;
                this.error = error;
                this.match = this.regex.FirstMatch;
                if (this.greedy)
                {
                    this.match = this.regex.LastMatch;
                }
            }

            protected override Expected<T, ParsingException> ParseImplementation(string str, ref int index, List<ParsingException> exceptions, MemoDictionary memo)
            {
                var view = new StringView(str).Substring(index);
                if (this.match(view) is int length)
                {
                    var ret = this.func(view.Substring(0, length), index);
                    index += length;
                    return Success(ret);
                }
                else
                {
                    return Failure<T>(new ParsingException(index, this.error()));
                }
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Regex<T> regex &&
                   EqualityComparer<IRegex>.Default.Equals(this.regex, regex.regex) &&
                   EqualityComparer<Func<StringView, int, T>>.Default.Equals(this.func, regex.func) &&
                   this.greedy == regex.greedy &&
                   EqualityComparer<Func<Exception>>.Default.Equals(this.error, regex.error);
        }

        public override int GetHashCode()
        {
            var hashCode = 2120474785;
            hashCode = hashCode * -1521134295 + EqualityComparer<IRegex>.Default.GetHashCode(this.regex);
            hashCode = hashCode * -1521134295 + EqualityComparer<Func<StringView, int, T>>.Default.GetHashCode(this.func);
            hashCode = hashCode * -1521134295 + this.greedy.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Func<Exception>>.Default.GetHashCode(this.error);
            return hashCode;
        }
    }

    /// <summary>
    /// Create Regex Instance without Transform Function
    /// </summary>
    public static class Regex
    {
        private static ArgumentException DefaultError()
        {
            return new ArgumentException("the string didn't match the regex.");
        }

        /// <summary>
        /// Create Regex Expression with Custom Exception
        /// </summary>
        /// <typeparam name="TResult">Return Type</typeparam>
        /// <param name="regex">Regular Expression</param>
        /// <param name="func">Transform Function</param>
        /// <param name="error">Function that return Custom Exception</param>
        /// <param name="greedy">Greedy Flag (if true, this match will do greedy)</param>
        /// <returns>Regex Expression</returns>
        public static Regex<TResult> Create<TResult>(IRegex regex, Func<StringView, int, TResult> func, Func<Exception> error, bool greedy = true)
        {
            return new Regex<TResult>(regex, func, greedy, error);
        }

        /// <summary>
        /// Create Regex Expression
        /// </summary>
        /// <typeparam name="TResult">Return Type</typeparam>
        /// <param name="regex">Regular Expression</param>
        /// <param name="func">Transform Function</param>
        /// <param name="greedy">Greedy Flag (if true, this match will do greedy)</param>
        /// <returns>Regex Expression</returns>
        public static Regex<TResult> Create<TResult>(IRegex regex, Func<StringView, int, TResult> func, bool greedy = true)
        {
            return new Regex<TResult>(regex, func, greedy, DefaultError);
        }

        /// <summary>
        /// Create Simple Regex Expression
        /// </summary>
        /// <param name="regex">Regular Expression</param>
        /// <param name="greedy">Greedy Flag(if true, this match will do greedy)</param>
        /// <returns>Regex Expression</returns>
        public static Regex<StringView> Create(IRegex regex, bool greedy = true)
        {
            return new Regex<StringView>(regex, (view, _) => view, greedy, DefaultError);
        }

        /// <summary>
        /// Create Simple Regex Expression with Custom Exception
        /// </summary>
        /// <param name="regex">Regular Expression</param>
        /// <param name="error">Function that return Custom Exception</param>
        /// <param name="greedy">Greedy Flag(if true, this match will do greedy)</param>
        /// <returns>Regex Expression</returns>
        public static Regex<StringView> Create(IRegex regex, Func<Exception> error, bool greedy = true)
        {
            return new Regex<StringView>(regex, (view, _) => view, greedy, error);
        }

        /// <summary>
        /// Transform Regex to Regex Expression
        /// </summary>
        /// <param name="regex">Base Regex</param>
        /// <param name="greedy">Greedy Flag (if true, this match will do greedy)</param>
        /// <returns>Regex Expression</returns>
        public static Regex<StringView> ToExpr(this IRegex regex, bool greedy = true)
        {
            return Create(regex, greedy);
        }

        /// <summary>
        /// Transform Regex to Regex Expression with Transform Function
        /// </summary>
        /// <typeparam name="T">Expression Return Type</typeparam>
        /// <param name="regex">Base Regex</param>
        /// <param name="func">Transform Function</param>
        /// <param name="greedy">Greedy Flag (if true, this match will do greedy)</param>
        /// <returns>Regex Expression</returns>
        public static Regex<T> ToExpr<T>(this IRegex regex, Func<StringView, int, T> func, bool greedy = true)
        {
            return new Regex<T>(regex, func, greedy, DefaultError);
        }

        /// <summary>
        /// Transform Regex to Regex Expression with Transform Function and Custom Exception
        /// </summary>
        /// <typeparam name="T">Expression Return Type</typeparam>
        /// <param name="regex">Base Regex</param>
        /// <param name="func">Transform Function</param>
        /// <param name="error">Function that return Custom Exception</param>
        /// <param name="greedy">Greedy Flag (if true, this match will do greedy)</param>
        /// <returns>Regex Expression</returns>
        public static Regex<T> ToExpr<T>(this IRegex regex, Func<StringView, int, T> func, Func<Exception> error, bool greedy = true)
        {
            return new Regex<T>(regex, func, greedy, error);
        }
    }
}