//Copyright (c) 2019 plasma_effect
//This source code is under MIT License. See ./LICENSE
using System;
using System.Collections.Generic;
using System.Text;
using UtilityLibrary;
using static UtilityLibrary.Expected<PEGer.ParsingException>;
using static UtilityLibrary.IntegerEnumerable;
using static PEGer.Utility;

namespace PEGer
{
    internal static class Expression
    {
        static public int? Exist(this List<IExpression> list,IExpression expr)
        {
            foreach(var i in Range(list.Count))
            {
                if (list[i].Equals(expr))
                {
                    return i;
                }
            }
            return null;
        }
    }

    public interface IExpression
    {
        int Instance<T>(Parser<T> parser, List<IExpression> exprs);
    }

    public abstract class ExpressionBase<T> : IExpression
    {
        internal abstract InstanceBase<T, ParseResult> InstanceImplement<ParseResult>(Parser<ParseResult> parser, List<IExpression> exprs, int thisIndex);
        public int Instance<TResult>(Parser<TResult> parser, List<IExpression> exprs)
        {
            if (exprs.Exist(this) is int index)
            {
                return index;
            }
            var ret = exprs.Count;
            exprs.Add(this);
            parser.Instances.Add(null);
            parser[ret] = InstanceImplement(parser, exprs, ret);
            return ret;
        }

        public static Repeat<T, List<T>> operator ~(ExpressionBase<T> expr)
        {
            return Repeat.Create(expr);
        }

        public static EqualSelect2<T> operator|(ExpressionBase<T> lhs, ExpressionBase<T> rhs)
        {
            return new EqualSelect2<T>(lhs, rhs, Echo, Echo, null);
        }
    }

    internal interface IInstancedExpression
    {
        Expected<object, ParsingException> Parse(string str, ref int index, List<ParsingException> exceptions, MemoDictionary memo);
    }

    internal abstract class InstanceBase<TResult, ParseResult> : IInstancedExpression
    {
        protected Parser<ParseResult> Parser { get; }
        protected int Index { get; }

        protected InstanceBase(Parser<ParseResult> parser, int index)
        {
            this.Parser = parser;
            this.Index = index;
        }

        protected abstract Expected<TResult, ParsingException> ParseImplementation(string str, ref int index, List<ParsingException> exceptions, MemoDictionary memo);
        public Expected<object, ParsingException> Parse(string str, ref int index, List<ParsingException> exceptions, MemoDictionary memo)
        {
            this.Parser.SpaceSkip(str, ref index);
            if (memo.TryGet(this.Index, index, out var next, out var value))
            {
                index = next;
                return value;
            }
            else
            {
                var start = index;
                var val = ParseImplementation(str, ref index, exceptions, memo);
                var ret = val.TryGet(out var result) ?
                    Success<object>(result) :
                    Failure<object>(val.GetException());
                memo.Add(this.Index, start, index, ret);
                return ret;
            }
        }
    }
}
