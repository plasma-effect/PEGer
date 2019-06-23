//Copyright (c) 2019 plasma_effect
//This source code is under MIT License. See ./LICENSE
using System;
using System.Collections.Generic;
using UtilityLibrary;
using static UtilityLibrary.Expected<PEGer.ParsingException>;

namespace PEGer
{
    /// <summary>
    /// Create Value without Transform Function
    /// </summary>
    public static class Value
    {
        /// <summary>
        /// Create Value from Expression
        /// </summary>
        /// <typeparam name="T">Return Type</typeparam>
        /// <param name="expr">Expression</param>
        /// <returns>Value</returns>
        static public InstancedValue<T, T> Create<T>(ExpressionBase<T> expr)
        {
            return new InstancedValue<T, T>(expr, v => v, null);
        }
        /// <summary>
        /// Create Value from Expression with Custom Exception
        /// </summary>
        /// <typeparam name="T">Return Type</typeparam>
        /// <param name="expr">Expression</param>
        /// <param name="error">Function that return Custom Exception from Parsing Exception</param>
        /// <returns>Value</returns>
        static public InstancedValue<T, T> Create<T>(ExpressionBase<T> expr, Func<ParsingException, Exception> error)
        {
            return new InstancedValue<T, T>(expr, v => v, error);
        }
    }

    /// <summary>
    /// Value Expression
    /// </summary>
    /// <typeparam name="T">Return Type</typeparam>
    public abstract class Value<T> : ExpressionBase<T>
    {
        /// <summary>
        /// Return Value Expression from Expression
        /// </summary>
        /// <typeparam name="BaseT">Expression Return Type</typeparam>
        /// <param name="expr">Expression</param>
        /// <param name="func">Transform Function</param>
        /// <returns>Value Expression</returns>
        static public InstancedValue<BaseT, T> Create<BaseT>(ExpressionBase<BaseT> expr, Func<BaseT,T> func)
        {
            return new InstancedValue<BaseT, T>(expr, func, null);
        }
        /// <summary>
        /// Return Value Expression with Custom Exception from Expression
        /// </summary>
        /// <typeparam name="BaseT">Expression Return Type</typeparam>
        /// <param name="expr">Expression</param>
        /// <param name="func">Transform Function</param>
        /// <param name="error">Function that return Custom Exception from Parsing Exception</param>
        /// <returns></returns>
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

        internal InstancedValue(ExpressionBase<T> expr, Func<T, TResult> func, Func<ParsingException, Exception> error)
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

        internal override InstanceBase<TResult, ParseResult> InstanceImplement<ParseResult>(Parser<ParseResult> parser, List<IExpression> exprs, int thisIndex)
        {
            var exprIndex = this.expr.Instance(parser, exprs);
            return new InstanceClass<ParseResult>(exprIndex, this.func, this.error, parser, thisIndex);
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

            protected override Expected<TResult, ParsingException> ParseImplementation(string str, ref int index, List<ParsingException> exceptions, MemoDictionary memo)
            {
                var start = index;
                var val = this.Parser[this.exprIndex].Parse(str, ref index, exceptions, memo);
                if(val.TryGet(out var obj) && obj is T value)
                {
                    return Success(this.func(value));
                }
                else
                {
                    index = start;
                    var exc = val.GetException();
                    if(this.error is Func<ParsingException, Exception>)
                    {
                        exc = new ParsingException(exc.Index, this.error(exc));
                    }
                    return Failure<TResult>(exc);
                }
            }
        }
    }
    /// <summary>
    /// Static Class for Create Parser
    /// </summary>
    public static class Parser
    {
        /// <summary>
        /// Constuct Parser from Expr
        /// </summary>
        /// <typeparam name="TResult">Result Value</typeparam>
        /// <param name="expr">Initial Expr</param>
        /// <returns>Parser</returns>
        public static Parser<TResult> Create<TResult>(ExpressionBase<TResult> expr)
        {
            return new Parser<TResult>(expr);
        }


    }
    /// <summary>
    /// Parser Type
    /// </summary>
    /// <typeparam name="TResult">Result Type</typeparam>
    public class Parser<TResult>
    {
        internal List<IInstancedExpression> Instances { get; }
        int startIndex;
        bool SpaceIgnore { get; set; }
        internal Parser(ExpressionBase<TResult> initValue)
        {
            this.Instances = new List<IInstancedExpression>();
            var internalExpr = new List<IExpression>();
            this.startIndex = initValue.Instance(this, internalExpr);
            this.SpaceIgnore = true;
        }

        internal void SpaceSkip(string str,ref int index)
        {
            if (this.SpaceIgnore)
            {
                while (index < str.Length && char.IsWhiteSpace(str[index]))
                {
                    ++index;
                }
            }
        }

        /// <summary>
        /// Parse String
        /// </summary>
        /// <param name="str">Parsing Target String</param>
        /// <param name="ret">Return Value (if Parsing Action succeeded)</param>
        /// <param name="exceptions">Parsing Errors</param>
        /// <param name="endPoint">Stop Point (if Parsing Action succeeded) or -1 (otherwise)</param>
        /// <returns>Whether It Succeeded</returns>
        public bool Parse(string str, out TResult ret, out List<ParsingException> exceptions,out int endPoint)
        {
            var index = 0;
            exceptions = new List<ParsingException>();
            var value = this[this.startIndex].Parse(str, ref index, exceptions, new MemoDictionary());
            if (value.TryGet(out var val) && val is TResult v)
            {
                if (exceptions.Count == 0)
                {
                    ret = v;
                    endPoint = index;
                    return true;
                }
                else
                {
                    ret = default;
                    endPoint = -1;
                    return false;
                }
            }
            else
            {
                exceptions.Add(value.GetException());
                ret = default;
                endPoint = -1;
                return false;
            }
        }

        /// <summary>
        /// Parse String (if end point is not string end, this action fail)
        /// </summary>
        /// <param name="str">Parsing Target String</param>
        /// <param name="ret">Return Value (if Parsing Action succeeded)</param>
        /// <param name="exceptions">Parsing Errors</param>
        /// <returns>Whether It Succeeded</returns>
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

        internal IInstancedExpression this[int index]
        {
            get
            {
                return this.Instances[index];
            }
            set
            {
                this.Instances[index] = value;
            }
        }
    }
}
