//Copyright (c) 2019 plasma_effect
//This source code is under MIT License. See ./LICENSE
using System;
using System.Collections.Generic;
using System.Text;

namespace PEGer
{
    public class Sequence<T1, T2, TResult> : ExpressionBase<TResult>
    {
        ExpressionBase<T1> expr1;
        ExpressionBase<T2> expr2;
        Func<T1, T2, TResult> func;
        Func<ParsingException, int, Exception> error;

        public Sequence(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, Func<T1, T2, TResult> func, Func<ParsingException, int, Exception> error)
        {
            this.expr1 = expr1;
            this.expr2 = expr2;
            this.func = func;
            this.error = error;
        }

        public override bool Equals(object obj)
        {
            return obj is Sequence<T1, T2, TResult> sequence &&
                   EqualityComparer<ExpressionBase<T1>>.Default.Equals(this.expr1, sequence.expr1) &&
                   EqualityComparer<ExpressionBase<T2>>.Default.Equals(this.expr2, sequence.expr2) &&
                   EqualityComparer<Func<T1, T2, TResult>>.Default.Equals(this.func, sequence.func) &&
                   EqualityComparer<Func<ParsingException, int, Exception>>.Default.Equals(this.error, sequence.error);
        }

        public override int GetHashCode()
        {
            var hashCode = 2052636279;
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T1>>.Default.GetHashCode(this.expr1);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T2>>.Default.GetHashCode(this.expr2);
            hashCode = hashCode * -1521134295 + EqualityComparer<Func<T1, T2, TResult>>.Default.GetHashCode(this.func);
            hashCode = hashCode * -1521134295 + EqualityComparer<Func<ParsingException, int, Exception>>.Default.GetHashCode(this.error);
            return hashCode;
        }

        internal override InstanceBase<TResult, ParseResult> InstanceImplement<ParseResult>(Parser<ParseResult> parser, List<IExpression> exprs, int thisIndex)
        {
            var thisExprs = new int[2];
            thisExprs[0] = this.expr1.Instance(parser, exprs);
            thisExprs[1] = this.expr2.Instance(parser, exprs);
            return new SequenceInstancedClass<TResult, ParseResult>(thisExprs, objs =>
              this.func((T1)objs[0], (T2)objs[1]),
              this.error, parser, thisIndex);
        }
    }
}
