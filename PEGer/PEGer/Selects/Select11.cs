//Copyright (c) 2019 plasma_effect
//This source code is under MIT License. See ./LICENSE
using System;
using System.Collections.Generic;
using System.Text;
using static PEGer.Utility;

namespace PEGer
{
    public class Select<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> : ExpressionBase<TResult>
    {
        protected ExpressionBase<T1> expr1;
        protected ExpressionBase<T2> expr2;
        protected ExpressionBase<T3> expr3;
        protected ExpressionBase<T4> expr4;
        protected ExpressionBase<T5> expr5;
        protected ExpressionBase<T6> expr6;
        protected ExpressionBase<T7> expr7;
        protected ExpressionBase<T8> expr8;
        protected ExpressionBase<T9> expr9;
        protected ExpressionBase<T10> expr10;
        protected ExpressionBase<T11> expr11;

        Func<T1, TResult> func1;
        Func<T2, TResult> func2;
        Func<T3, TResult> func3;
        Func<T4, TResult> func4;
        Func<T5, TResult> func5;
        Func<T6, TResult> func6;
        Func<T7, TResult> func7;
        Func<T8, TResult> func8;
        Func<T9, TResult> func9;
        Func<T10, TResult> func10;
        Func<T11, TResult> func11;

        Func<ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, Exception> error;

        public Select(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8, ExpressionBase<T9> expr9, ExpressionBase<T10> expr10, ExpressionBase<T11> expr11, Func<T1, TResult> func1, Func<T2, TResult> func2, Func<T3, TResult> func3, Func<T4, TResult> func4, Func<T5, TResult> func5, Func<T6, TResult> func6, Func<T7, TResult> func7, Func<T8, TResult> func8, Func<T9, TResult> func9, Func<T10, TResult> func10, Func<T11, TResult> func11, Func<ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, Exception> error)
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
            this.expr10 = expr10;
            this.expr11 = expr11;

            this.func1 = func1;
            this.func2 = func2;
            this.func3 = func3;
            this.func4 = func4;
            this.func5 = func5;
            this.func6 = func6;
            this.func7 = func7;
            this.func8 = func8;
            this.func9 = func9;
            this.func10 = func10;
            this.func11 = func11;

            this.error = error;
        }

        public override bool Equals(object obj)
        {
            return obj is Select<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> select &&
                   EqualityComparer<ExpressionBase<T1>>.Default.Equals(this.expr1, select.expr1) &&
                   EqualityComparer<ExpressionBase<T2>>.Default.Equals(this.expr2, select.expr2) &&
                   EqualityComparer<ExpressionBase<T3>>.Default.Equals(this.expr3, select.expr3) &&
                   EqualityComparer<ExpressionBase<T4>>.Default.Equals(this.expr4, select.expr4) &&
                   EqualityComparer<ExpressionBase<T5>>.Default.Equals(this.expr5, select.expr5) &&
                   EqualityComparer<ExpressionBase<T6>>.Default.Equals(this.expr6, select.expr6) &&
                   EqualityComparer<ExpressionBase<T7>>.Default.Equals(this.expr7, select.expr7) &&
                   EqualityComparer<ExpressionBase<T8>>.Default.Equals(this.expr8, select.expr8) &&
                   EqualityComparer<ExpressionBase<T9>>.Default.Equals(this.expr9, select.expr9) &&
                   EqualityComparer<ExpressionBase<T10>>.Default.Equals(this.expr10, select.expr10) &&
                   EqualityComparer<ExpressionBase<T11>>.Default.Equals(this.expr11, select.expr11) &&
                   EqualityComparer<Func<T1, TResult>>.Default.Equals(this.func1, select.func1) &&
                   EqualityComparer<Func<T2, TResult>>.Default.Equals(this.func2, select.func2) &&
                   EqualityComparer<Func<T3, TResult>>.Default.Equals(this.func3, select.func3) &&
                   EqualityComparer<Func<T4, TResult>>.Default.Equals(this.func4, select.func4) &&
                   EqualityComparer<Func<T5, TResult>>.Default.Equals(this.func5, select.func5) &&
                   EqualityComparer<Func<T6, TResult>>.Default.Equals(this.func6, select.func6) &&
                   EqualityComparer<Func<T7, TResult>>.Default.Equals(this.func7, select.func7) &&
                   EqualityComparer<Func<T8, TResult>>.Default.Equals(this.func8, select.func8) &&
                   EqualityComparer<Func<T9, TResult>>.Default.Equals(this.func9, select.func9) &&
                   EqualityComparer<Func<T10, TResult>>.Default.Equals(this.func10, select.func10) &&
                   EqualityComparer<Func<T11, TResult>>.Default.Equals(this.func11, select.func11) &&
                   EqualityComparer<Func<ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, Exception>>.Default.Equals(this.error, select.error);
        }

