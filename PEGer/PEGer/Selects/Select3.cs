//Copyright (c) 2019 plasma_effect
//This source code is under MIT License. See ./LICENSE
using System;
using System.Collections.Generic;
using System.Text;
using static PEGer.Utility;

namespace PEGer
{
    public class Select<T1, T2, T3, TResult> : ExpressionBase<TResult>
    {
        protected ExpressionBase<T1> expr1;
        protected ExpressionBase<T2> expr2;
        protected ExpressionBase<T3> expr3;

        Func<T1, TResult> func1;
        Func<T2, TResult> func2;
        Func<T3, TResult> func3;

        Func<ParsingException, ParsingException, ParsingException, Exception> error;

        public Select(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, Func<T1, TResult> func1, Func<T2, TResult> func2, Func<T3, TResult> func3, Func<ParsingException, ParsingException, ParsingException, Exception> error)
        {
            this.expr1 = expr1;
            this.expr2 = expr2;
            this.expr3 = expr3;

            this.func1 = func1;
            this.func2 = func2;
            this.func3 = func3;

            this.error = error;
        }

        public override bool Equals(object obj)
        {
            return obj is Select<T1, T2, T3, TResult> select &&
                   EqualityComparer<ExpressionBase<T1>>.Default.Equals(this.expr1, select.expr1) &&
                   EqualityComparer<ExpressionBase<T2>>.Default.Equals(this.expr2, select.expr2) &&
                   EqualityComparer<ExpressionBase<T3>>.Default.Equals(this.expr3, select.expr3) &&
                   EqualityComparer<Func<T1, TResult>>.Default.Equals(this.func1, select.func1) &&
                   EqualityComparer<Func<T2, TResult>>.Default.Equals(this.func2, select.func2) &&
                   EqualityComparer<Func<T3, TResult>>.Default.Equals(this.func3, select.func3) &&
                   EqualityComparer<Func<ParsingException, ParsingException, ParsingException, Exception>>.Default.Equals(this.error, select.error);
        }

        public override int GetHashCode()
        {
            var hashCode = -643119786;
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T1>>.Default.GetHashCode(this.expr1);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T2>>.Default.GetHashCode(this.expr2);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T3>>.Default.GetHashCode(this.expr3);
            hashCode = hashCode * -1521134295 + EqualityComparer<Func<T1, TResult>>.Default.GetHashCode(this.func1);
            hashCode = hashCode * -1521134295 + EqualityComparer<Func<T2, TResult>>.Default.GetHashCode(this.func2);
            hashCode = hashCode * -1521134295 + EqualityComparer<Func<T3, TResult>>.Default.GetHashCode(this.func3);
            hashCode = hashCode * -1521134295 + EqualityComparer<Func<ParsingException, ParsingException, ParsingException, Exception>>.Default.GetHashCode(this.error);
            return hashCode;
        }

        internal override InstanceBase<TResult, ParseResult> InstanceImplement<ParseResult>(Parser<ParseResult> parser, List<IExpression> exprs, int thisIndex)
        {
            const int N = 3;
            var exprIndexes = new int[N];
            var funcs = new Func<object, TResult>[N];
            Func<ParsingException[], Exception> error = null;
            if (!(this.error is null))
            {
                error = (excs) => this.error(excs[0], excs[1], excs[2]);
            }
            exprIndexes[0] = this.expr1.Instance(parser, exprs);
            funcs[0] = (obj) => this.func1((T1)obj);
            exprIndexes[1] = this.expr2.Instance(parser, exprs);
            funcs[1] = (obj) => this.func2((T2)obj);
            exprIndexes[2] = this.expr3.Instance(parser, exprs);
            funcs[2] = (obj) => this.func3((T3)obj);

            return new SelectInstancedClass<TResult, ParseResult>(exprIndexes, funcs, error, parser, thisIndex);
        }
    }

    public class EqualSelect3<T> : Select<T, T, T, T>
    {
        public EqualSelect3(ExpressionBase<T> expr1, ExpressionBase<T> expr2, ExpressionBase<T> expr3, Func<T, T> func1, Func<T, T> func2, Func<T, T> func3, Func<ParsingException, ParsingException, ParsingException, Exception> error) : base(expr1, expr2, expr3, func1, func2, func3, error)
        {

        }

        public Select<T, T, T, TResult> Change<TResult>(Func<T, TResult> func1, Func<T, TResult> func2, Func<T, TResult> func3, Func<ParsingException, ParsingException, ParsingException, Exception> error)
        {
            return Select<TResult>.Create(this.expr1, this.expr2, this.expr3, func1, func2, func3, error);
        }
        public Select<T, T, T, TResult> Change<TResult>(Func<T, TResult> func1, Func<T, TResult> func2, Func<T, TResult> func3)
        {
            return Select<TResult>.Create(this.expr1, this.expr2, this.expr3, func1, func2, func3);
        }
        public Select<T, T, T, T> Change(Func<ParsingException, ParsingException, ParsingException, Exception> error)
        {
            return Select<T>.Create(this.expr1, this.expr2, this.expr3, error);
        }
        public static EqualSelect4<T> operator |(EqualSelect3<T> lhs, ExpressionBase<T> rhs)
        {
            return new EqualSelect4<T>(lhs.expr1, lhs.expr2, lhs.expr3, rhs, Echo, Echo, Echo, Echo, null);
        }
    }
}
