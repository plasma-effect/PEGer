//Copyright (c) 2019 plasma_effect
//This source code is under MIT License. See ./LICENSE
using System;
using System.Collections.Generic;
using System.Text;
using TrueRegex;
using UtilityLibrary;

namespace PEGer
{
    /// <summary>
    /// Regular Expression
    /// </summary>
    /// <typeparam name="T">Return Type</typeparam>
    public class Regex<T> : ExpressionBase<T>
    {
        IRegex regex;
        Func<StringView, int, T> func;
        Func<Exception> error;

        private Regex(IRegex regex, Func<StringView, int, T> func, Func<Exception> error)
        {
            this.regex = regex;
            this.func = func;
            this.error = error;
        }

        internal override void InstanceImplement<ParseResult>(Parser<ParseResult> parser, List<IExpression> exprs, int thisIndex)
        {
            parser.Instances.Add(new InstancedClass<ParseResult>(this.regex, this.func, this.error, parser, thisIndex));
        }

        internal class InstancedClass<ParseResult> : InstanceBase<T, ParseResult>
        {
            IRegex regex;
            Func<StringView, int, T> func;
            Func<Exception> error;

            public InstancedClass(IRegex regex, Func<StringView, int, T> func,Func<Exception> error, Parser<ParseResult> parser, int thisIndex) : base(parser, thisIndex)
            {
                this.regex = regex;
                this.func = func;
                this.error = error;
            }

            protected override T ParseImplementation(string str, ref int index, List<ParsingException> exceptions, MemoDictionary memo)
            {
                var view = new StringView(str).Substring(index);
                if (this.regex.LastMatch(view) is int length)
                {
                    var ret = this.func(view.Substring(0, length), index);
                    index += length;
                    return ret;
                }
                else
                {
                    if (this.error is null)
                    {
                        throw new ParsingException(index, new ArgumentException("the string didn't match the regex."));
                    }
                    else
                    {
                        throw new ParsingException(index, this.error());
                    }
                }
            }
        }

        /// <summary>
        /// Create Regex
        /// </summary>
        /// <param name="regex">Regular Expression</param>
        /// <param name="func">Transform Function</param>
        /// <returns>Expression</returns>
        public static Regex<T> Create(IRegex regex, Func<StringView, int, T> func)
        {
            return new Regex<T>(regex, func, null);
        }

        /// <summary>
        /// Create Regex with Custom Exception
        /// </summary>
        /// <param name="regex">Regular Expression</param>
        /// <param name="func">Transform Function</param>
        /// <param name="error">Function that return Custom Exception</param>
        /// <returns>Expression</returns>
        public static Regex<T> Create(IRegex regex, Func<StringView, int, T> func, Func<Exception> error)
        {
            return new Regex<T>(regex, func, error);
        }

        public override bool Equals(object obj)
        {
            return obj is Regex<T> regex &&
                   EqualityComparer<IRegex>.Default.Equals(this.regex, regex.regex) &&
                   EqualityComparer<Func<StringView, int, T>>.Default.Equals(this.func, regex.func) &&
                   EqualityComparer<Func<Exception>>.Default.Equals(this.error, regex.error);
        }

        public override int GetHashCode()
        {
            var hashCode = 942585704;
            hashCode = hashCode * -1521134295 + EqualityComparer<IRegex>.Default.GetHashCode(this.regex);
            hashCode = hashCode * -1521134295 + EqualityComparer<Func<StringView, int, T>>.Default.GetHashCode(this.func);
            hashCode = hashCode * -1521134295 + EqualityComparer<Func<Exception>>.Default.GetHashCode(this.error);
            return hashCode;
        }
    }

    /// <summary>
    /// Create Regex Instance without Transform Function
    /// </summary>
    public static class Regex
    {
        /// <summary>
        /// Create Regex
        /// </summary>
        /// <param name="regex">Regular Expression</param>
        /// <returns>Expression</returns>
        public static Regex<string> Create(IRegex regex)
        {
            return Regex<string>.Create(regex, (view, _) => view.ToString());
        }

        /// <summary>
        /// Create Regex with Custom Exception
        /// </summary>
        /// <param name="regex">Regular Expression</param>
        /// <param name="error">Function that return Custom Exception</param>
        /// <returns>Expression</returns>
        public static Regex<string> Create(IRegex regex,Func<Exception> error)
        {
            return Regex<string>.Create(regex, (view, _) => view.ToString(), error);
        }
    }

}
