//Copyright (c) 2019 plasma_effect
//This source code is under MIT License. See ./LICENSE
using System;
using System.Collections.Generic;
using System.Text;

namespace PEGer
{
    /// <summary>
    /// Optional Expression
    /// </summary>
    /// <typeparam name="TResult">Return Type</typeparam>
    public static class Optional<TResult>
    {
        /// <summary>
        /// Create Optional Expression
        /// </summary>
        /// <typeparam name="T">Expression Return Type</typeparam>
        /// <param name="expr">Expression</param>
        /// <param name="success">Function that call if parsing is success</param>
        /// <param name="failure">Function that call if parsing is failure</param>
        /// <returns></returns>
        public static Optional<T,TResult> Create<T>(ExpressionBase<T> expr,Func<T,TResult> success,Func<TResult> failure)
        {
            return new Optional<T, TResult>(expr, success, failure);
        }
    }

    public static class Optional
    {
        /// <summary>
        /// Create Simple Optional Expression
        /// </summary>
        /// <param name="expr">Expression</param>
        /// <param name="failure">Function that call if parsing is failure</param>
        /// <returns>Optional Expression</returns>
        public static Optional<T, T> Create<T>(ExpressionBase<T> expr, Func<T> failure)
        {
            return new Optional<T, T>(expr, Utility.Echo, failure);
        }
    }


    public class Optional<T, TResult> : ExpressionBase<TResult>
    {
        ExpressionBase<T> expr;
        Func<T, TResult> func;
        Func<TResult> error;

        public Optional(ExpressionBase<T> expr, Func<T, TResult> func, Func<TResult> error)
        {
            this.expr = expr;
            this.func = func;
            this.error = error;
        }

        public override bool Equals(object obj)
        {
            return obj is Optional<T, TResult> optional &&
                   EqualityComparer<ExpressionBase<T>>.Default.Equals(this.expr, optional.expr) &&
                   EqualityComparer<Func<T, TResult>>.Default.Equals(this.func, optional.func) &&
                   EqualityComparer<Func<TResult>>.Default.Equals(this.error, optional.error);
        }

        public override int GetHashCode()
        {
            var hashCode = 1180268542;
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T>>.Default.GetHashCode(this.expr);
            hashCode = hashCode * -1521134295 + EqualityComparer<Func<T, TResult>>.Default.GetHashCode(this.func);
            hashCode = hashCode * -1521134295 + EqualityComparer<Func<TResult>>.Default.GetHashCode(this.error);
            return hashCode;
        }

        internal override IInstancedExpression<ParseResult> InstanceImplement<ParseResult>(Parser<ParseResult> parser, List<IExpression> exprs, int thisIndex)
        {
            var exprIndex = this.expr.Instance(parser, exprs);
            return new InstancedClass<ParseResult>(exprIndex, this.func, this.error, parser, thisIndex);
        }

        internal class InstancedClass<ParseResult> : InstanceBase<TResult, ParseResult>
        {
            int exprIndex;
            Func<T, TResult> func;
            Func<TResult> error;

            public InstancedClass(int exprIndex, Func<T, TResult> func, Func<TResult> error, Parser<ParseResult> parser, int thisIndex) : base(parser, thisIndex)
            {
                this.exprIndex = exprIndex;
                this.func = func;
                this.error = error;
            }

            protected override TResult ParseImplementation(string str, ref int index, List<ParsingException> exceptions, MemoDictionary memo)
            {
                var start = index;
                try
                {
                    return this.func((T)this.Parser[this.exprIndex].Parse(str, ref index, exceptions, memo));
                }
                catch (ParsingException)
                {
                    index = start;
                    return this.error();
                }
            }
        }
    }
}