        public override int GetHashCode()
        {
            var hashCode = 1648485858;
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T1>>.Default.GetHashCode(this.expr1);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T2>>.Default.GetHashCode(this.expr2);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T3>>.Default.GetHashCode(this.expr3);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T4>>.Default.GetHashCode(this.expr4);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T5>>.Default.GetHashCode(this.expr5);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T6>>.Default.GetHashCode(this.expr6);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T7>>.Default.GetHashCode(this.expr7);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T8>>.Default.GetHashCode(this.expr8);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T9>>.Default.GetHashCode(this.expr9);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T10>>.Default.GetHashCode(this.expr10);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T11>>.Default.GetHashCode(this.expr11);
            hashCode = hashCode * -1521134295 + EqualityComparer<Func<T1, TResult>>.Default.GetHashCode(this.func1);
            hashCode = hashCode * -1521134295 + EqualityComparer<Func<T2, TResult>>.Default.GetHashCode(this.func2);
            hashCode = hashCode * -1521134295 + EqualityComparer<Func<T3, TResult>>.Default.GetHashCode(this.func3);
            hashCode = hashCode * -1521134295 + EqualityComparer<Func<T4, TResult>>.Default.GetHashCode(this.func4);
            hashCode = hashCode * -1521134295 + EqualityComparer<Func<T5, TResult>>.Default.GetHashCode(this.func5);
            hashCode = hashCode * -1521134295 + EqualityComparer<Func<T6, TResult>>.Default.GetHashCode(this.func6);
            hashCode = hashCode * -1521134295 + EqualityComparer<Func<T7, TResult>>.Default.GetHashCode(this.func7);
            hashCode = hashCode * -1521134295 + EqualityComparer<Func<T8, TResult>>.Default.GetHashCode(this.func8);
            hashCode = hashCode * -1521134295 + EqualityComparer<Func<T9, TResult>>.Default.GetHashCode(this.func9);
            hashCode = hashCode * -1521134295 + EqualityComparer<Func<T10, TResult>>.Default.GetHashCode(this.func10);
            hashCode = hashCode * -1521134295 + EqualityComparer<Func<T11, TResult>>.Default.GetHashCode(this.func11);
            hashCode = hashCode * -1521134295 + EqualityComparer<Func<ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, Exception>>.Default.GetHashCode(this.error);
            return hashCode;
        }

