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
    /// NotPredicate Expression (if parsing by expr fails, this parsing succeed)
    /// </summary>
    public static class NotPredicate
    {
        internal static ArgumentException DefaultException(int index)
        {
            return new ArgumentException("this expr match succeeded (it must not succeed in Not Predicate)");
        }

        /// <summary>
        /// Create NotPredicate Expression
        /// </summary>
        /// <typeparam name="T">Target Expression Return Type</typeparam>
        /// <typeparam name="TResult">Return Type</typeparam>
        /// <param name="expr">Target Expression</param>
        /// <param name="failure">Function that return value when the parsing fails</param>
        /// <returns>NotPredicate Function</returns>
        public static NotPredicate<T, TResult> Create<T, TResult>(ExpressionBase<T> expr, Func<int, TResult> failure)
        {
            return new NotPredicate<T, TResult>(expr, failure, NotPredicate.DefaultException);
        }

        /// <summary>
        /// Create NotPredicate Expression with Custom Exception
        /// </summary>
        /// <typeparam name="T">Target Expression Return Type</typeparam>
        /// <typeparam name="TResult">Return Type</typeparam>
        /// <param name="expr">Target Expression</param>
        /// <param name="failure">Function that return value when the parsing fails</param>
        /// <param name="error">Function that return Custom Exception when the parsing succeed</param>
        /// <returns>NotPredicate Function</returns>
        public static NotPredicate<T, TResult> Create<T, TResult>(ExpressionBase<T> expr, Func<int, TResult> failure, Func<int, Exception> error)
        {
            return new NotPredicate<T, TResult>(expr, failure, error);
        }

        /// <summary>
        /// Create NotPredicate Expression with constant Return Value
        /// </summary>
        /// <typeparam name="T">Target Expression Return Type</typeparam>
        /// <typeparam name="TResult">This Expression Return Type</typeparam>
        /// <param name="expr">Target Expression</param>
        /// <param name="failure">Return Value if the parsing fails</param>
        /// <returns>NotPredicate Expression</returns>
        public static NotPredicate<T, TResult> Create<T, TResult>(ExpressionBase<T> expr, TResult failure)
        {
            return new NotPredicate<T, TResult>(expr, (_) => failure, DefaultException);
        }

        /// <summary>
        /// Create NotPredicate Expression with constant Return Value and Custom Exception
        /// </summary>
        /// <typeparam name="T">Target Expression Return Type</typeparam>
        /// <typeparam name="TResult">This Expression Return Type</typeparam>
        /// <param name="expr">Target Expression</param>
        /// <param name="failure">Return Value if the parsing fails</param>
        /// <param name="error">Functon that return Custom Exception when the parsing succeed</param>
        /// <returns>NotPredicate Expression</returns>
        public static NotPredicate<T, TResult> Create<T, TResult>(ExpressionBase<T> expr, TResult failure, Func<int, Exception> error)
        {
            return new NotPredicate<T, TResult>(expr, (_) => failure, error);
        }
    }

    public class NotPredicate<T, TResult> : ExpressionBase<TResult>
    {
        ExpressionBase<T> expr;
        Func<int, TResult> failure;
        Func<int, Exception> error;

        internal NotPredicate(ExpressionBase<T> expr, Func<int, TResult> failure, Func<int, Exception> error)
        {
            this.expr = expr;
            this.failure = failure;
            this.error = error;
        }

        public override bool Equals(object obj)
        {
            return obj is NotPredicate<T, TResult> predicate &&
                   EqualityComparer<ExpressionBase<T>>.Default.Equals(this.expr, predicate.expr) &&
                   EqualityComparer<Func<int, TResult>>.Default.Equals(this.failure, predicate.failure) &&
                   EqualityComparer<Func<int, Exception>>.Default.Equals(this.error, predicate.error);
        }

        public override int GetHashCode()
        {
            var hashCode = 1795969976;
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T>>.Default.GetHashCode(this.expr);
            hashCode = hashCode * -1521134295 + EqualityComparer<Func<int, TResult>>.Default.GetHashCode(this.failure);
            hashCode = hashCode * -1521134295 + EqualityComparer<Func<int, Exception>>.Default.GetHashCode(this.error);
            return hashCode;
        }

        internal override InstanceBase<TResult, ParseResult> InstanceImplement<ParseResult>(Parser<ParseResult> parser, List<IExpression> exprs, int thisIndex)
        {
            return new InstancedClass<ParseResult>(this.expr.Instance(parser, exprs), this.failure, this.error, parser, thisIndex);
        }

        internal class InstancedClass<ParseResult> : InstanceBase<TResult, ParseResult>
        {
            int exprIndex;
            Func<int, TResult> failure;
            Func<int, Exception> error;

            public InstancedClass(int exprIndex, Func<int, TResult> failure, Func<int, Exception> error, Parser<ParseResult> parser, int thisIndex) : base(parser, thisIndex)
            {
                this.exprIndex = exprIndex;
                this.failure = failure;
                this.error = error;
            }

            protected override Expected<TResult, ParsingException> ParseImplementation(string str, ref int index, List<ParsingException> exceptions, MemoDictionary memo)
            {
                var start = index;
                var val = this.Parser[this.exprIndex].Parse(str, ref index, new List<ParsingException>(), memo);
                index = start;
                if (!val)
                {
                    return Success(this.failure(start));
                }
                else
                {
                    return Failure<TResult>(new ParsingException(start, this.error(start)));
                }
            }
        }
    }
}
