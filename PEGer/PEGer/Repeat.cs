//Copyright (c) 2019 plasma_effect
//This source code is under MIT License. See ./LICENSE
using System;
using System.Collections.Generic;
using System.Text;
using UtilityLibrary;
using static UtilityLibrary.Expected<PEGer.ParsingException>;

namespace PEGer
{
    /// <summary>
    /// Repetitive Expression
    /// </summary>
    /// <typeparam name="TResult">Return Type</typeparam>
    public static class Repeat<TResult>
    {
        /// <summary>
        /// Create Repetitive Expression with Min Count, Max Count, and Custom Exception
        /// </summary>
        /// <typeparam name="T">Expression Return Type</typeparam>
        /// <param name="expr">Expression</param>
        /// <param name="func">Transform Function</param>
        /// <param name="minCount">Min Count</param>
        /// <param name="maxCount">Max Count</param>
        /// <param name="error">Custom Exception (that is thrown when repetitive count is less than minCount)</param>
        /// <returns>Repetitive Expression</returns>
        public static Repeat<T, TResult> Create<T>(ExpressionBase<T> expr, Func<List<T>, TResult> func, int minCount, int maxCount, Func<int, Exception> error)
        {
            return new Repeat<T, TResult>(expr, func, minCount, maxCount, error);
        }

        /// <summary>
        /// Create Repetitive Expression with Min Count and Custom Exception
        /// </summary>
        /// <typeparam name="T">Expression Return Type</typeparam>
        /// <param name="expr">Expression</param>
        /// <param name="func">Transform Function</param>
        /// <param name="minCount">Min Count</param>
        /// <param name="error">Custom Exception (that is thrown when repetitive count is less than minCount)</param>
        /// <returns>Repetitive Expression</returns>
        public static Repeat<T, TResult> Create<T>(ExpressionBase<T> expr, Func<List<T>, TResult> func, int minCount, Func<int, Exception> error)
        {
            return Create(expr, func, minCount, int.MaxValue, error);
        }

        /// <summary>
        /// Create Repetitive Expression with Custom Exception
        /// </summary>
        /// <typeparam name="T">Expression Return Type</typeparam>
        /// <param name="expr">Expression</param>
        /// <param name="func">Transform Function</param>
        /// <param name="error">Custom Exception (that is thrown when repetitive count is less than minCount)</param>
        /// <returns>Repetitive Expression</returns>
        public static Repeat<T, TResult> Create<T>(ExpressionBase<T> expr, Func<List<T>, TResult> func, Func<int, Exception> error)
        {
            return Create(expr, func, 0, int.MaxValue, error);
        }

        /// <summary>
        /// Create Repetitive Expression with Min Count and Max Count
        /// </summary>
        /// <typeparam name="T">Expression Return Type</typeparam>
        /// <param name="expr">Expression</param>
        /// <param name="func">Transform Function</param>
        /// <param name="minCount">Min Count</param>
        /// <param name="maxCount">Max Count</param>
        /// <returns>Repetitive Expression</returns>
        public static Repeat<T, TResult> Create<T>(ExpressionBase<T> expr, Func<List<T>, TResult> func, int minCount, int maxCount)
        {
            return Create(expr, func, minCount, maxCount, null);
        }

        /// <summary>
        /// Create Repetitive Expression with Min Count
        /// </summary>
        /// <typeparam name="T">Expression Return Type</typeparam>
        /// <param name="expr">Expression</param>
        /// <param name="func">Transform Function</param>
        /// <param name="minCount">Min Count</param>
        /// <returns>Repetitive Expression</returns>
        public static Repeat<T, TResult> Create<T>(ExpressionBase<T> expr, Func<List<T>, TResult> func, int minCount)
        {
            return Create(expr, func, minCount, int.MaxValue, null);
        }

