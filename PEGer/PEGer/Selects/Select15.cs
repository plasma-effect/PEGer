//Copyright (c) 2019 plasma_effect
//This source code is under MIT License. See ./LICENSE
using System;
using System.Collections.Generic;
using System.Text;

namespace PEGer
{
    public class Select<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> : ExpressionBase<TResult>
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
        ExpressionBase<T10> expr10;
        ExpressionBase<T11> expr11;
        ExpressionBase<T12> expr12;
        ExpressionBase<T13> expr13;
        ExpressionBase<T14> expr14;
        ExpressionBase<T15> expr15;

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
        Func<T12, TResult> func12;
        Func<T13, TResult> func13;
        Func<T14, TResult> func14;
        Func<T15, TResult> func15;

        Func<ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, Exception> error;

        public Select(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8, ExpressionBase<T9> expr9, ExpressionBase<T10> expr10, ExpressionBase<T11> expr11, ExpressionBase<T12> expr12, ExpressionBase<T13> expr13, ExpressionBase<T14> expr14, ExpressionBase<T15> expr15, Func<T1, TResult> func1, Func<T2, TResult> func2, Func<T3, TResult> func3, Func<T4, TResult> func4, Func<T5, TResult> func5, Func<T6, TResult> func6, Func<T7, TResult> func7, Func<T8, TResult> func8, Func<T9, TResult> func9, Func<T10, TResult> func10, Func<T11, TResult> func11, Func<T12, TResult> func12, Func<T13, TResult> func13, Func<T14, TResult> func14, Func<T15, TResult> func15, Func<ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, Exception> error)
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
            this.expr12 = expr12;
            this.expr13 = expr13;
            this.expr14 = expr14;
            this.expr15 = expr15;

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
            this.func12 = func12;
            this.func13 = func13;
            this.func14 = func14;
            this.func15 = func15;

            this.error = error;
        }

        public override bool Equals(object obj)
        {
            return obj is Select<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> select &&
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
                   EqualityComparer<ExpressionBase<T12>>.Default.Equals(this.expr12, select.expr12) &&
                   EqualityComparer<ExpressionBase<T13>>.Default.Equals(this.expr13, select.expr13) &&
                   EqualityComparer<ExpressionBase<T14>>.Default.Equals(this.expr14, select.expr14) &&
                   EqualityComparer<ExpressionBase<T15>>.Default.Equals(this.expr15, select.expr15) &&
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
                   EqualityComparer<Func<T12, TResult>>.Default.Equals(this.func12, select.func12) &&
                   EqualityComparer<Func<T13, TResult>>.Default.Equals(this.func13, select.func13) &&
                   EqualityComparer<Func<T14, TResult>>.Default.Equals(this.func14, select.func14) &&
                   EqualityComparer<Func<T15, TResult>>.Default.Equals(this.func15, select.func15) &&
                   EqualityComparer<Func<ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, Exception>>.Default.Equals(this.error, select.error);
        }

        public override int GetHashCode()
        {
            var hashCode = -382832842;
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
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T12>>.Default.GetHashCode(this.expr12);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T13>>.Default.GetHashCode(this.expr13);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T14>>.Default.GetHashCode(this.expr14);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T15>>.Default.GetHashCode(this.expr15);
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
            hashCode = hashCode * -1521134295 + EqualityComparer<Func<T12, TResult>>.Default.GetHashCode(this.func12);
            hashCode = hashCode * -1521134295 + EqualityComparer<Func<T13, TResult>>.Default.GetHashCode(this.func13);
            hashCode = hashCode * -1521134295 + EqualityComparer<Func<T14, TResult>>.Default.GetHashCode(this.func14);
            hashCode = hashCode * -1521134295 + EqualityComparer<Func<T15, TResult>>.Default.GetHashCode(this.func15);
            hashCode = hashCode * -1521134295 + EqualityComparer<Func<ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, Exception>>.Default.GetHashCode(this.error);
            return hashCode;
        }

        internal override IInstancedExpression<ParseResult> InstanceImplement<ParseResult>(Parser<ParseResult> parser, List<IExpression> exprs, int thisIndex)
        {
            const int N = 15;
            var exprIndexes = new int[N];
            var funcs = new Func<object, TResult>[N];
            Func<ParsingException[], Exception> error = null;
            if (!(this.error is null))
            {
                error = (excs) => this.error(excs[0], excs[1], excs[2], excs[3], excs[4], excs[5], excs[6], excs[7], excs[8], excs[9], excs[10], excs[11], excs[12], excs[13], excs[14]);
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
            exprIndexes[11] = this.expr12.Instance(parser, exprs);
            funcs[11] = (obj) => this.func12((T12)obj);
            exprIndexes[12] = this.expr13.Instance(parser, exprs);
            funcs[12] = (obj) => this.func13((T13)obj);
            exprIndexes[13] = this.expr14.Instance(parser, exprs);
            funcs[13] = (obj) => this.func14((T14)obj);
            exprIndexes[14] = this.expr15.Instance(parser, exprs);
            funcs[14] = (obj) => this.func15((T15)obj);

            return new SelectInstancedClass<TResult, ParseResult>(exprIndexes, funcs, error, parser, thisIndex);
        }
    }
}
