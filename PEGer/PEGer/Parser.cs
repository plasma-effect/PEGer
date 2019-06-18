//Copyright (c) 2019 plasma_effect
//This source code is under MIT License. See ./LICENSE
using System;
using System.Collections.Generic;

namespace PEGer
{
    public static class Value
    {
        static public InstancedValue<T, T> Create<T>(ExpressionBase<T> expr)
        {
            return new InstancedValue<T, T>(expr, v => v, null);
        }
        static public InstancedValue<T, T> Create<T>(ExpressionBase<T> expr, Func<ParsingException, Exception> error)
        {
            return new InstancedValue<T, T>(expr, v => v, error);
        }
    }

    public abstract class Value<T> : ExpressionBase<T>
    {
        static public InstancedValue<BaseT, T> Create<BaseT>(ExpressionBase<BaseT> expr, Func<BaseT,T> func)
        {
            return new InstancedValue<BaseT, T>(expr, func, null);
        }
        static public InstancedValue<BaseT,T> Create<BaseT>(ExpressionBase<BaseT> expr, Func<BaseT, T> func,Func<ParsingException,Exception> error)
        {
            return new InstancedValue<BaseT, T>(expr, func, error);
        }
    }
    public class InstancedValue<T, TResult> : Value<TResult>
    {
        ExpressionBase<T> expr;
        Func<T, TResult> func;
        Func<ParsingException, Exception> error;

        public InstancedValue(ExpressionBase<T> expr, Func<T, TResult> func, Func<ParsingException, Exception> error)
        {
            this.expr = expr;
            this.func = func;
            this.error = error;
        }

        public override bool Equals(object obj)
        {
            return obj is InstancedValue<T, TResult> value &&
                   EqualityComparer<ExpressionBase<T>>.Default.Equals(this.expr, value.expr) &&
                   EqualityComparer<Func<T, TResult>>.Default.Equals(this.func, value.func);
        }

        public override int GetHashCode()
        {
            var hashCode = -1380316187;
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T>>.Default.GetHashCode(this.expr);
            hashCode = hashCode * -1521134295 + EqualityComparer<Func<T, TResult>>.Default.GetHashCode(this.func);
            return hashCode;
        }

        internal override void InstanceImplement<ParseResult>(Parser<ParseResult> parser, List<IExpression> exprs, int thisIndex)
        {
            var exprIndex = this.expr.Instance(parser, exprs);
            parser.Instances.Add(new InstanceClass<ParseResult>(exprIndex, this.func, this.error, parser, thisIndex));
        }

        internal class InstanceClass<ParseResult> : InstanceBase<TResult, ParseResult>
        {
            int exprIndex;
            Func<T, TResult> func;
            Func<ParsingException, Exception> error;

            public InstanceClass(int exprIndex, Func<T, TResult> func, Func<ParsingException, Exception> error, Parser<ParseResult> parser, int thisIndex) : base(parser, thisIndex)
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
                    return this.func((T)this.Parser.Instances[this.exprIndex].Parse(str, ref index, exceptions, memo));
                }
                catch (ParsingException exc)
                {
                    if(this.error is null)
                    {
                        throw exc;
                    }
                    else
                    {
                        throw new ParsingException(start, this.error(exc));
                    }
                }
            }
        }

    }
    public class Parser<TResult>
    {
        internal List<IInstancedExpression<TResult>> Instances { get; }
        int startIndex;
        public bool SpaceIgnore { get; set; }
        public Parser(Value<TResult> initValue, params IExpression[] exprs)
        {
            this.Instances = new List<IInstancedExpression<TResult>>();
            var internalExpr = new List<IExpression>();
            this.startIndex = initValue.Instance(this, internalExpr);
            foreach (var e in exprs)
            {
                e.Instance(this, internalExpr);
            }
            this.SpaceIgnore = true;
        }

        public void SpaceSkip(string str,ref int index)
        {
            if (this.SpaceIgnore)
            {
                while (index < str.Length && char.IsWhiteSpace(str[index]))
                {
                    ++index;
                }
            }
        }

        public bool Parse(string str, out TResult ret, out List<ParsingException> exceptions,out int endPoint)
        {
            var index = 0;
            SpaceSkip(str, ref index);
            exceptions = new List<ParsingException>();
            try
            {
                ret = (TResult)this.Instances[this.startIndex].Parse(str, ref index, exceptions, new MemoDictionary());
                endPoint = exceptions.Count == 0 ? index : -1;
                return exceptions.Count == 0;
            }
            catch (ParsingException exc)
            {
                exceptions.Add(exc);
                ret = default;
                endPoint = -1;
                return false;
            }
        }

        public bool ParseFullMatch(string str, out TResult ret, out List<ParsingException> exceptions)
        {
            var result = Parse(str, out ret, out exceptions, out var end);
            if (result && end != str.Length)
            {
                exceptions.Add(new ParsingException(end, new DontReachEndOfStringException()));
                ret = default;
                result = false;
            }
            return result;
        }
    }
}