        /// <summary>
        /// Create Repetitive Expression
        /// </summary>
        /// <typeparam name="T">Expression Return Type</typeparam>
        /// <param name="expr">Expression</param>
        /// <param name="func">Transform Function</param>
        /// <returns>Repetitive Expression</returns>
        public static Repeat<T, TResult> Create<T>(ExpressionBase<T> expr, Func<List<T>, TResult> func)
        {
            return Create(expr, func, 0, int.MaxValue, null);
        }
    }

    public class Repeat<T, TResult> : ExpressionBase<TResult>
    {
        ExpressionBase<T> expr;
        Func<List<T>, TResult> func;
        int minCount;
        int maxCount;
        Func<int, Exception> error;

        internal Repeat(ExpressionBase<T> expr, Func<List<T>, TResult> func, int minCount, int maxCount, Func<int, Exception> error)
        {
            this.expr = expr;
            this.func = func;
            this.minCount = minCount;
            this.maxCount = maxCount;
            this.error = error;
        }

        public override bool Equals(object obj)
        {
            return obj is Repeat<T, TResult> repeat &&
                   EqualityComparer<ExpressionBase<T>>.Default.Equals(this.expr, repeat.expr) &&
                   EqualityComparer<Func<List<T>, TResult>>.Default.Equals(this.func, repeat.func) &&
                   this.minCount == repeat.minCount &&
                   this.maxCount == repeat.maxCount &&
                   EqualityComparer<Func<int, Exception>>.Default.Equals(this.error, repeat.error);
        }

        public override int GetHashCode()
        {
            var hashCode = -684230212;
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T>>.Default.GetHashCode(this.expr);
            hashCode = hashCode * -1521134295 + EqualityComparer<Func<List<T>, TResult>>.Default.GetHashCode(this.func);
            hashCode = hashCode * -1521134295 + this.minCount.GetHashCode();
            hashCode = hashCode * -1521134295 + this.maxCount.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Func<int, Exception>>.Default.GetHashCode(this.error);
            return hashCode;
        }

        internal override InstanceBase<TResult, ParseResult> InstanceImplement<ParseResult>(Parser<ParseResult> parser, List<IExpression> exprs, int thisIndex)
        {
            var exprIndex = this.expr.Instance(parser, exprs);
            return new InstancedClass<ParseResult>(exprIndex, this.func, this.minCount, this.maxCount, this.error, parser, thisIndex);
        }

        internal class InstancedClass<ParseResult> : InstanceBase<TResult, ParseResult>
        {
            int exprIndex;
            Func<List<T>, TResult> func;
            int minCount;
            int maxCount;
            Func<int, Exception> error;

            public InstancedClass(int exprIndex, Func<List<T>, TResult> func, int minCount, int maxCount, Func<int, Exception> error, Parser<ParseResult> parser, int thisIndex) : base(parser, thisIndex)
            {
                this.exprIndex = exprIndex;
                this.func = func;
                this.minCount = minCount;
                this.maxCount = maxCount;
                this.error = error;
            }

            protected override Expected<TResult,ParsingException> ParseImplementation(string str, ref int index, List<ParsingException> exceptions, MemoDictionary memo)
            {
                var list = new List<T>();
                var start = index;
                var now = start;
                while (list.Count < this.maxCount)
                {
                    now = index;
                    var val = this.Parser[this.exprIndex].Parse(str, ref index, exceptions, memo);
                    if (val.TryGet(out var obj) && obj is T value)
                    {
                        list.Add(value);
                    }
                    else
                    {
                        index = now;
                        break;
                    }
                }
                if (list.Count < this.minCount)
                {
                    index = start;
                    if(this.error is null)
                    {
                        return Failure<TResult>(new ParsingException(now, new ArgumentOutOfRangeException($"Number of repetition is few (it must be more than or equal to {this.minCount})")));
                    }
                    else
                    {
                        return Failure<TResult>(new ParsingException(now, this.error(list.Count)));
                    }
                }
                else
                {
                    return Success(this.func(list));
                }
            }
        }
    }
}
