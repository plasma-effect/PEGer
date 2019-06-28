//Copyright (c) 2019 plasma_effect
//This source code is under MIT License. See ./LICENSE
using System;
using System.Collections.Generic;
using System.Text;

namespace PEGer
{
    public class MakeSequence<T1, T2>
    {
        internal ExpressionBase<T1> expr1;
        internal ExpressionBase<T2> expr2;

        internal MakeSequence(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2)
        {
            this.expr1 = expr1;
            this.expr2 = expr2;
        }

        /// <summary>
        /// Transform to Sequence Expression
        /// </summary>
        /// <typeparam name="TResult">Return Type</typeparam>
        /// <param name="func">Transform Function</param>
        /// <returns>Sequence Expression</returns>
        public Sequence<T1, T2, TResult> ToExpr<TResult>(Func<T1, T2, TResult> func)
        {
            return Sequence.Create(this.expr1, this.expr2, func);
        }

        /// <summary>
        /// Transform to Sequence Expression with Custom Function
        /// </summary>
        /// <typeparam name="TResult">Return Type</typeparam>
        /// <param name="func">Transform Function</param>
        /// <param name="error">Function that return Custom Exception</param>
        /// <returns>Sequence Expression</returns>
        public Sequence<T1, T2, TResult> ToExpr<TResult>(Func<T1, T2, TResult> func, Func<ParsingException, int, Exception> error)
        {
            return Sequence.Create(this.expr1, this.expr2, func, error);
        }

        public MakeSequence<T1, T2, T3> Next<T3>(ExpressionBase<T3> rhs)
        {
            return new MakeSequence<T1, T2, T3>(this.expr1, this.expr2, rhs);
        }
    }
    public class MakeSequence<T1, T2, T3>
    {
        internal ExpressionBase<T1> expr1;
        internal ExpressionBase<T2> expr2;
        internal ExpressionBase<T3> expr3;

        internal MakeSequence(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3)
        {
            this.expr1 = expr1;
            this.expr2 = expr2;
            this.expr3 = expr3;

        }

        /// <summary>
        /// Transform to Sequence Expression
        /// </summary>
        /// <typeparam name="TResult">Return Type</typeparam>
        /// <param name="func">Transform Function</param>
        /// <returns>Sequence Expression</returns>
        public Sequence<T1, T2, T3, TResult> ToExpr<TResult>(Func<T1, T2, T3, TResult> func)
        {
            return Sequence.Create(this.expr1, this.expr2, this.expr3, func);
        }

        /// <summary>
        /// Transform to Sequence Expression with Custom Function
        /// </summary>
        /// <typeparam name="TResult">Return Type</typeparam>
        /// <param name="func">Transform Function</param>
        /// <param name="error">Function that return Custom Exception</param>
        /// <returns>Sequence Expression</returns>
        public Sequence<T1, T2, T3, TResult> ToExpr<TResult>(Func<T1, T2, T3, TResult> func, Func<ParsingException, int, Exception> error)
        {
            return Sequence.Create(this.expr1, this.expr2, this.expr3, func, error);
        }

        public MakeSequence<T1, T2, T3, T4> Next<T4>(ExpressionBase<T4> rhs)
        {
            return new MakeSequence<T1, T2, T3, T4>(this.expr1, this.expr2, this.expr3, rhs);
        }
    }
    public class MakeSequence<T1, T2, T3, T4>
    {
        internal ExpressionBase<T1> expr1;
        internal ExpressionBase<T2> expr2;
        internal ExpressionBase<T3> expr3;
        internal ExpressionBase<T4> expr4;

        internal MakeSequence(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4)
        {
            this.expr1 = expr1;
            this.expr2 = expr2;
            this.expr3 = expr3;
            this.expr4 = expr4;

        }

        /// <summary>
        /// Transform to Sequence Expression
        /// </summary>
        /// <typeparam name="TResult">Return Type</typeparam>
        /// <param name="func">Transform Function</param>
        /// <returns>Sequence Expression</returns>
        public Sequence<T1, T2, T3, T4, TResult> ToExpr<TResult>(Func<T1, T2, T3, T4, TResult> func)
        {
            return Sequence.Create(this.expr1, this.expr2, this.expr3, this.expr4, func);
        }

