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
    /// Expression that make parsing (in repeat or sequence) continue even if match of it fails
    /// </summary>
    public static class Continue
    {
        /// <summary>
        /// Create Continue Expression
        /// </summary>
        /// <typeparam name="T">Base Expression Return Type</typeparam>
        /// <param name="expr">Expression</param>
        /// <returns>Continue Expression</returns>
        public static Continue<T> Create<T>(ExpressionBase<T> expr)
        {
            return new Continue<T>(expr);
        }

        internal class ContinueException : ParsingException
        {
            public ContinueException(int index, Exception exception) : base(index, exception)
            {

            }
        }

        internal class ContinueExceptionTag : Exception
        {

        }
    }


    public class Continue<T>:ExpressionBase<T>
    {
        ExpressionBase<T> expr;

        internal Continue(ExpressionBase<T> expr)
        {
            this.expr = expr;
        }

        public override bool Equals(object obj)
        {
            return obj is Continue<T> @continue &&
                   EqualityComparer<ExpressionBase<T>>.Default.Equals(this.expr, @continue.expr);
        }

        public override int GetHashCode()
        {
            return -1623473186 + EqualityComparer<ExpressionBase<T>>.Default.GetHashCode(this.expr);
        }

        internal override InstanceBase<T, ParseResult> InstanceImplement<ParseResult>(Parser<ParseResult> parser, List<IExpression> exprs, int thisIndex)
        {
            return new InstancedClass<ParseResult>(this.expr.Instance(parser, exprs), parser, thisIndex);
        }

        internal class InstancedClass<ParseResult> : InstanceBase<T, ParseResult>
        {
            int exprIndex;

            public InstancedClass(int exprIndex, Parser<ParseResult> parser, int index) : base(parser, index)
            {
                this.exprIndex = exprIndex;
            }

            protected override Expected<T, ParsingException> ParseImplementation(string str, ref int index, List<ParsingException> exceptions, MemoDictionary memo)
            {
                var val = this.Parser[this.exprIndex].Parse(str, ref index, exceptions, memo);
                if (val.TryGet(out var obj)&&obj is T value)
                {
                    return Success(value);
                }
                else
                {
                    var exc = val.GetException();
                    return Failure<T>(new Continue.ContinueException(exc.Index, exc.Exception));
                }
            }
        }
    }
}
