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
    /// Value Expression (for Recursive Expression)
    /// </summary>
    /// <typeparam name="T">Return Type</typeparam>
    public class Value<T> : ExpressionBase<T>
    {
        public ExpressionBase<T> Expr { get; set; }
        private Guid guid;
        
        public Value()
        {
            this.Expr = null;
            this.guid = Guid.NewGuid();
        }

        internal class InstancedClass<ParseResult> : InstanceBase<T, ParseResult>
        {
            int exprIndex;

            public InstancedClass(int exprIndex, Parser<ParseResult> parser, int thisIndex) : base(parser, thisIndex)
            {
                this.exprIndex = exprIndex;
            }

            protected override Expected<T, ParsingException> ParseImplementation(string str, ref int index, List<ParsingException> exceptions, MemoDictionary memo)
            {
                var ret = this.Parser[this.exprIndex].Parse(str, ref index, exceptions, memo);
                if (ret.TryGet(out var obj) && obj is T val)
                {
                    return Success(val);
                }
                else
                {
                    return Failure<T>(ret.GetException());
                }
            }
        }

        internal override InstanceBase<T, ParseResult> InstanceImplement<ParseResult>(Parser<ParseResult> parser, List<IExpression> exprs, int thisIndex)
        {
            return new InstancedClass<ParseResult>(this.Expr.Instance(parser, exprs), parser, thisIndex);
        }

        public override bool Equals(object obj)
        {
            return obj is Value<T> value &&
                   this.guid.Equals(value.guid);
        }

        public override int GetHashCode()
        {
            return -1324198676 + EqualityComparer<Guid>.Default.GetHashCode(this.guid);
        }
    }
}