        /// <summary>
        /// Transform to Sequence Expression with Custom Function
        /// </summary>
        /// <typeparam name="TResult">Return Type</typeparam>
        /// <param name="func">Transform Function</param>
        /// <param name="error">Function that return Custom Exception</param>
        /// <returns>Sequence Expression</returns>
        public Sequence<T1, T2, T3, T4, TResult> ToExpr<TResult>(Func<T1, T2, T3, T4, TResult> func, Func<ParsingException, int, Exception> error)
        {
            return Sequence.Create(this.expr1, this.expr2, this.expr3, this.expr4, func, error);
        }

        public MakeSequence<T1, T2, T3, T4, T5> Next<T5>(ExpressionBase<T5> rhs)
        {
            return new MakeSequence<T1, T2, T3, T4, T5>(this.expr1, this.expr2, this.expr3, this.expr4, rhs);
        }
    }
    public class MakeSequence<T1, T2, T3, T4, T5>
    {
        internal ExpressionBase<T1> expr1;
        internal ExpressionBase<T2> expr2;
        internal ExpressionBase<T3> expr3;
        internal ExpressionBase<T4> expr4;
        internal ExpressionBase<T5> expr5;

        internal MakeSequence(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5)
        {
            this.expr1 = expr1;
            this.expr2 = expr2;
            this.expr3 = expr3;
            this.expr4 = expr4;
            this.expr5 = expr5;

        }

        /// <summary>
        /// Transform to Sequence Expression
        /// </summary>
        /// <typeparam name="TResult">Return Type</typeparam>
        /// <param name="func">Transform Function</param>
        /// <returns>Sequence Expression</returns>
        public Sequence<T1, T2, T3, T4, T5, TResult> ToExpr<TResult>(Func<T1, T2, T3, T4, T5, TResult> func)
        {
            return Sequence.Create(this.expr1, this.expr2, this.expr3, this.expr4, this.expr5, func);
        }

        /// <summary>
        /// Transform to Sequence Expression with Custom Function
        /// </summary>
        /// <typeparam name="TResult">Return Type</typeparam>
        /// <param name="func">Transform Function</param>
        /// <param name="error">Function that return Custom Exception</param>
        /// <returns>Sequence Expression</returns>
        public Sequence<T1, T2, T3, T4, T5, TResult> ToExpr<TResult>(Func<T1, T2, T3, T4, T5, TResult> func, Func<ParsingException, int, Exception> error)
        {
            return Sequence.Create(this.expr1, this.expr2, this.expr3, this.expr4, this.expr5, func, error);
        }

        public MakeSequence<T1, T2, T3, T4, T5, T6> Next<T6>(ExpressionBase<T6> rhs)
        {
            return new MakeSequence<T1, T2, T3, T4, T5, T6>(this.expr1, this.expr2, this.expr3, this.expr4, this.expr5, rhs);
        }
    }
    public class MakeSequence<T1, T2, T3, T4, T5, T6>
    {
        internal ExpressionBase<T1> expr1;
        internal ExpressionBase<T2> expr2;
        internal ExpressionBase<T3> expr3;
        internal ExpressionBase<T4> expr4;
        internal ExpressionBase<T5> expr5;
        internal ExpressionBase<T6> expr6;

        internal MakeSequence(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6)
        {
            this.expr1 = expr1;
            this.expr2 = expr2;
            this.expr3 = expr3;
            this.expr4 = expr4;
            this.expr5 = expr5;
            this.expr6 = expr6;

        }

        /// <summary>
        /// Transform to Sequence Expression
        /// </summary>
        /// <typeparam name="TResult">Return Type</typeparam>
        /// <param name="func">Transform Function</param>
        /// <returns>Sequence Expression</returns>
        public Sequence<T1, T2, T3, T4, T5, T6, TResult> ToExpr<TResult>(Func<T1, T2, T3, T4, T5, T6, TResult> func)
        {
            return Sequence.Create(this.expr1, this.expr2, this.expr3, this.expr4, this.expr5, this.expr6, func);
        }