        internal override InstanceBase<TResult, ParseResult> InstanceImplement<ParseResult>(Parser<ParseResult> parser, List<IExpression> exprs, int thisIndex)
        {
            const int N = 11;
            var exprIndexes = new int[N];
            var funcs = new Func<object, TResult>[N];
            Func<ParsingException[], Exception> error = null;
            if (!(this.error is null))
            {
                error = (excs) => this.error(excs[0], excs[1], excs[2], excs[3], excs[4], excs[5], excs[6], excs[7], excs[8], excs[9], excs[10]);
            }
            exprIndexes[0] = this.expr1.Instance(parser, exprs);
            funcs[0] = (obj) => this.func1((T1)obj);
            exprIndexes[1] = this.expr2.Instance(parser, exprs);
            funcs[1] = (obj) => this.func2((T2)obj);
            exprIndexes[2] = this.expr3.Instance(parser, exprs);
            funcs[2] = (obj) => this.func3((T3)obj);
            exprIndexes[3] = this.expr4.Instance(parser, exprs);
            funcs[3] = (obj) => this.func4((T4)obj);
            exprIndexes[4] = this.expr5.Instance(parser, exprs);
            funcs[4] = (obj) => this.func5((T5)obj);
            exprIndexes[5] = this.expr6.Instance(parser, exprs);
            funcs[5] = (obj) => this.func6((T6)obj);
            exprIndexes[6] = this.expr7.Instance(parser, exprs);
            funcs[6] = (obj) => this.func7((T7)obj);
            exprIndexes[7] = this.expr8.Instance(parser, exprs);
            funcs[7] = (obj) => this.func8((T8)obj);
            exprIndexes[8] = this.expr9.Instance(parser, exprs);
            funcs[8] = (obj) => this.func9((T9)obj);
            exprIndexes[9] = this.expr10.Instance(parser, exprs);
            funcs[9] = (obj) => this.func10((T10)obj);
            exprIndexes[10] = this.expr11.Instance(parser, exprs);
            funcs[10] = (obj) => this.func11((T11)obj);

            return new SelectInstancedClass<TResult, ParseResult>(exprIndexes, funcs, error, parser, thisIndex);
        }
    }

    public class EqualSelect11<T> : Select<T, T, T, T, T, T, T, T, T, T, T, T>
    {
        public EqualSelect11(ExpressionBase<T> expr1, ExpressionBase<T> expr2, ExpressionBase<T> expr3, ExpressionBase<T> expr4, ExpressionBase<T> expr5, ExpressionBase<T> expr6, ExpressionBase<T> expr7, ExpressionBase<T> expr8, ExpressionBase<T> expr9, ExpressionBase<T> expr10, ExpressionBase<T> expr11, Func<T, T> func1, Func<T, T> func2, Func<T, T> func3, Func<T, T> func4, Func<T, T> func5, Func<T, T> func6, Func<T, T> func7, Func<T, T> func8, Func<T, T> func9, Func<T, T> func10, Func<T, T> func11, Func<ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, Exception> error) : base(expr1, expr2, expr3, expr4, expr5, expr6, expr7, expr8, expr9, expr10, expr11, func1, func2, func3, func4, func5, func6, func7, func8, func9, func10, func11, error)
        {

        }

        public Select<T, T, T, T, T, T, T, T, T, T, T, TResult> Change<TResult>(Func<T, TResult> func1, Func<T, TResult> func2, Func<T, TResult> func3, Func<T, TResult> func4, Func<T, TResult> func5, Func<T, TResult> func6, Func<T, TResult> func7, Func<T, TResult> func8, Func<T, TResult> func9, Func<T, TResult> func10, Func<T, TResult> func11, Func<ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, Exception> error)
        {
            return Select<TResult>.Create(this.expr1, this.expr2, this.expr3, this.expr4, this.expr5, this.expr6, this.expr7, this.expr8, this.expr9, this.expr10, this.expr11, func1, func2, func3, func4, func5, func6, func7, func8, func9, func10, func11, error);
        }
        public Select<T, T, T, T, T, T, T, T, T, T, T, TResult> Change<TResult>(Func<T, TResult> func1, Func<T, TResult> func2, Func<T, TResult> func3, Func<T, TResult> func4, Func<T, TResult> func5, Func<T, TResult> func6, Func<T, TResult> func7, Func<T, TResult> func8, Func<T, TResult> func9, Func<T, TResult> func10, Func<T, TResult> func11)
        {
            return Select<TResult>.Create(this.expr1, this.expr2, this.expr3, this.expr4, this.expr5, this.expr6, this.expr7, this.expr8, this.expr9, this.expr10, this.expr11, func1, func2, func3, func4, func5, func6, func7, func8, func9, func10, func11);
        }
        public Select<T, T, T, T, T, T, T, T, T, T, T, T> Change(Func<ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, Exception> error)
        {
            return Select<T>.Create(this.expr1, this.expr2, this.expr3, this.expr4, this.expr5, this.expr6, this.expr7, this.expr8, this.expr9, this.expr10, this.expr11, error);
        }
        public static EqualSelect12<T> operator |(EqualSelect11<T> lhs, ExpressionBase<T> rhs)
        {
            return new EqualSelect12<T>(lhs.expr1, lhs.expr2, lhs.expr3, lhs.expr4, lhs.expr5, lhs.expr6, lhs.expr7, lhs.expr8, lhs.expr9, lhs.expr10, lhs.expr11, rhs, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, null);
        }
    }
}
