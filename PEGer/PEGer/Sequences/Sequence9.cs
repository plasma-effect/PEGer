//Copyright (c) 2019 plasma_effect
//This source code is under MIT License. See ./LICENSE
using System;
using System.Collections.Generic;
using System.Text;

namespace PEGer
{
    public class Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> : ExpressionBase<TResult>
    {
        ExpressionBase<T1> expr1;
        ExpressionBase<T2> expr2;
        ExpressionBase<T3> expr3;
        ExpressionBase<T4> expr4;
        ExpressionBase<T5> expr5;
        ExpressionBase<T6> expr6;
        ExpressionBase<T7> expr7;
        ExpressionBase<T8> expr8;
        ExpressionBase<T9> expr9;

        Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> func;
        Func<ParsingException, int, Exception> error;

        public Sequence(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8, ExpressionBase<T9> expr9, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> func, Func<ParsingException, int, Exception> error)
        {
            this.expr1 = expr1;
            this.expr2 = expr2;
            this.expr3 = expr3;
            this.expr4 = expr4;
            this.expr5 = expr5;
            this.expr6 = expr6;
            this.expr7 = expr7;
            this.expr8 = expr8;
            this.expr9 = expr9;

            this.func = func;
            this.error = error;
        }

        public override bool Equals(object obj)
        {
            return obj is Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> sequence &&
                   EqualityComparer<ExpressionBase<T1>>.Default.Equals(this.expr1, sequence.expr1) &&
                   EqualityComparer<ExpressionBase<T2>>.Default.Equals(this.expr2, sequence.expr2) &&
                   EqualityComparer<ExpressionBase<T3>>.Default.Equals(this.expr3, sequence.expr3) &&
                   EqualityComparer<ExpressionBase<T4>>.Default.Equals(this.expr4, sequence.expr4) &&
                   EqualityComparer<ExpressionBase<T5>>.Default.Equals(this.expr5, sequence.expr5) &&
                   EqualityComparer<ExpressionBase<T6>>.Default.Equals(this.expr6, sequence.expr6) &&
                   EqualityComparer<ExpressionBase<T7>>.Default.Equals(this.expr7, sequence.expr7) &&
                   EqualityComparer<ExpressionBase<T8>>.Default.Equals(this.expr8, sequence.expr8) &&
                   EqualityComparer<ExpressionBase<T9>>.Default.Equals(this.expr9, sequence.expr9) &&
                   EqualityComparer<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>>.Default.Equals(this.func, sequence.func) &&
                   EqualityComparer<Func<ParsingException, int, Exception>>.Default.Equals(this.error, sequence.error);
        }

        public override int GetHashCode()
        {
            var hashCode = 2116772518;
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T1>>.Default.GetHashCode(this.expr1);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T2>>.Default.GetHashCode(this.expr2);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T3>>.Default.GetHashCode(this.expr3);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T4>>.Default.GetHashCode(this.expr4);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T5>>.Default.GetHashCode(this.expr5);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T6>>.Default.GetHashCode(this.expr6);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T7>>.Default.GetHashCode(this.expr7);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T8>>.Default.GetHashCode(this.expr8);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T9>>.Default.GetHashCode(this.expr9);
            hashCode = hashCode * -1521134295 + EqualityComparer<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>>.Default.GetHashCode(this.func);
            hashCode = hashCode * -1521134295 + EqualityComparer<Func<ParsingException, int, Exception>>.Default.GetHashCode(this.error);
            return hashCode;
        }

        internal override InstanceBase<TResult, ParseResult> InstanceImplement<ParseResult>(Parser<ParseResult> parser, List<IExpression> exprs, int thisIndex)
        {
            var thisExprs = new int[9];
            thisExprs[0] = this.expr1.Instance(parser, exprs);
            thisExprs[1] = this.expr2.Instance(parser, exprs);
            thisExprs[2] = this.expr3.Instance(parser, exprs);
            thisExprs[3] = this.expr4.Instance(parser, exprs);
            thisExprs[4] = this.expr5.Instance(parser, exprs);
            thisExprs[5] = this.expr6.Instance(parser, exprs);
            thisExprs[6] = this.expr7.Instance(parser, exprs);
            thisExprs[7] = this.expr8.Instance(parser, exprs);
            thisExprs[8] = this.expr9.Instance(parser, exprs);

            return new SequenceInstancedClass<TResult, ParseResult>(thisExprs, objs =>
              this.func((T1)objs[0], (T2)objs[1], (T3)objs[2], (T4)objs[3], (T5)objs[4], (T6)objs[5], (T7)objs[6], (T8)objs[7], (T9)objs[8]),
              this.error, parser, thisIndex);
        }
    }
}