        /// <summary>
        /// Transform to Sequence Expression with Custom Function
        /// </summary>
        /// <typeparam name="TResult">Return Type</typeparam>
        /// <param name="func">Transform Function</param>
        /// <param name="error">Function that return Custom Exception</param>
        /// <returns>Sequence Expression</returns>
        public Sequence<T1, T2, T3, T4, T5, T6, TResult> ToExpr<TResult>(Func<T1, T2, T3, T4, T5, T6, TResult> func, Func<ParsingException, int, Exception> error)
        {
            return Sequence.Create(this.expr1, this.expr2, this.expr3, this.expr4, this.expr5, this.expr6, func, error);
        }

        public MakeSequence<T1, T2, T3, T4, T5, T6, T7> Next<T7>(ExpressionBase<T7> rhs)
        {
            return new MakeSequence<T1, T2, T3, T4, T5, T6, T7>(this.expr1, this.expr2, this.expr3, this.expr4, this.expr5, this.expr6, rhs);
        }
    }
    public class MakeSequence<T1, T2, T3, T4, T5, T6, T7>
    {
        internal ExpressionBase<T1> expr1;
        internal ExpressionBase<T2> expr2;
        internal ExpressionBase<T3> expr3;
        internal ExpressionBase<T4> expr4;
        internal ExpressionBase<T5> expr5;
        internal ExpressionBase<T6> expr6;
        internal ExpressionBase<T7> expr7;

        internal MakeSequence(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7)
        {
            this.expr1 = expr1;
            this.expr2 = expr2;
            this.expr3 = expr3;
            this.expr4 = expr4;
            this.expr5 = expr5;
            this.expr6 = expr6;
            this.expr7 = expr7;

        }

        /// <summary>
        /// Transform to Sequence Expression
        /// </summary>
        /// <typeparam name="TResult">Return Type</typeparam>
        /// <param name="func">Transform Function</param>
        /// <returns>Sequence Expression</returns>
        public Sequence<T1, T2, T3, T4, T5, T6, T7, TResult> ToExpr<TResult>(Func<T1, T2, T3, T4, T5, T6, T7, TResult> func)
        {
            return Sequence.Create(this.expr1, this.expr2, this.expr3, this.expr4, this.expr5, this.expr6, this.expr7, func);
        }

        /// <summary>
        /// Transform to Sequence Expression with Custom Function
        /// </summary>
        /// <typeparam name="TResult">Return Type</typeparam>
        /// <param name="func">Transform Function</param>
        /// <param name="error">Function that return Custom Exception</param>
        /// <returns>Sequence Expression</returns>
        public Sequence<T1, T2, T3, T4, T5, T6, T7, TResult> ToExpr<TResult>(Func<T1, T2, T3, T4, T5, T6, T7, TResult> func, Func<ParsingException, int, Exception> error)
        {
            return Sequence.Create(this.expr1, this.expr2, this.expr3, this.expr4, this.expr5, this.expr6, this.expr7, func, error);
        }

        public MakeSequence<T1, T2, T3, T4, T5, T6, T7, T8> Next<T8>(ExpressionBase<T8> rhs)
        {
            return new MakeSequence<T1, T2, T3, T4, T5, T6, T7, T8>(this.expr1, this.expr2, this.expr3, this.expr4, this.expr5, this.expr6, this.expr7, rhs);
        }
    }
    public class MakeSequence<T1, T2, T3, T4, T5, T6, T7, T8>
    {
        internal ExpressionBase<T1> expr1;
        internal ExpressionBase<T2> expr2;
        internal ExpressionBase<T3> expr3;
        internal ExpressionBase<T4> expr4;
        internal ExpressionBase<T5> expr5;
        internal ExpressionBase<T6> expr6;
        internal ExpressionBase<T7> expr7;
        internal ExpressionBase<T8> expr8;

