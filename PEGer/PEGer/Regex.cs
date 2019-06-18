//Copyright (c) 2019 plasma_effect
//This source code is under MIT License. See ./LICENSE
using System;
using System.Collections.Generic;
using System.Text;
using TrueRegex;
using UtilityLibrary;

namespace PEGer
{
    public class Regex<T> : ExpressionBase<T>
    {
        IRegex regex;
        Func<StringView, int, T> func;
        Func<Exception> error;

        public Regex(IRegex regex, Func<StringView, int, T> func, Func<Exception> error)
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

        public static Regex<T> Create(IRegex regex, Func<StringView, int, T> func)
        {
            return new Regex<T>(regex, func, null);
        }

        public static Regex<T> Create(IRegex regex,Func<StringView,int,T> func,Func<Exception> error)
        {
            return new Regex<T>(regex, func, error);
        }
    }
}
