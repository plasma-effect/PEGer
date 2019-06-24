//Copyright (c) 2019 plasma_effect
//This source code is under MIT License. See ./LICENSE
using System;
using System.Collections.Generic;
using System.Linq;
using UtilityLibrary;
using static UtilityLibrary.Expected<PEGer.ParsingException>;

namespace PEGer
{
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
        public bool Parse(string str, out TResult ret, out List<ParsingException> exceptions, out int endPoint)
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
                }
            }
            else
            {
                exceptions.Add(value.GetException());
                ret = default;
                endPoint = -1;
            }
            exceptions = exceptions.Where(exc => !(exc.Exception is Continue.ContinueExceptionTag)).ToList();
            return false;
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
            if (result)
            {
                SpaceSkip(str, ref end);
                if (end != str.Length)
                {
                    exceptions.Add(new ParsingException(end, new DontReachEndOfStringException()));
                    ret = default;
                    result = false;
                }
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