        internal MakeSequence(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8)
        {
            this.expr1 = expr1;
            this.expr2 = expr2;
            this.expr3 = expr3;
            this.expr4 = expr4;
            this.expr5 = expr5;
            this.expr6 = expr6;
            this.expr7 = expr7;
            this.expr8 = expr8;

        }

        /// <summary>
        /// Transform to Sequence Expression
        /// </summary>
        /// <typeparam name="TResult">Return Type</typeparam>
        /// <param name="func">Transform Function</param>
        /// <returns>Sequence Expression</returns>
        public Sequence<T1, T2, T3, T4, T5, T6, T7, T8, TResult> ToExpr<TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> func)
        {
            return Sequence.Create(this.expr1, this.expr2, this.expr3, this.expr4, this.expr5, this.expr6, this.expr7, this.expr8, func);
        }

        /// <summary>
        /// Transform to Sequence Expression with Custom Function
        /// </summary>
        /// <typeparam name="TResult">Return Type</typeparam>
        /// <param name="func">Transform Function</param>
        /// <param name="error">Function that return Custom Exception</param>
        /// <returns>Sequence Expression</returns>
        public Sequence<T1, T2, T3, T4, T5, T6, T7, T8, TResult> ToExpr<TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> func, Func<ParsingException, int, Exception> error)
        {
            return Sequence.Create(this.expr1, this.expr2, this.expr3, this.expr4, this.expr5, this.expr6, this.expr7, this.expr8, func, error);
        }

        public MakeSequence<T1, T2, T3, T4, T5, T6, T7, T8, T9> Next<T9>(ExpressionBase<T9> rhs)
        {
            return new MakeSequence<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this.expr1, this.expr2, this.expr3, this.expr4, this.expr5, this.expr6, this.expr7, this.expr8, rhs);
        }
    }
    public class MakeSequence<T1, T2, T3, T4, T5, T6, T7, T8, T9>
    {
        internal ExpressionBase<T1> expr1;
        internal ExpressionBase<T2> expr2;
        internal ExpressionBase<T3> expr3;
        internal ExpressionBase<T4> expr4;
        internal ExpressionBase<T5> expr5;
        internal ExpressionBase<T6> expr6;
        internal ExpressionBase<T7> expr7;
        internal ExpressionBase<T8> expr8;
        internal ExpressionBase<T9> expr9;

        internal MakeSequence(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8, ExpressionBase<T9> expr9)
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

        }

        /// <summary>
        /// Transform to Sequence Expression
        /// </summary>
        /// <typeparam name="TResult">Return Type</typeparam>
        /// <param name="func">Transform Function</param>
        /// <returns>Sequence Expression</returns>
        public Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> ToExpr<TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> func)
        {
            return Sequence.Create(this.expr1, this.expr2, this.expr3, this.expr4, this.expr5, this.expr6, this.expr7, this.expr8, this.expr9, func);
        }

        /// <summary>
        /// Transform to Sequence Expression with Custom Function
        /// </summary>
        /// <typeparam name="TResult">Return Type</typeparam>
        /// <param name="func">Transform Function</param>
        /// <param name="error">Function that return Custom Exception</param>
        /// <returns>Sequence Expression</returns>
        public Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> ToExpr<TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> func, Func<ParsingException, int, Exception> error)
        {
            return Sequence.Create(this.expr1, this.expr2, this.expr3, this.expr4, this.expr5, this.expr6, this.expr7, this.expr8, this.expr9, func, error);
        }

        public MakeSequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Next<T10>(ExpressionBase<T10> rhs)
        {
            return new MakeSequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this.expr1, this.expr2, this.expr3, this.expr4, this.expr5, this.expr6, this.expr7, this.expr8, this.expr9, rhs);
        }
    }
    public class MakeSequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>
    {
        internal ExpressionBase<T1> expr1;
        internal ExpressionBase<T2> expr2;
        internal ExpressionBase<T3> expr3;
        internal ExpressionBase<T4> expr4;
        internal ExpressionBase<T5> expr5;
        internal ExpressionBase<T6> expr6;
        internal ExpressionBase<T7> expr7;
        internal ExpressionBase<T8> expr8;
        internal ExpressionBase<T9> expr9;
        internal ExpressionBase<T10> expr10;

        internal MakeSequence(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8, ExpressionBase<T9> expr9, ExpressionBase<T10> expr10)
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

        }

        /// <summary>
        /// Transform to Sequence Expression
        /// </summary>
        /// <typeparam name="TResult">Return Type</typeparam>
        /// <param name="func">Transform Function</param>
        /// <returns>Sequence Expression</returns>
        public Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> ToExpr<TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> func)
        {
            return Sequence.Create(this.expr1, this.expr2, this.expr3, this.expr4, this.expr5, this.expr6, this.expr7, this.expr8, this.expr9, this.expr10, func);
        }

        /// <summary>
        /// Transform to Sequence Expression with Custom Function
        /// </summary>
        /// <typeparam name="TResult">Return Type</typeparam>
        /// <param name="func">Transform Function</param>
        /// <param name="error">Function that return Custom Exception</param>
        /// <returns>Sequence Expression</returns>
        public Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> ToExpr<TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> func, Func<ParsingException, int, Exception> error)
        {
            return Sequence.Create(this.expr1, this.expr2, this.expr3, this.expr4, this.expr5, this.expr6, this.expr7, this.expr8, this.expr9, this.expr10, func, error);
        }

        public MakeSequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Next<T11>(ExpressionBase<T11> rhs)
        {
            return new MakeSequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this.expr1, this.expr2, this.expr3, this.expr4, this.expr5, this.expr6, this.expr7, this.expr8, this.expr9, this.expr10, rhs);
        }
    }
    public class MakeSequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>
    {
        internal ExpressionBase<T1> expr1;
        internal ExpressionBase<T2> expr2;
        internal ExpressionBase<T3> expr3;
        internal ExpressionBase<T4> expr4;
        internal ExpressionBase<T5> expr5;
        internal ExpressionBase<T6> expr6;
        internal ExpressionBase<T7> expr7;
        internal ExpressionBase<T8> expr8;
        internal ExpressionBase<T9> expr9;
        internal ExpressionBase<T10> expr10;
        internal ExpressionBase<T11> expr11;

        internal MakeSequence(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8, ExpressionBase<T9> expr9, ExpressionBase<T10> expr10, ExpressionBase<T11> expr11)
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

        }

        /// <summary>
        /// Transform to Sequence Expression
        /// </summary>
        /// <typeparam name="TResult">Return Type</typeparam>
        /// <param name="func">Transform Function</param>
        /// <returns>Sequence Expression</returns>
        public Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> ToExpr<TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> func)
        {
            return Sequence.Create(this.expr1, this.expr2, this.expr3, this.expr4, this.expr5, this.expr6, this.expr7, this.expr8, this.expr9, this.expr10, this.expr11, func);
        }

        /// <summary>
        /// Transform to Sequence Expression with Custom Function
        /// </summary>
        /// <typeparam name="TResult">Return Type</typeparam>
        /// <param name="func">Transform Function</param>
        /// <param name="error">Function that return Custom Exception</param>
        /// <returns>Sequence Expression</returns>
        public Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> ToExpr<TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> func, Func<ParsingException, int, Exception> error)
        {
            return Sequence.Create(this.expr1, this.expr2, this.expr3, this.expr4, this.expr5, this.expr6, this.expr7, this.expr8, this.expr9, this.expr10, this.expr11, func, error);
        }

        public MakeSequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Next<T12>(ExpressionBase<T12> rhs)
        {
            return new MakeSequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this.expr1, this.expr2, this.expr3, this.expr4, this.expr5, this.expr6, this.expr7, this.expr8, this.expr9, this.expr10, this.expr11, rhs);
        }
    }
    public class MakeSequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>
    {
        internal ExpressionBase<T1> expr1;
        internal ExpressionBase<T2> expr2;
        internal ExpressionBase<T3> expr3;
        internal ExpressionBase<T4> expr4;
        internal ExpressionBase<T5> expr5;
        internal ExpressionBase<T6> expr6;
        internal ExpressionBase<T7> expr7;
        internal ExpressionBase<T8> expr8;
        internal ExpressionBase<T9> expr9;
        internal ExpressionBase<T10> expr10;
        internal ExpressionBase<T11> expr11;
        internal ExpressionBase<T12> expr12;

        internal MakeSequence(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8, ExpressionBase<T9> expr9, ExpressionBase<T10> expr10, ExpressionBase<T11> expr11, ExpressionBase<T12> expr12)
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

        }

        /// <summary>
        /// Transform to Sequence Expression
        /// </summary>
        /// <typeparam name="TResult">Return Type</typeparam>
        /// <param name="func">Transform Function</param>
        /// <returns>Sequence Expression</returns>
        public Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> ToExpr<TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> func)
        {
            return Sequence.Create(this.expr1, this.expr2, this.expr3, this.expr4, this.expr5, this.expr6, this.expr7, this.expr8, this.expr9, this.expr10, this.expr11, this.expr12, func);
        }

        /// <summary>
        /// Transform to Sequence Expression with Custom Function
        /// </summary>
        /// <typeparam name="TResult">Return Type</typeparam>
        /// <param name="func">Transform Function</param>
        /// <param name="error">Function that return Custom Exception</param>
        /// <returns>Sequence Expression</returns>
        public Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> ToExpr<TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> func, Func<ParsingException, int, Exception> error)
        {
            return Sequence.Create(this.expr1, this.expr2, this.expr3, this.expr4, this.expr5, this.expr6, this.expr7, this.expr8, this.expr9, this.expr10, this.expr11, this.expr12, func, error);
        }

        public MakeSequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Next<T13>(ExpressionBase<T13> rhs)
        {
            return new MakeSequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this.expr1, this.expr2, this.expr3, this.expr4, this.expr5, this.expr6, this.expr7, this.expr8, this.expr9, this.expr10, this.expr11, this.expr12, rhs);
        }
    }
    public class MakeSequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>
    {
        internal ExpressionBase<T1> expr1;
        internal ExpressionBase<T2> expr2;
        internal ExpressionBase<T3> expr3;
        internal ExpressionBase<T4> expr4;
        internal ExpressionBase<T5> expr5;
        internal ExpressionBase<T6> expr6;
        internal ExpressionBase<T7> expr7;
        internal ExpressionBase<T8> expr8;
        internal ExpressionBase<T9> expr9;
        internal ExpressionBase<T10> expr10;
        internal ExpressionBase<T11> expr11;
        internal ExpressionBase<T12> expr12;
        internal ExpressionBase<T13> expr13;

        internal MakeSequence(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8, ExpressionBase<T9> expr9, ExpressionBase<T10> expr10, ExpressionBase<T11> expr11, ExpressionBase<T12> expr12, ExpressionBase<T13> expr13)
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

        }

        /// <summary>
        /// Transform to Sequence Expression
        /// </summary>
        /// <typeparam name="TResult">Return Type</typeparam>
        /// <param name="func">Transform Function</param>
        /// <returns>Sequence Expression</returns>
        public Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> ToExpr<TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> func)
        {
            return Sequence.Create(this.expr1, this.expr2, this.expr3, this.expr4, this.expr5, this.expr6, this.expr7, this.expr8, this.expr9, this.expr10, this.expr11, this.expr12, this.expr13, func);
        }

        /// <summary>
        /// Transform to Sequence Expression with Custom Function
        /// </summary>
        /// <typeparam name="TResult">Return Type</typeparam>
        /// <param name="func">Transform Function</param>
        /// <param name="error">Function that return Custom Exception</param>
        /// <returns>Sequence Expression</returns>
        public Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> ToExpr<TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> func, Func<ParsingException, int, Exception> error)
        {
            return Sequence.Create(this.expr1, this.expr2, this.expr3, this.expr4, this.expr5, this.expr6, this.expr7, this.expr8, this.expr9, this.expr10, this.expr11, this.expr12, this.expr13, func, error);
        }

        public MakeSequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Next<T14>(ExpressionBase<T14> rhs)
        {
            return new MakeSequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this.expr1, this.expr2, this.expr3, this.expr4, this.expr5, this.expr6, this.expr7, this.expr8, this.expr9, this.expr10, this.expr11, this.expr12, this.expr13, rhs);
        }
    }
    public class MakeSequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>
    {
        internal ExpressionBase<T1> expr1;
        internal ExpressionBase<T2> expr2;
        internal ExpressionBase<T3> expr3;
        internal ExpressionBase<T4> expr4;
        internal ExpressionBase<T5> expr5;
        internal ExpressionBase<T6> expr6;
        internal ExpressionBase<T7> expr7;
        internal ExpressionBase<T8> expr8;
        internal ExpressionBase<T9> expr9;
        internal ExpressionBase<T10> expr10;
        internal ExpressionBase<T11> expr11;
        internal ExpressionBase<T12> expr12;
        internal ExpressionBase<T13> expr13;
        internal ExpressionBase<T14> expr14;

        internal MakeSequence(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8, ExpressionBase<T9> expr9, ExpressionBase<T10> expr10, ExpressionBase<T11> expr11, ExpressionBase<T12> expr12, ExpressionBase<T13> expr13, ExpressionBase<T14> expr14)
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

        }

        /// <summary>
        /// Transform to Sequence Expression
        /// </summary>
        /// <typeparam name="TResult">Return Type</typeparam>
        /// <param name="func">Transform Function</param>
        /// <returns>Sequence Expression</returns>
        public Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> ToExpr<TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> func)
        {
            return Sequence.Create(this.expr1, this.expr2, this.expr3, this.expr4, this.expr5, this.expr6, this.expr7, this.expr8, this.expr9, this.expr10, this.expr11, this.expr12, this.expr13, this.expr14, func);
        }

        /// <summary>
        /// Transform to Sequence Expression with Custom Function
        /// </summary>
        /// <typeparam name="TResult">Return Type</typeparam>
        /// <param name="func">Transform Function</param>
        /// <param name="error">Function that return Custom Exception</param>
        /// <returns>Sequence Expression</returns>
        public Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> ToExpr<TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> func, Func<ParsingException, int, Exception> error)
        {
            return Sequence.Create(this.expr1, this.expr2, this.expr3, this.expr4, this.expr5, this.expr6, this.expr7, this.expr8, this.expr9, this.expr10, this.expr11, this.expr12, this.expr13, this.expr14, func, error);
        }

        public MakeSequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Next<T15>(ExpressionBase<T15> rhs)
        {
            return new MakeSequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this.expr1, this.expr2, this.expr3, this.expr4, this.expr5, this.expr6, this.expr7, this.expr8, this.expr9, this.expr10, this.expr11, this.expr12, this.expr13, this.expr14, rhs);
        }
    }
    public class MakeSequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>
    {
        internal ExpressionBase<T1> expr1;
        internal ExpressionBase<T2> expr2;
        internal ExpressionBase<T3> expr3;
        internal ExpressionBase<T4> expr4;
        internal ExpressionBase<T5> expr5;
        internal ExpressionBase<T6> expr6;
        internal ExpressionBase<T7> expr7;
        internal ExpressionBase<T8> expr8;
        internal ExpressionBase<T9> expr9;
        internal ExpressionBase<T10> expr10;
        internal ExpressionBase<T11> expr11;
        internal ExpressionBase<T12> expr12;
        internal ExpressionBase<T13> expr13;
        internal ExpressionBase<T14> expr14;
        internal ExpressionBase<T15> expr15;

        internal MakeSequence(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8, ExpressionBase<T9> expr9, ExpressionBase<T10> expr10, ExpressionBase<T11> expr11, ExpressionBase<T12> expr12, ExpressionBase<T13> expr13, ExpressionBase<T14> expr14, ExpressionBase<T15> expr15)
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

        }

        /// <summary>
        /// Transform to Sequence Expression
        /// </summary>
        /// <typeparam name="TResult">Return Type</typeparam>
        /// <param name="func">Transform Function</param>
        /// <returns>Sequence Expression</returns>
        public Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> ToExpr<TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> func)
        {
            return Sequence.Create(this.expr1, this.expr2, this.expr3, this.expr4, this.expr5, this.expr6, this.expr7, this.expr8, this.expr9, this.expr10, this.expr11, this.expr12, this.expr13, this.expr14, this.expr15, func);
        }

        /// <summary>
        /// Transform to Sequence Expression with Custom Function
        /// </summary>
        /// <typeparam name="TResult">Return Type</typeparam>
        /// <param name="func">Transform Function</param>
        /// <param name="error">Function that return Custom Exception</param>
        /// <returns>Sequence Expression</returns>
        public Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> ToExpr<TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> func, Func<ParsingException, int, Exception> error)
        {
            return Sequence.Create(this.expr1, this.expr2, this.expr3, this.expr4, this.expr5, this.expr6, this.expr7, this.expr8, this.expr9, this.expr10, this.expr11, this.expr12, this.expr13, this.expr14, this.expr15, func, error);
        }

        public MakeSequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Next<T16>(ExpressionBase<T16> rhs)
        {
            return new MakeSequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this.expr1, this.expr2, this.expr3, this.expr4, this.expr5, this.expr6, this.expr7, this.expr8, this.expr9, this.expr10, this.expr11, this.expr12, this.expr13, this.expr14, this.expr15, rhs);
        }
    }
    public class MakeSequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>
    {
        internal ExpressionBase<T1> expr1;
        internal ExpressionBase<T2> expr2;
        internal ExpressionBase<T3> expr3;
        internal ExpressionBase<T4> expr4;
        internal ExpressionBase<T5> expr5;
        internal ExpressionBase<T6> expr6;
        internal ExpressionBase<T7> expr7;
        internal ExpressionBase<T8> expr8;
        internal ExpressionBase<T9> expr9;
        internal ExpressionBase<T10> expr10;
        internal ExpressionBase<T11> expr11;
        internal ExpressionBase<T12> expr12;
        internal ExpressionBase<T13> expr13;
        internal ExpressionBase<T14> expr14;
        internal ExpressionBase<T15> expr15;
        internal ExpressionBase<T16> expr16;

        internal MakeSequence(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8, ExpressionBase<T9> expr9, ExpressionBase<T10> expr10, ExpressionBase<T11> expr11, ExpressionBase<T12> expr12, ExpressionBase<T13> expr13, ExpressionBase<T14> expr14, ExpressionBase<T15> expr15, ExpressionBase<T16> expr16)
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
            this.expr16 = expr16;

        }

        /// <summary>
        /// Transform to Sequence Expression
        /// </summary>
        /// <typeparam name="TResult">Return Type</typeparam>
        /// <param name="func">Transform Function</param>
        /// <returns>Sequence Expression</returns>
        public Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> ToExpr<TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> func)
        {
            return Sequence.Create(this.expr1, this.expr2, this.expr3, this.expr4, this.expr5, this.expr6, this.expr7, this.expr8, this.expr9, this.expr10, this.expr11, this.expr12, this.expr13, this.expr14, this.expr15, this.expr16, func);
        }

        /// <summary>
        /// Transform to Sequence Expression with Custom Function
        /// </summary>
        /// <typeparam name="TResult">Return Type</typeparam>
        /// <param name="func">Transform Function</param>
        /// <param name="error">Function that return Custom Exception</param>
        /// <returns>Sequence Expression</returns>
        public Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> ToExpr<TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> func, Func<ParsingException, int, Exception> error)
        {
            return Sequence.Create(this.expr1, this.expr2, this.expr3, this.expr4, this.expr5, this.expr6, this.expr7, this.expr8, this.expr9, this.expr10, this.expr11, this.expr12, this.expr13, this.expr14, this.expr15, this.expr16, func, error);
        }
    }
}
