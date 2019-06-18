using System;
using System.Collections.Generic;
using System.Text;

namespace PEGer
{
    /// <summary>
    /// Repetitive Expression
    /// </summary>
    /// <typeparam name="TResult">Return Type</typeparam>
    public static class Repeat<TResult>
    {
        public class CreateClass<T>
        {
            ExpressionBase<T> expr;

            public CreateClass(ExpressionBase<T> expr)
            {
                this.expr = expr;
            }

            /// <summary>
            /// Create Repetitive Expression with Min Count, Max Count, and Custom Error
            /// </summary>
            /// <param name="func">Transform Function</param>
            /// <param name="minCount">Min Count</param>
            /// <param name="maxCount">Max Count</param>
            /// <param name="error">Function that return Custom Exception</param>
            /// <returns>Repetitive Expression</returns>
            public Repeat<T, TResult> Create(Func<List<T>, TResult> func, int minCount, int maxCount, Func<int, Exception> error)
            {
                return new Repeat<T, TResult>(this.expr, func, minCount, maxCount, error);
            }

            /// <summary>
            /// Create Repetitive Expression with Max Count, and Custom Error
            /// </summary>
            /// <param name="func">Transform Function</param>
            /// <param name="minCount">Min Count</param>
            /// <param name="error">Function that return Custom Exception</param>
            /// <returns>Repetitive Expression</returns>
            public Repeat<T, TResult> Create(Func<List<T>, TResult> func, int minCount, Func<int, Exception> error)
            {
                return Create(func, minCount,int.MaxValue, error);
            }

            /// <summary>
            /// Create Repetitive Expression with Custom Error
            /// </summary>
            /// <param name="func">Transform Function</param>
            /// <param name="error">Function that return Custom Exception</param>
            /// <returns>Repetitive Expression</returns>
            public Repeat<T, TResult> Create(Func<List<T>, TResult> func, Func<int, Exception> error)
            {
                return Create(func, 0, int.MaxValue, error);
            }

            /// <summary>
            /// Create Repetitive Expression with Min Count and Max Count
            /// </summary>
            /// <param name="func">Transform Function</param>
            /// <param name="minCount">Min Count</param>
            /// <param name="maxCount">Max Count</param>
            /// <returns>Repetitive Expression</returns>
            public Repeat<T,TResult> Create(Func<List<T>,TResult> func,int minCount,int maxCount)
            {
                return Create(func, minCount, maxCount, null);
            }

            /// <summary>
            /// Create Repetitive Expression with Max Count
            /// </summary>
            /// <param name="func">Transform Function</param>
            /// <param name="minCount">Min Count</param>
            /// <returns>Repetitive Expression</returns>
            public Repeat<T, TResult> Create(Func<List<T>, TResult> func, int minCount)
            {
                return Create(func, minCount, int.MaxValue, null);
            }

            /// <summary>
            /// Create Repetitive Expression
            /// </summary>
            /// <param name="func">Transform Function</param>
            /// <returns>Repetitive Expression</returns>
            public Repeat<T, TResult> Create(Func<List<T>, TResult> func)
            {
                return Create(func, 0, int.MaxValue, null);
            }
        }
        /// <summary>
        /// Set Expression for Create
        /// </summary>
        /// <typeparam name="T">Expression Return Type</typeparam>
        /// <param name="expr">Repetitive Expression</param>
        /// <returns>Object for Create Repetitive Expression</returns>
        public static CreateClass<T> Set<T>(ExpressionBase<T> expr)
        {
            return new CreateClass<T>(expr);
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

        internal override IInstancedExpression<ParseResult> InstanceImplement<ParseResult>(Parser<ParseResult> parser, List<IExpression> exprs, int thisIndex)
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

            protected override TResult ParseImplementation(string str, ref int index, List<ParsingException> exceptions, MemoDictionary memo)
            {
                var list = new List<T>();
                var start = index;
                var now = start;
                try
                {
                    while (list.Count < this.maxCount)
                    {
                        now = index;
                        list.Add((T)this.Parser[this.exprIndex].Parse(str, ref index, exceptions, memo));
                    }
                }
                catch (ParsingException)
                {
                    index = now;
                    if (list.Count < this.minCount)
                    {
                        if (this.error is null)
                        {
                            throw new ParsingException(start, new ArgumentOutOfRangeException($"Repetition count is few(it must be more than or equal to {this.minCount})"));
                        }
                        else
                        {
                            throw new ParsingException(start, this.error(list.Count));
                        }
                    }
                }
                return this.func(list);
            }
        }
    }
}
