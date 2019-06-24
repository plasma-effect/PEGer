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
    /// AndPredicate Expression (even if parsing will be success, it does not advance index)
    /// </summary>
    public static class AndPredicate
    {
        /// <summary>
        /// Create AndPredicate Expression
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="expr"></param>
        /// <returns>AndPredicate Expression</returns>
        public static AndPredicate<TResult> Create<TResult>(ExpressionBase<TResult> expr)
        {
            return new AndPredicate<TResult>(expr);
        }
    }

    public class AndPredicate<TResult> : ExpressionBase<TResult>
    {
        ExpressionBase<TResult> expr;

        internal AndPredicate(ExpressionBase<TResult> expr)
        {
            this.expr = expr;
        }

        public override bool Equals(object obj)
        {
            return obj is AndPredicate<TResult> predicate &&
                   EqualityComparer<ExpressionBase<TResult>>.Default.Equals(this.expr, predicate.expr);
        }

        public override int GetHashCode()
        {
            return -1623473186 + EqualityComparer<ExpressionBase<TResult>>.Default.GetHashCode(this.expr);
        }

        internal override InstanceBase<TResult, ParseResult> InstanceImplement<ParseResult>(Parser<ParseResult> parser, List<IExpression> exprs, int thisIndex)
        {
            return new InstancedClass<ParseResult>(this.expr.Instance(parser, exprs), parser, thisIndex);
        }

        internal class InstancedClass<ParseResult> : InstanceBase<TResult, ParseResult>
        {
            int exprIndex;

            public InstancedClass(int exprIndex, Parser<ParseResult> parser, int thisIndex) : base(parser, thisIndex)
            {
                this.exprIndex = exprIndex;
            }

            protected override Expected<TResult, ParsingException> ParseImplementation(string str, ref int index, List<ParsingException> exceptions, MemoDictionary memo)
            {
                var start = index;
                var ret = this.Parser[this.exprIndex].Parse(str, ref index, exceptions, memo);
                index = start;
                if (ret.TryGet(out var obj) && obj is TResult val)
                {
                    return Success(val);
                }
                else
                {
                    return Failure<TResult>(ret.GetException());
                }
            }
        }
    }
}
