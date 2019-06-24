//Copyright (c) 2019 plasma_effect
//This source code is under MIT License. See ./LICENSE
using System;
using System.Collections.Generic;
using System.Text;
using static PEGer.Utility;

namespace PEGer
{
    public class Select<T1, T2, TResult> : ExpressionBase<TResult>
    {
        protected ExpressionBase<T1> expr1;
        protected ExpressionBase<T2> expr2;
        Func<T1, TResult> func1;
        Func<T2, TResult> func2;
        Func<ParsingException, ParsingException, Exception> error;

        public Select(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, Func<T1, TResult> func1, Func<T2, TResult> func2, Func<ParsingException, ParsingException, Exception> error)
        {
            this.expr1 = expr1;
            this.expr2 = expr2;
            this.func1 = func1;
            this.func2 = func2;
            this.error = error;
        }

        public override bool Equals(object obj)
        {
            return obj is Select<T1, T2, TResult> select &&
                   EqualityComparer<ExpressionBase<T1>>.Default.Equals(this.expr1, select.expr1) &&
                   EqualityComparer<ExpressionBase<T2>>.Default.Equals(this.expr2, select.expr2) &&
                   EqualityComparer<Func<T1, TResult>>.Default.Equals(this.func1, select.func1) &&
                   EqualityComparer<Func<T2, TResult>>.Default.Equals(this.func2, select.func2) &&
                   EqualityComparer<Func<ParsingException, ParsingException, Exception>>.Default.Equals(this.error, select.error);
        }

        public override int GetHashCode()
        {
            var hashCode = -879600357;
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T1>>.Default.GetHashCode(this.expr1);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T2>>.Default.GetHashCode(this.expr2);
            hashCode = hashCode * -1521134295 + EqualityComparer<Func<T1, TResult>>.Default.GetHashCode(this.func1);
            hashCode = hashCode * -1521134295 + EqualityComparer<Func<T2, TResult>>.Default.GetHashCode(this.func2);
            hashCode = hashCode * -1521134295 + EqualityComparer<Func<ParsingException, ParsingException, Exception>>.Default.GetHashCode(this.error);
            return hashCode;
        }

        internal override InstanceBase<TResult, ParseResult> InstanceImplement<ParseResult>(Parser<ParseResult> parser, List<IExpression> exprs, int thisIndex)
        {
            const int N = 2;
            var exprIndexes = new int[N];
            var funcs = new Func<object, TResult>[N];
            Func<ParsingException[], Exception> error = null;
            if (!(this.error is null))
            {
                error = (excs) => this.error(excs[0], excs[1]);
            }
            exprIndexes[0] = this.expr1.Instance(parser, exprs);
            funcs[0] = (obj) => this.func1((T1)obj);
            exprIndexes[1] = this.expr2.Instance(parser, exprs);
            funcs[1] = (obj) => this.func2((T2)obj);
            return new SelectInstancedClass<TResult, ParseResult>(exprIndexes, funcs, error, parser, thisIndex);
        }
    }

    public class EqualSelect2<T> : Select<T, T, T>
    {
        public EqualSelect2(ExpressionBase<T> expr1, ExpressionBase<T> expr2, Func<T, T> func1, Func<T, T> func2, Func<ParsingException, ParsingException, Exception> error) : base(expr1, expr2, func1, func2, error)
        {

        }

        public Select<T, T, TResult> Change<TResult>(Func<T, TResult> func1, Func<T, TResult> func2, Func<ParsingException, ParsingException, Exception> error)
        {
            return Select<TResult>.Create(this.expr1, this.expr2, func1, func2, error);
        }
        public Select<T, T, TResult> Change<TResult>(Func<T, TResult> func1, Func<T, TResult> func2)
        {
            return Select<TResult>.Create(this.expr1, this.expr2, func1, func2);
        }
        public Select<T, T, T> Change(Func<ParsingException, ParsingException, Exception> error)
        {
            return Select<T>.Create(this.expr1, this.expr2, error);
        }
        public static EqualSelect3<T> operator |(EqualSelect2<T> lhs, ExpressionBase<T> rhs)
        {
            return new EqualSelect3<T>(lhs.expr1, lhs.expr2, rhs, Echo, Echo, Echo, null);
        }
    }
}
